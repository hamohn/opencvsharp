using System;

namespace OpenCvSharp.DebuggerVisualizers
{
    [Serializable]
    public class MatProxyGrid : IDisposable
    {
        public Scalar[,] Data         { get; set; }
        public int       Rows         { get; set; }
        public int       Cols         { get; set; }
        public int       ElemChannels { get; set; }

        
        
        public MatProxyGrid(Mat mat)
        {
            Data = GetScalarArray(mat);
            Rows = mat.Rows;
            Cols = mat.Cols;
            ElemChannels = mat.Channels();
        }

        
        
        public MatProxyGrid(Scalar[,] data, int rows, int cols, int elemChannels)
        {
            Data = data;
            Rows = rows;
            Cols = cols;
            ElemChannels = elemChannels;
        }



        private Scalar[,] GetScalarArray(Mat mat)
        {
            var t = mat.Type();
            if (t == MatType.CV_8UC1)  { mat.GetRectangularArray(out byte  [,] array); return FillScalar(mat, array, v => new Scalar(v)); } else
            if (t == MatType.CV_8SC1)  { mat.GetRectangularArray(out sbyte [,] array); return FillScalar(mat, array, v => new Scalar(v)); } else
            if (t == MatType.CV_16UC1) { mat.GetRectangularArray(out short [,] array); return FillScalar(mat, array, v => new Scalar(v)); } else
            if (t == MatType.CV_16SC1) { mat.GetRectangularArray(out ushort[,] array); return FillScalar(mat, array, v => new Scalar(v)); } else
            if (t == MatType.CV_32SC1) { mat.GetRectangularArray(out int   [,] array); return FillScalar(mat, array, v => new Scalar(v)); } else
            if (t == MatType.CV_32FC1) { mat.GetRectangularArray(out float [,] array); return FillScalar(mat, array, v => new Scalar(v)); } else
            if (t == MatType.CV_64FC1) { mat.GetRectangularArray(out double[,] array); return FillScalar(mat, array, v => new Scalar(v)); } else
            if (t == MatType.CV_8UC2)  { mat.GetRectangularArray(out Vec2b [,] array); return FillScalar(mat, array, v => new Scalar(v.Item0, v.Item1)); } else
            if (t == MatType.CV_8SC2)  { mat.GetRectangularArray(out Vec2b [,] array); return FillScalar(mat, array, v => new Scalar(v.Item0, v.Item1)); } else
            if (t == MatType.CV_16UC2) { mat.GetRectangularArray(out Vec2s [,] array); return FillScalar(mat, array, v => new Scalar(v.Item0, v.Item1)); } else
            if (t == MatType.CV_16SC2) { mat.GetRectangularArray(out Vec2w [,] array); return FillScalar(mat, array, v => new Scalar(v.Item0, v.Item1)); } else
            if (t == MatType.CV_32SC2) { mat.GetRectangularArray(out Vec2i [,] array); return FillScalar(mat, array, v => new Scalar(v.Item0, v.Item1)); } else
            if (t == MatType.CV_32FC2) { mat.GetRectangularArray(out Vec2f [,] array); return FillScalar(mat, array, v => new Scalar(v.Item0, v.Item1)); } else
            if (t == MatType.CV_64FC2) { mat.GetRectangularArray(out Vec2d [,] array); return FillScalar(mat, array, v => new Scalar(v.Item0, v.Item1)); } else
            if (t == MatType.CV_8UC3)  { mat.GetRectangularArray(out Vec3b [,] array); return FillScalar(mat, array, v => new Scalar(v.Item0, v.Item1)); } else
            if (t == MatType.CV_8SC3)  { mat.GetRectangularArray(out Vec3b [,] array); return FillScalar(mat, array, v => new Scalar(v.Item0, v.Item1, v.Item2)); } else
            if (t == MatType.CV_16UC3) { mat.GetRectangularArray(out Vec3s [,] array); return FillScalar(mat, array, v => new Scalar(v.Item0, v.Item1, v.Item2)); } else
            if (t == MatType.CV_16SC3) { mat.GetRectangularArray(out Vec3w [,] array); return FillScalar(mat, array, v => new Scalar(v.Item0, v.Item1, v.Item2)); } else
            if (t == MatType.CV_32SC3) { mat.GetRectangularArray(out Vec3i [,] array); return FillScalar(mat, array, v => new Scalar(v.Item0, v.Item1, v.Item2)); } else
            if (t == MatType.CV_32FC3) { mat.GetRectangularArray(out Vec3f [,] array); return FillScalar(mat, array, v => new Scalar(v.Item0, v.Item1, v.Item2)); } else
            if (t == MatType.CV_64FC3) { mat.GetRectangularArray(out Vec3d [,] array); return FillScalar(mat, array, v => new Scalar(v.Item0, v.Item1, v.Item2)); } else
            if (t == MatType.CV_8UC4)  { mat.GetRectangularArray(out Vec4b [,] array); return FillScalar(mat, array, v => new Scalar(v.Item0, v.Item1, v.Item2, v.Item3)); } else
            if (t == MatType.CV_8SC4)  { mat.GetRectangularArray(out Vec4b [,] array); return FillScalar(mat, array, v => new Scalar(v.Item0, v.Item1, v.Item2, v.Item3)); } else
            if (t == MatType.CV_16UC4) { mat.GetRectangularArray(out Vec4s [,] array); return FillScalar(mat, array, v => new Scalar(v.Item0, v.Item1, v.Item2, v.Item3)); } else
            if (t == MatType.CV_16SC4) { mat.GetRectangularArray(out Vec4w [,] array); return FillScalar(mat, array, v => new Scalar(v.Item0, v.Item1, v.Item2, v.Item3)); } else
            if (t == MatType.CV_32SC4) { mat.GetRectangularArray(out Vec4i [,] array); return FillScalar(mat, array, v => new Scalar(v.Item0, v.Item1, v.Item2, v.Item3)); } else
            if (t == MatType.CV_32FC4) { mat.GetRectangularArray(out Vec4f [,] array); return FillScalar(mat, array, v => new Scalar(v.Item0, v.Item1, v.Item2, v.Item3)); } else
            if (t == MatType.CV_64FC4) { mat.GetRectangularArray(out Vec4d [,] array); return FillScalar(mat, array, v => new Scalar(v.Item0, v.Item1, v.Item2, v.Item3)); } else
            throw new ArgumentException($"Mat Depth {mat.Depth()} is not supported");
        }

        
        
        private Scalar[,] FillScalar<T>(Mat mat, T[,] array, Func<T, Scalar> Conv)
            where T : struct
        {
            var scalars = new Scalar[mat.Rows, mat.Cols];
            for (var r = 0; r < mat.Rows; r++)
                for (var c = 0; c < mat.Cols; c++)
                    scalars[r, c] = Conv(array[r, c]);
            return scalars;
        }



        public void Dispose()
        {
        }

    }
}
