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
        private Bitmap _inputBitmap;

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

        public int DecBlockIncX
        {
            get;
            set;
        }

        public int DecBlockIncY
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
            _inputBitmap = new Bitmap(bitmap);
            DecLevelsCount = 1;
            IncLevelsCount = 1;
            BlockWidth = BlockHeight = 9;
            DecBlockWidth = DecBlockHeight = 9;
            DecBlockIncX = DecBlockIncY = 1;
        }

        public Bitmap Process()
        {
            LevelImage origLevelImage;
            LevelImage[] decLevelImages, incLevelImages;

            GenerateLevelsAndFragments(out origLevelImage, out decLevelImages, out incLevelImages);
            var mapping = SearchCorrespondingFragments(origLevelImage, decLevelImages);
            var resultImage = ReplaceFragments(origLevelImage, decLevelImages, incLevelImages, mapping);

            return resultImage;
        }

        private void GenerateLevelsAndFragments(out LevelImage origLevelImage, out LevelImage[] decLevelImages, out LevelImage[] incLevelImages)
        {
            decLevelImages = new LevelImage[DecLevelsCount];
            incLevelImages = new LevelImage[IncLevelsCount];
            origLevelImage = new LevelImage(_inputBitmap);

            for (int i = 0; i < DecLevelsCount; i++)
            {
                double coef = 1 / (Math.Pow(DecZoomCoef, (i + 1)));
                int newWidth = (int)Math.Round(_inputBitmap.Width * coef);
                int newHeight = (int)Math.Round(_inputBitmap.Height * coef);
                decLevelImages[i] = new LevelImage(_inputBitmap, newWidth, newHeight);
                decLevelImages[i].PrepareFragments(DecBlockIncX, DecBlockIncY, BlockWidth, BlockHeight);
            }

            for (int i = 0; i < IncLevelsCount; i++)
            {
                double coef = ZoomCoef * (i + 1) / IncLevelsCount;
                int newWidth = (int)Math.Round(_inputBitmap.Width * coef);
                int newHeight = (int)Math.Round(_inputBitmap.Height * coef);
                incLevelImages[i] = new LevelImage(_inputBitmap, newWidth, newHeight);
            }

            origLevelImage.PrepareFragments(BlockWidth, BlockHeight, BlockWidth, BlockHeight);
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

        private Bitmap ReplaceFragments(LevelImage origLevelImage, LevelImage[] decLevelImages, LevelImage[] incLevelImages, List<FragmentsMapping> mapping)
        {
            var resultImage = incLevelImages[0].Image;
            var origImage = origLevelImage.Image;
            var resultBlockWidth = (double)BlockWidth / origImage.Width * resultImage.Width;
            var resultBlockHeight = (double)BlockHeight / origImage.Height * resultImage.Height;

            var orderedByDistances = mapping.OrderBy(m => m.Distance);
            var minDist = orderedByDistances.First();
            var maxDist = orderedByDistances.Last();
            var avg = mapping.Average(m => m.Distance);

            using (var graphics = Graphics.FromImage(resultImage))
            {
                int decReplaceCount = 0;
                int origReplaceCount = 0;
                foreach (var fragmentMapping in mapping)
                {
                    PointD origImageFragmentOffset, decImageFragmentOffset;
                    if (fragmentMapping.Distance < ReplaceDistance)
                    {
                        origImageFragmentOffset = origLevelImage.Fragments[fragmentMapping.OrigIndex].Offset;
                        decImageFragmentOffset = decLevelImages[fragmentMapping.LevelIndex].Fragments[fragmentMapping.DecIndex].Offset;
                        decReplaceCount++;
                    }
                    else
                    {
                        origImageFragmentOffset = origLevelImage.Fragments[fragmentMapping.OrigIndex].Offset;
                        decImageFragmentOffset = origLevelImage.Fragments[fragmentMapping.OrigIndex].Offset;
                        origReplaceCount++;
                    }
                    graphics.DrawImage(origImage, new Rectangle(
                            (int)Math.Round(origImageFragmentOffset.X * resultImage.Width),
                            (int)Math.Round(origImageFragmentOffset.Y * resultImage.Height),
                            (int)Math.Round(resultBlockWidth),
                            (int)Math.Round(resultBlockHeight)),
                            (float)(decImageFragmentOffset.X * origImage.Width),
                            (float)(decImageFragmentOffset.Y * origImage.Height),
                            (float)(BlockWidth),
                            (float)(BlockHeight),
                            GraphicsUnit.Pixel);
                }
            }

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
