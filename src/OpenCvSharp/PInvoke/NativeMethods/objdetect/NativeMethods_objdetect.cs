﻿using System;
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;

#pragma warning disable 1591
// ReSharper disable InconsistentNaming

namespace OpenCvSharp
{
    static partial class NativeMethods
    {
        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void objdetect_groupRectangles1(IntPtr rectList, int groupThreshold, double eps);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void objdetect_groupRectangles2(IntPtr rectList, IntPtr weights, int groupThreshold, double eps);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void objdetect_groupRectangles3(
            IntPtr rectList, int groupThreshold, double eps, IntPtr weights, IntPtr levelWeights);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void objdetect_groupRectangles4(
            IntPtr rectList, IntPtr rejectLevels, IntPtr levelWeights, int groupThreshold, double eps);

        [Pure, DllImport(DllExtern, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void objdetect_groupRectangles_meanshift(
            IntPtr rectList, IntPtr foundWeights, IntPtr foundScales, double detectThreshold, Size winDetSize);
    }
}