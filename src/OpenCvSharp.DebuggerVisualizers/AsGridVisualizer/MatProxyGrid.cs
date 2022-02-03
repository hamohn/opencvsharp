﻿using System;
using System.IO;

namespace OpenCvSharp.DebuggerVisualizers
{
    [Serializable]
    public class MatProxyGrid : IDisposable
    {
        public Scalar[,] Data     { get; set; }
        public int       Rows     { get; set; }
        public int       Cols     { get; set; }
        public int       Channels { get; set; }

        
        
        public MatProxyGrid(Mat mat)
        {
            File.AppendAllText(@"c:\temp\DebuggerVisualizer.txt", $"MatProxyGrid.construct from mat: {mat}\n");
            Rows     = mat.Rows;
            Cols     = mat.Cols;
            Channels = mat.Channels();
            Data     = GetScalarArray(mat);
            File.AppendAllText(@"c:\temp\DebuggerVisualizer.txt", $"MatProxyGrid.construct done\n");
        }



        public MatProxyGrid(Scalar[,] data, int rows, int cols, int elemChannels)
        {
            File.AppendAllText(@"c:\temp\DebuggerVisualizer.txt", $"MatProxyGrid.construct from data: rows: {rows}, cols: {cols}\n");
            Data     = data;
            Rows     = rows;
            Cols     = cols;
            Channels = elemChannels;
            File.AppendAllText(@"c:\temp\DebuggerVisualizer.txt", $"MatProxyGrid.construct done\n");
        }



