using System;
using System.Windows.Forms;

namespace OpenCvSharp.DebuggerVisualizers.Tester
{
	static class Program
	{
		/// <summary>
		/// 应用程序的主入口点。
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

            // Test the MatAsGridVisualizer
            var _gridNeighborLeft = 400;
			var _gridSizeLeft = new Size(20, 20);
			var mat = (Mat)Mat.Zeros(_gridNeighborLeft, 9, MatType.CV_32SC1);
			InitalizeNeighbors(mat, _gridSizeLeft);
            //var data = new float[] { 1, 1, 1, 2, 2, 2, 3, 3, 3, 4, 4, 4, 5, 5, 5, 6, 6, 6, 7, 7, 7, 8, 8, 8, 9, 9, 9, 10, 10, 10, 11, 11, 11, 12, 12, 12 };
            //var mat = new Mat(4, 3, MatType.CV_32FC3, data);
            MatAsGridVisualizer.TestShowVisualizer(mat);

            // Test the MatAsImageVisualizer
            var img = new Mat(@"_data\image\calibration\00.jpg");
            MatAsImageVisualizer.TestShowVisualizer(img);
        }

        static void InitalizeNeighbors(Mat neighbor, Size gridSize)
        {
            neighbor.SetTo(-1);
            for (int idx = 0; idx < neighbor.Rows; idx++)
            {
                int idx_x = idx % gridSize.Width;
                int idx_y = idx / gridSize.Width;

                for (int yi = -1; yi <= 1; yi++)
                {
                    for (int xi = -1; xi <= 1; xi++)
                    {
                        int idx_xx = idx_x + xi;
                        int idx_yy = idx_y + yi;

                        if (idx_xx < 0 || idx_xx >= gridSize.Width || idx_yy < 0 || idx_yy >= gridSize.Height)
                            continue;

                        neighbor.At<int>(idx, xi + 4 + yi * 3) = idx_xx + idx_yy * gridSize.Width;
                    }
                }
            }
        } // end InitalizeNeighbors()

    }
}
