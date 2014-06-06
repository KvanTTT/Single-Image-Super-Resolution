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
    public class FragmentEventArgs : EventArgs
    {
        public int IncLevel
        {
            get;
            set;
        }

        public int FragmentNumber
        {
            get;
            set;
        }

        public int FragmentCount
        {
            get;
            set;
        }

        public int IncLevelsCount
        {
            get;
            set;
        }

        public FragmentEventArgs(int incLevel, int incLevelsCount, int fragmentNumber, int fragmentCount)
        {
            IncLevel = incLevel;
            IncLevelsCount = incLevelsCount;
            FragmentNumber = fragmentNumber;
            FragmentCount = fragmentCount;
        }
    }

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

        public bool Blur
        {
            get;
            set;
        }

        public int BlurKernelSize
        {
            get;
            set;
        }

        public double BlurSigma
        {
            get;
            set;
        }

        public event EventHandler FragmentFounded;

        public SuperResolution(Bitmap bitmap)
        {
            _inputImage = new Bitmap(bitmap);
            DecLevelsCount = 1;
            IncLevelsCount = 1;
            BlockWidth = BlockHeight = 9;
            DecBlockWidth = DecBlockHeight = 9;
            DecBlockIncXRatio = DecBlockIncYRatio = 0;
            BlurKernelSize = 12;
            BlurSigma = 1.4;
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
                var mapping = SearchCorrespondingFragments(i, origLevelImage, decLevelImages);
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

            origLevelImage = new LevelImage(image, Blur, BlurKernelSize, BlurSigma);
            double blockIncX = BlockIncRatioX * BlockWidth;
            if (blockIncX < 1)
                blockIncX = 1;
            double blockIncY = BlockIncRatioY * BlockHeight;
            if (blockIncY < 1)
                blockIncY = 1;
            origLevelImage.PrepareFragments(Blur, blockIncX, blockIncY, BlockWidth, BlockHeight);

            double decBlockIncX = DecBlockIncXRatio * BlockWidth;
            if (decBlockIncX < 1)
                decBlockIncX = 1;
            double decBlockIncY = DecBlockIncYRatio * BlockHeight;
            if (decBlockIncY < 1)
                decBlockIncY = 1;

            for (int i = 0; i < DecLevelsCount; i++)
            {
                double coef = 1 / (Math.Pow(DecZoomCoef, (i + 1)));
                int newWidth = (int)Math.Round(image.Width * coef);
                int newHeight = (int)Math.Round(image.Height * coef);
                image = Utils.ChangeSize(image, newWidth, newHeight);
                decLevelImages[i] = new LevelImage(image, Blur, BlurKernelSize, BlurSigma);
                decLevelImages[i].PrepareFragments(Blur, decBlockIncX, decBlockIncY, BlockWidth, BlockHeight);
            }
        }

        private List<FragmentsMapping> SearchCorrespondingFragments(int incLevelNumber, LevelImage origLevelImage, LevelImage[] decLevelImages)
        {
            int[] fragmentLevelsIndexes;
            var fragmentsYComps = LevelFragmentPointsToArray(decLevelImages, out fragmentLevelsIndexes);
            AnnWrapper.InitKdTree(fragmentsYComps,
                fragmentsYComps.Length / (BlockWidth * BlockHeight),
                BlockWidth * BlockHeight);

            var mapping = new List<FragmentsMapping>();

            int pointsCount = 1000;
            int queryCount = (origLevelImage.Fragments.Count + pointsCount - 1) / pointsCount;
            for (int i = 0; i < queryCount; i++)
            {
                KdSearch(incLevelNumber, origLevelImage,
                    i * pointsCount, Math.Min((i + 1) * pointsCount, origLevelImage.Fragments.Count),
                    mapping, fragmentLevelsIndexes);
            }

            AnnWrapper.AnnFree();

            return mapping;
        }

        private void KdSearch(int incLevelNumber, LevelImage levelImage, int startInd, int endInd, List<FragmentsMapping> mapping, int[] fragmentLevelsIndexes)
        {
            var fragments = levelImage.Fragments;
            var indsDists = AnnWrapper.AnnKdSearch(levelImage.FragmentYCompsToDoubleArray(startInd, endInd), (endInd - startInd), levelImage.Fragments[0].Size);

            for (int i = 0; i < indsDists.Count; i++)
            {
                var fragmentMapping = new FragmentsMapping
                {
                    LevelIndex = FindLevelIndex(indsDists[i].Item1, fragmentLevelsIndexes),
                    OrigIndex = startInd + i,
                    Distance = indsDists[i].Item2
                };
                fragmentMapping.DecIndex = indsDists[i].Item1 - fragmentLevelsIndexes[fragmentMapping.LevelIndex];
                mapping.Add(fragmentMapping);
            }

            if (FragmentFounded != null)
                FragmentFounded(this, new FragmentEventArgs(incLevelNumber, IncLevelsCount, endInd, fragments.Count));
        }

        private Bitmap ReplaceFragments(LevelImage origLevelImage, LevelImage[] decLevelImages, List<FragmentsMapping> mapping)
        {
            int width = origLevelImage.Image.Width;
            int height = origLevelImage.Image.Height;
            var resultRGB = new byte[width * height * Utils.ColorComponentsCount];

            if (!Parallelization)
            {
                for (int y = 0; y < height; y++)
                {
                    ReplaceFragmentsPart(origLevelImage, decLevelImages, mapping, width, height, y, resultRGB);
                }
            }
            else
            {
                Parallel.For(0, height, y => ReplaceFragmentsPart(origLevelImage, decLevelImages, mapping, width, height, y, resultRGB));
            }

            var resultImage = Utils.BytesArrayToBitmap(resultRGB, width, height);

            return resultImage;
        }

        private void ReplaceFragmentsPart(LevelImage origLevelImage, LevelImage[] decLevelImages, List<FragmentsMapping> mapping, int width, int height, int y, byte[] resultRGB)
        {
            double blockIncX = BlockIncRatioX * BlockWidth;
            double blockIncY = BlockIncRatioY * BlockHeight;
            int fragmentsInLineX = (int)((width - BlockWidth) / blockIncX);
            int fragmentsInLineY = (int)((height - BlockHeight) / blockIncY);
            int overlapsCountX = (int)Math.Round(BlockWidth / blockIncX);
            int overlapsCountY = (int)Math.Round(BlockHeight / blockIncY);
            double blockWidth2 = BlockWidth * 0.5;
            double blockHeight2 = BlockHeight * 0.5;

            for (int x = 0; x < width; x++)
            {
                int ix = (int)(x / blockIncX);
                int iy = (int)(y / blockIncY);

                var overlapBlockNumbers = new List<int>(overlapsCountX + overlapsCountY);
                var distances = new List<double>(overlapsCountX + overlapsCountY);
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
                        if (fragmentMapping.Distance < ReplaceDistance && fragmentMapping.DecIndex < decLevelImages[fragmentMapping.LevelIndex].Fragments.Count)
                        {
                            decImageFragmentOffset = decLevelImages[fragmentMapping.LevelIndex].Fragments[fragmentMapping.DecIndex].Offset;
                            decReplaceCount++;
                        }
                        else
                        {
                            decImageFragmentOffset = origLevelImage.Fragments[blockNumber].Offset;
                            origReplaceCount++;
                        }

                        double dx = x - origImageFragmentOffset.X * width;
                        double dy = y - origImageFragmentOffset.Y * height;
                        int srcX = (int)Math.Round(decImageFragmentOffset.X * width + dx);
                        int srcY = (int)Math.Round(decImageFragmentOffset.Y * height + dy);

                        int ind = (srcY * width + srcX) * Utils.ColorComponentsCount;
                        r += origLevelImage.RGB[ind + Utils.RedOffset] * distances[i] * invDistVectorLength;
                        g += origLevelImage.RGB[ind + Utils.GreenOffset] * distances[i] * invDistVectorLength;
                        b += origLevelImage.RGB[ind + Utils.BlurOffset] * distances[i] * invDistVectorLength;
                    }
                }
                else
                {
                    int ind = (y * width + x) * Utils.ColorComponentsCount;
                    r = origLevelImage.RGB[ind + Utils.RedOffset];
                    g = origLevelImage.RGB[ind + Utils.GreenOffset];
                    b = origLevelImage.RGB[ind + Utils.BlurOffset];
                }

                int resultInd = (y * width + x) * Utils.ColorComponentsCount;
                resultRGB[resultInd + Utils.RedOffset] = (byte)Math.Round(r);
                resultRGB[resultInd + Utils.GreenOffset] = (byte)Math.Round(g);
                resultRGB[resultInd + Utils.BlurOffset] = (byte)Math.Round(b);
                resultRGB[resultInd + Utils.AlphaOffset] = 255;
            }
        }

        private static double[] LevelFragmentPointsToArray(LevelImage[] levelImages, out int[] fragmentLevelsIndexes)
        {
            fragmentLevelsIndexes = new int[levelImages.Length];
            List<double> result = new List<double>(levelImages.Aggregate(0, (i, levelImage) => i += levelImage.Fragments.Count));
            int ind = 0;
            int count = levelImages[0].Fragments[0].Size;
            for (int i = 0; i < levelImages.Length; i++)
            {
                fragmentLevelsIndexes[i] = ind;
                var yComps = levelImages[i].FragmentYCompsToDoubleArray();
                result.AddRange(yComps);
                ind += yComps.Length / count;
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