        private unsafe Scalar[,] GetScalarArray(Mat mat)
        {
            File.AppendAllText(@"c:\temp\DebuggerVisualizer.txt", $"MatProxyGrid.GetScalarArray: {mat}\n");
            var scalars = new Scalar[mat.Rows, mat.Cols];
            var t = mat.Type();
            if (t == MatType.CV_8UC1)  { mat.GetRectangularArray(out byte  [,] array); mat.ForEachAsByte  ((byte*   v, int* p) => { scalars[p[0], p[1]] = new Scalar(        *v); }); } else
            if (t == MatType.CV_8SC1)  { mat.GetRectangularArray(out sbyte [,] array); mat.ForEachAsByte  ((byte*   v, int* p) => { scalars[p[0], p[1]] = new Scalar((sbyte) *v); }); } else
            if (t == MatType.CV_16UC1) { mat.GetRectangularArray(out short [,] array); mat.ForEachAsInt16 ((short*  v, int* p) => { scalars[p[0], p[1]] = new Scalar(        *v); }); } else
            if (t == MatType.CV_16SC1) { mat.GetRectangularArray(out ushort[,] array); mat.ForEachAsInt16 ((short*  v, int* p) => { scalars[p[0], p[1]] = new Scalar((ushort)*v); }); } else
            if (t == MatType.CV_32SC1) { mat.GetRectangularArray(out int   [,] array); mat.ForEachAsInt32 ((int*    v, int* p) => { scalars[p[0], p[1]] = new Scalar(        *v); }); } else
            if (t == MatType.CV_32FC1) { mat.GetRectangularArray(out float [,] array); mat.ForEachAsFloat ((float*  v, int* p) => { scalars[p[0], p[1]] = new Scalar(        *v); }); } else
            if (t == MatType.CV_64FC1) { mat.GetRectangularArray(out double[,] array); mat.ForEachAsDouble((double* v, int* p) => { scalars[p[0], p[1]] = new Scalar(        *v); }); } else
            if (t == MatType.CV_8UC2)  { mat.GetRectangularArray(out Vec2b [,] array); mat.ForEachAsVec2b ((Vec2b*  v, int* p) => { scalars[p[0], p[1]] = new Scalar(        (*v).Item0,         (*v).Item1); }); } else
            if (t == MatType.CV_8SC2)  { mat.GetRectangularArray(out Vec2b [,] array); mat.ForEachAsVec2b ((Vec2b*  v, int* p) => { scalars[p[0], p[1]] = new Scalar((sbyte) (*v).Item0, (sbyte) (*v).Item1); }); } else
            if (t == MatType.CV_16UC2) { mat.GetRectangularArray(out Vec2s [,] array); mat.ForEachAsVec2s ((Vec2s*  v, int* p) => { scalars[p[0], p[1]] = new Scalar((ushort)(*v).Item0, (ushort)(*v).Item1); }); } else
            if (t == MatType.CV_16SC2) { mat.GetRectangularArray(out Vec2w [,] array); mat.ForEachAsVec2s ((Vec2s*  v, int* p) => { scalars[p[0], p[1]] = new Scalar(        (*v).Item0,         (*v).Item1); }); } else
            if (t == MatType.CV_32SC2) { mat.GetRectangularArray(out Vec2i [,] array); mat.ForEachAsVec2i ((Vec2i*  v, int* p) => { scalars[p[0], p[1]] = new Scalar(        (*v).Item0,         (*v).Item1); }); } else
            if (t == MatType.CV_32FC2) { mat.GetRectangularArray(out Vec2f [,] array); mat.ForEachAsVec2f ((Vec2f*  v, int* p) => { scalars[p[0], p[1]] = new Scalar(        (*v).Item0,         (*v).Item1); }); } else
            if (t == MatType.CV_64FC2) { mat.GetRectangularArray(out Vec2d [,] array); mat.ForEachAsVec2d ((Vec2d*  v, int* p) => { scalars[p[0], p[1]] = new Scalar(        (*v).Item0,         (*v).Item1); }); } else
            if (t == MatType.CV_8UC3)  { mat.GetRectangularArray(out Vec3b [,] array); mat.ForEachAsVec3b ((Vec3b*  v, int* p) => { scalars[p[0], p[1]] = new Scalar(        (*v).Item0,         (*v).Item1,         (*v).Item2); }); } else
            if (t == MatType.CV_8SC3)  { mat.GetRectangularArray(out Vec3b [,] array); mat.ForEachAsVec3b ((Vec3b*  v, int* p) => { scalars[p[0], p[1]] = new Scalar((sbyte) (*v).Item0, (sbyte) (*v).Item1, (sbyte) (*v).Item2); }); } else
            if (t == MatType.CV_16UC3) { mat.GetRectangularArray(out Vec3s [,] array); mat.ForEachAsVec3s ((Vec3s*  v, int* p) => { scalars[p[0], p[1]] = new Scalar((ushort)(*v).Item0, (ushort)(*v).Item1, (ushort)(*v).Item2); }); } else
            if (t == MatType.CV_16SC3) { mat.GetRectangularArray(out Vec3w [,] array); mat.ForEachAsVec3s ((Vec3s*  v, int* p) => { scalars[p[0], p[1]] = new Scalar(        (*v).Item0,         (*v).Item1,         (*v).Item2); }); } else
            if (t == MatType.CV_32SC3) { mat.GetRectangularArray(out Vec3i [,] array); mat.ForEachAsVec3i ((Vec3i*  v, int* p) => { scalars[p[0], p[1]] = new Scalar(        (*v).Item0,         (*v).Item1,         (*v).Item2); }); } else
            if (t == MatType.CV_32FC3) { mat.GetRectangularArray(out Vec3f [,] array); mat.ForEachAsVec3f ((Vec3f*  v, int* p) => { scalars[p[0], p[1]] = new Scalar(        (*v).Item0,         (*v).Item1,         (*v).Item2); }); } else
            if (t == MatType.CV_64FC3) { mat.GetRectangularArray(out Vec3d [,] array); mat.ForEachAsVec3d ((Vec3d*  v, int* p) => { scalars[p[0], p[1]] = new Scalar(        (*v).Item0,         (*v).Item1,         (*v).Item2); }); } else
            if (t == MatType.CV_8UC4)  { mat.GetRectangularArray(out Vec4b [,] array); mat.ForEachAsVec4b ((Vec4b*  v, int* p) => { scalars[p[0], p[1]] = new Scalar(        (*v).Item0,         (*v).Item1,         (*v).Item2,         (*v).Item3); }); } else
            if (t == MatType.CV_8SC4)  { mat.GetRectangularArray(out Vec4b [,] array); mat.ForEachAsVec4b ((Vec4b*  v, int* p) => { scalars[p[0], p[1]] = new Scalar((sbyte) (*v).Item0, (sbyte) (*v).Item1, (sbyte) (*v).Item2, (sbyte) (*v).Item3); }); } else
            if (t == MatType.CV_16UC4) { mat.GetRectangularArray(out Vec4s [,] array); mat.ForEachAsVec4s ((Vec4s*  v, int* p) => { scalars[p[0], p[1]] = new Scalar((ushort)(*v).Item0, (ushort)(*v).Item1, (ushort)(*v).Item2, (ushort)(*v).Item3); }); } else
            if (t == MatType.CV_16SC4) { mat.GetRectangularArray(out Vec4w [,] array); mat.ForEachAsVec4s ((Vec4s*  v, int* p) => { scalars[p[0], p[1]] = new Scalar(        (*v).Item0,         (*v).Item1,         (*v).Item2,         (*v).Item3); }); } else
            if (t == MatType.CV_32SC4) { mat.GetRectangularArray(out Vec4i [,] array); mat.ForEachAsVec4i ((Vec4i*  v, int* p) => { scalars[p[0], p[1]] = new Scalar(        (*v).Item0,         (*v).Item1,         (*v).Item2,         (*v).Item3); }); } else
            if (t == MatType.CV_32FC4) { mat.GetRectangularArray(out Vec4f [,] array); mat.ForEachAsVec4f ((Vec4f*  v, int* p) => { scalars[p[0], p[1]] = new Scalar(        (*v).Item0,         (*v).Item1,         (*v).Item2,         (*v).Item3); }); } else
            if (t == MatType.CV_64FC4) { mat.GetRectangularArray(out Vec4d [,] array); mat.ForEachAsVec4d ((Vec4d*  v, int* p) => { scalars[p[0], p[1]] = new Scalar(        (*v).Item0,         (*v).Item1,         (*v).Item2,         (*v).Item3); }); } else
            throw new ArgumentException($"Mat type {mat.Type()} is not supported");
            File.AppendAllText(@"c:\temp\DebuggerVisualizer.txt", $"MatProxyGrid.GetScalarArray: Done\n");
            return scalars;
        }

        
        
        private Scalar[,] FillScalar<T>(Mat mat, T[,] array, Func<T, Scalar> T2Scalar)
        {
            var scalars = new Scalar[mat.Rows, mat.Cols];
            for (var r = 0; r < mat.Rows; r++)
                for (var c = 0; c < mat.Cols; c++)
                    scalars[r, c] = T2Scalar(array[r, c]);
            return scalars;
        }


        public void Dispose()
        {
            Data = null;
        }

    }
}
