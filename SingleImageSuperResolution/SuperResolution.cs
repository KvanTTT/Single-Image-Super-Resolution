using AnnWrapperNET;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SingleImageSuperResolution
{
    public class SuperResolution
    {
        private Bitmap _inputImage;

        public double DecZoomCoef
        {
            get;
            set;
        }

        public double ZoomCoef
        {
            get;
            set;
        }

        public int DecLevelsCount
        {
            get;
            set;
        }

        public int IncLevelsCount
        {
            get;
            set;
        }

        public double DecBlockIncXRatio
        {
            get;
            set;
        }

        public double DecBlockIncYRatio
        {
            get;
            set;
        }

        public int DecBlockWidth
        {
            get;
            set;
        }

        public int DecBlockHeight
        {
            get;
            set;
        }

        public int BlockWidth
        {
            get;
            set;
        }

        public int BlockHeight
        {
            get;
            set;
        }

        public double BlockIncRatioX
        {
            get;
            set;
        }

        public double BlockIncRatioY
        {
            get;
            set;
        }

        public double ReplaceDistance
        {
            get;
            set;
        }

        public bool Parallelization
        {
            get;
            set;
        }

        public SuperResolution(Bitmap bitmap)
        {
            _inputImage = new Bitmap(bitmap);
            DecLevelsCount = 1;
            IncLevelsCount = 1;
            BlockWidth = BlockHeight = 9;
            DecBlockWidth = DecBlockHeight = 9;
            DecBlockIncXRatio = DecBlockIncYRatio = 0;
        }

        public OutputInfo Process()
        {
            LevelImage origLevelImage;
            LevelImage[] decLevelImages;

            var image = _inputImage;
            double minDist = 0, maxDist = 0, avgDist = 0;
            for (int i = 0; i < IncLevelsCount; i++)
            {
                GenerateDecLevelsAndFragments(image, out origLevelImage, out decLevelImages);
                var mapping = SearchCorrespondingFragments(origLevelImage, decLevelImages);
                image = ReplaceFragments(origLevelImage, decLevelImages, mapping);

                double coef = 1.0 + (ZoomCoef - 1) * (i + 1) / IncLevelsCount;
                int newWidth = (int)Math.Round(_inputImage.Width * coef);
                int newHeight = (int)Math.Round(_inputImage.Height * coef);
                image = Utils.ChangeSize(image, newWidth, newHeight);

                var orderedByDistances = mapping.OrderBy(m => m.Distance);
                minDist = (minDist + orderedByDistances.First().Distance) / 2;
                maxDist = (maxDist + orderedByDistances.Last().Distance) / 2;
                avgDist = (avgDist + mapping.Average(m => m.Distance)) / 2;
            }

            return new OutputInfo
            {
                Image = image,
                MinDistance = minDist,
                MaxDistance = maxDist,
                AvgDistance = avgDist
            };
        }

        private void GenerateDecLevelsAndFragments(Bitmap image,
            out LevelImage origLevelImage, out LevelImage[] decLevelImages)
        {
            decLevelImages = new LevelImage[DecLevelsCount];
            origLevelImage = new LevelImage(image);

            double decBlockIncX = DecBlockIncXRatio * BlockWidth;
            if (DecBlockIncXRatio == 0)
                decBlockIncX = 1;
            double decBlockIncY = DecBlockIncYRatio * BlockHeight;
            if (DecBlockIncYRatio == 0)
                decBlockIncY = 1;

            double blockIncX = BlockIncRatioX * BlockWidth;
            if (BlockIncRatioX == 0)
                blockIncX = 1;
            double blockIncY = BlockIncRatioY * BlockHeight;
            if (BlockIncRatioY == 0)
                blockIncY = 1;

            for (int i = 0; i < DecLevelsCount; i++)
            {
                double coef = 1 / (Math.Pow(DecZoomCoef, (i + 1)));
                int newWidth = (int)Math.Round(_inputImage.Width * coef);
                int newHeight = (int)Math.Round(_inputImage.Height * coef);
                decLevelImages[i] = new LevelImage(_inputImage, newWidth, newHeight);
                decLevelImages[i].PrepareFragments(decBlockIncX, decBlockIncY, BlockWidth, BlockHeight);
            }

            origLevelImage.PrepareFragments(blockIncX, blockIncY, BlockWidth, BlockHeight);
        }

        private List<FragmentsMapping> SearchCorrespondingFragments(LevelImage origLevelImage, LevelImage[] decLevelImages)
        {
            int[] fragmentLevelsIndexes;
            var fragmentsYComps = LevelFragmentPointsToArray(decLevelImages, out fragmentLevelsIndexes);
            AnnWrapper.InitKdTree(fragmentsYComps,
                fragmentsYComps.Length / (BlockWidth * BlockHeight),
                BlockWidth * BlockHeight);

            var mapping = new List<FragmentsMapping>();
            if (!Parallelization)
            {
                for (int i = 0; i < origLevelImage.Fragments.Count; i++)
                    KdSearch(origLevelImage.Fragments, i, mapping, fragmentLevelsIndexes);
            }
            else
                Parallel.For(0, origLevelImage.Fragments.Count, i => KdSearch(origLevelImage.Fragments, i, mapping, fragmentLevelsIndexes));

            AnnWrapper.AnnFree();

            return mapping;
        }

        private void KdSearch(List<LevelImageFragment> fragments, int ind, List<FragmentsMapping> mapping, int[] fragmentLevelsIndexes)
        {
            var indDist = AnnWrapper.AnnKdSearch(fragments[ind].YComponents.Select(y => (double)y).ToArray());
            lock (mapping)
            {
                var fragmentMapping = new FragmentsMapping
                {
                    LevelIndex = FindLevelIndex(indDist.Item1, fragmentLevelsIndexes),
                    OrigIndex = ind,
                    Distance = indDist.Item2
                };
                fragmentMapping.DecIndex = indDist.Item1 - fragmentLevelsIndexes[fragmentMapping.LevelIndex];
                mapping.Add(fragmentMapping);
            }
        }

        private Bitmap ReplaceFragments(LevelImage origLevelImage, LevelImage[] decLevelImages, List<FragmentsMapping> mapping)
        {
            var origImage = origLevelImage.Image;
            var origLevelFragments = origLevelImage.Fragments;
            int width = origImage.Width;
            int height = origImage.Height;
            double blockIncX = BlockIncRatioX * BlockWidth;
            double blockIncY = BlockIncRatioY * BlockHeight;
            int iterCountX = (int)(width / blockIncX);
            int iterCountY = (int)(height / blockIncY);
            int fragmentsInLineX = (int)((width - BlockWidth) / blockIncX);
            int fragmentsInLineY = (int)((height - BlockHeight) / blockIncY);
            int overlapsCountX = (int)Math.Round(BlockWidth / blockIncX);
            int overlapsCountY = (int)Math.Round(BlockHeight / blockIncY);
            double blockWidth2 = BlockWidth * 0.5;
            double blockHeight2 = BlockHeight * 0.5;

            var result = new Bitmap(width, height);
            var overlapBlockNumbers = new List<int>(overlapsCountX + overlapsCountY);
            var distances = new List<double>(overlapsCountX + overlapsCountY);

            var resultRGB = new byte[width * height * Utils.ColorComponentsCount];

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    int ix = (int)(x / blockIncX);
                    int iy = (int)(y / blockIncY);

                    overlapBlockNumbers.Clear();
                    distances.Clear();
                    for (int iy1 = 0; iy1 < overlapsCountY; iy1++)
                    {
                        int blockNumberY = iy - iy1;
                        if (blockNumberY >= 0 && blockNumberY < fragmentsInLineY)
                        {
                            for (int ix1 = 0; ix1 < overlapsCountX; ix1++)
                            {
                                int blockNumberX = ix - ix1;
                                if (blockNumberX >= 0 && blockNumberX < fragmentsInLineX)
                                {
                                    var overlapBlockNumber = blockNumberY * fragmentsInLineX + blockNumberX;

                                    var blockOffset = origLevelImage.Fragments[overlapBlockNumber].Offset;
                                    var blockCenterX = blockOffset.X * width + blockWidth2;
                                    var blockCenterY = blockOffset.Y * height + blockHeight2;

                                    double distance;
                                    if (Math.Abs(x - blockCenterX) > Math.Abs(y - blockCenterY))
                                        distance = Math.Abs(x - blockCenterX) / blockWidth2;
                                    else
                                        distance = Math.Abs(y - blockCenterY) / blockHeight2;

                                    overlapBlockNumbers.Add(overlapBlockNumber);
                                    if (distance < 0)
                                        distance = 0;
                                    else if (distance > 1)
                                        distance = 1;
                                    distances.Add(1.0 - distance);
                                }
                            }
                        }
                    }

                    var invDistVectorLength = distances.Aggregate(0.0, (sum, d) => sum += d);
                    if (invDistVectorLength == 0.0)
                    {
                        invDistVectorLength = 1.0;
                        for (int i = 0; i < distances.Count; i++)
                            distances[i] = 1.0 / distances.Count;
                    }
                    else
                        invDistVectorLength = 1.0 / invDistVectorLength;

                    double r = 0, g = 0, b = 0;
                    if (overlapBlockNumbers.Count != 0)
                    {
                        for (int i = 0; i < overlapBlockNumbers.Count; i++)
                        {
                            var blockNumber = overlapBlockNumbers[i];
                            var fragmentMapping = mapping[blockNumber];

                            PointD origImageFragmentOffset, decImageFragmentOffset;
                            origImageFragmentOffset = origLevelImage.Fragments[fragmentMapping.OrigIndex].Offset;

                            int decReplaceCount = 0;
                            int origReplaceCount = 0;
                            if (fragmentMapping.Distance < ReplaceDistance)
                            {
                                decImageFragmentOffset = decLevelImages[fragmentMapping.LevelIndex].Fragments[fragmentMapping.DecIndex].Offset;
                                decReplaceCount++;
                            }
                            else
                            {
                                decImageFragmentOffset = origLevelImage.Fragments[blockNumber].Offset;
                                origReplaceCount++;
                            }

                            double dx = x - origImageFragmentOffset.X * origImage.Width;
                            double dy = y - origImageFragmentOffset.Y * origImage.Height;
                            int srcX = (int)Math.Round(decImageFragmentOffset.X * origImage.Width + dx);
                            int srcY = (int)Math.Round(decImageFragmentOffset.Y * origImage.Height + dy);

                            int ind = (srcY * origImage.Width + srcX) * Utils.ColorComponentsCount;
                            r += origLevelImage.RGB[ind + Utils.RedOffset] * distances[i] * invDistVectorLength;
                            g += origLevelImage.RGB[ind + Utils.GreenOffset] * distances[i] * invDistVectorLength;
                            b += origLevelImage.RGB[ind + Utils.BlueOffset] * distances[i] * invDistVectorLength;
                        }
                    }
                    else
                    {
                        int ind = (y * width + x) * Utils.ColorComponentsCount;
                        r = origLevelImage.RGB[ind + Utils.RedOffset];
                        g = origLevelImage.RGB[ind + Utils.GreenOffset];
                        b = origLevelImage.RGB[ind + Utils.BlueOffset];
                    }

                    int resultInd = (y * width + x) * Utils.ColorComponentsCount;
                    resultRGB[resultInd + Utils.RedOffset] = (byte)Math.Round(r);
                    resultRGB[resultInd + Utils.GreenOffset] = (byte)Math.Round(g);
                    resultRGB[resultInd + Utils.BlueOffset] = (byte)Math.Round(b);
                    resultRGB[resultInd + Utils.AlphaOffset] = 255;
                }
            }

            var resultImage = Utils.BytesArrayToBitmap(resultRGB, width, height);

            return resultImage;
        }

        private static double[] LevelFragmentPointsToArray(LevelImage[] levelImages, out int[] fragmentLevelsIndexes)
        {
            fragmentLevelsIndexes = new int[levelImages.Length];
            List<double> result = new List<double>(levelImages.Aggregate(0, (i, levelImage) => i += levelImage.Fragments.Count));
            int ind = 0;
            for (int i = 0; i < levelImages.Length; i++)
            {
                fragmentLevelsIndexes[i] = ind;
                var yComps = levelImages[i].FragmentYCompsToDoubleArray();
                result.AddRange(yComps);
                ind += yComps.Length / (levelImages[i].Fragments[0].YComponents.Length);
            }
            return result.ToArray();
        }

        private int FindLevelIndex(int fragmentIndex, int[] fragmentLevelsIndexes)
        {
            for (int i = 1; i < fragmentLevelsIndexes.Length; i++)
                if (fragmentIndex <= fragmentLevelsIndexes[i])
                    return i - 1;
            return fragmentLevelsIndexes.Length - 1;
        }
    }
}
