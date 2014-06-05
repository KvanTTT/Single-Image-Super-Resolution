using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AnnWrapperNET
{
    public unsafe class AnnWrapper
    {
        const string DllPath = "ANN.dll";

        #region Unmanaged Helpers

        [DllImport(DllPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "annDist")]
        private static extern double* AnnDist(int dim, double* p, double* q);

        [DllImport(DllPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "annAllocPt")]
        private static extern double* AnnAllocPt(int dim, double c = 0);

        [DllImport(DllPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "annAllocPts")]
        private static extern double** AnnAllocPts(int n, int dim);

        [DllImport(DllPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "annDeallocPt")]
        private static extern double* AnnDeallocPt(double* p);

        [DllImport(DllPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "annDeallocPts")]
        private static extern double* AnnDeallocPts(double** p);

        [DllImport(DllPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "annCopyPt")]
        private static extern double* AnnCopyPt(int dim, double* source);

        [DllImport(DllPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "annMaxPtsVisit")]
        private static extern void AnnMaxPtsVisit(int maxPts);

        [DllImport(DllPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "annClose")]
        private static extern void AnnClose();

        [DllImport(DllPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "initKdTree")]
        private static extern void InitKdTree(double* data, int n, int dim, int bucketSize = 1, ANNSplitRule splitRule = ANNSplitRule.ANN_KD_SUGGEST);

        [DllImport(DllPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "annKdSearch")]
        private static extern void AnnKdSearch(double* q, int k, int* nnIdx, double* dd, double eps = 0.0);

        [DllImport(DllPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "annkPriSearch")]
        private static extern void AnnkPriSearch(double* q, int k, int* nnIdx, double* dd, double eps = 0.0);

        [DllImport(DllPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "annkFRSearch")]
        private static extern void AnnkFRSearch(double* q, double squareRadius, int k, int* nnIdx, double* dd, double eps = 0.0);

        #endregion

        public static void InitKdTree(double[][] points, int bucketSize = 1, ANNSplitRule splitRule = ANNSplitRule.ANN_KD_SUGGEST)
        {
            int n = points.Length;
            int dim = points[0].Length;
            double[] data = new double[n * dim];
            for (int i = 0; i < points.Length; i++)
                for (int j = 0; j < dim; j++)
                    data[i * dim + j] = points[i][j];
            InitKdTree(data, n, dim, bucketSize, splitRule);
        }

        public static void InitKdTree(double[] points, int n, int dim, int bucketSize = 1, ANNSplitRule splitRule = ANNSplitRule.ANN_KD_SUGGEST)
        {
            fixed (double* d = points)
                InitKdTree(d, n, dim, bucketSize, splitRule);
        }

        public static Tuple<int, double> AnnKdSearch(double[] point, double eps = 0.0)
        {
            var indexes = new int[1];
            var distances = new double[1];
            AnnKdSearch(point, 1, out indexes, out distances, eps);
            return new Tuple<int, double>(indexes[0], Math.Sqrt(distances[0]));
        }

        public static void AnnKdSearch(double[] point, int nearNeighbourCount, out int[] indexes, out double[] distances, double eps = 0.0)
        {
            indexes = new int[nearNeighbourCount];
            distances = new double[nearNeighbourCount];
            fixed (double* p = point)
                fixed (int* ind = indexes)
                    fixed (double* d = distances)
                        AnnKdSearch(p, nearNeighbourCount, ind, d, eps);
        }

        public static void AnnkPriSearch(double[] point, int nearNeighbourCount, out int[] indexes, out double[] distances, double eps = 0.0)
        {
            indexes = new int[nearNeighbourCount];
            distances = new double[nearNeighbourCount];
            fixed (double* p = point)
                fixed (int* ind = indexes)
                    fixed (double* d = distances)
                        AnnkPriSearch(p, nearNeighbourCount, ind, d, eps);
        }

        public static void AnnkFRSearch(double[] point, double squareRadius, int nearNeighbourCount, out int[] indexes, out double[] distances, double eps = 0.0)
        {
            indexes = new int[nearNeighbourCount];
            distances = new double[nearNeighbourCount];
            fixed (double* p = point)
                fixed (int* ind = indexes)
                    fixed (double* d = distances)
                        AnnkFRSearch(p, squareRadius, nearNeighbourCount, ind, d, eps);
        }

        [DllImport(DllPath, CallingConvention = CallingConvention.Cdecl, EntryPoint = "annFree")]
        public static extern void AnnFree();
    }
}