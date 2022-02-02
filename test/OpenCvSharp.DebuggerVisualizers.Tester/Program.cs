using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

			//var data = new float[] { 1, 1, 1, 2, 2, 2, 3, 3, 3, 4, 4, 4, 5, 5, 5, 6, 6, 6, 7, 7, 7, 8, 8, 8, 9, 9, 9, 10, 10, 10, 11, 11, 11, 12, 12, 12 };
			//var mat = new Mat(4, 3, MatType.CV_32FC3, data);

			var _gridNeighborLeft = 400;
			var _gridSizeLeft = new Size(20, 20);
			var mat = (Mat)Mat.Zeros(_gridNeighborLeft, 9, MatType.CV_32SC1);
			InitalizeNeighbors(mat, _gridSizeLeft);

			//MatAsImageVisualizer.TestShowVisualizer(mat);
            MatAsGridVisualizer.TestShowVisualizer(mat);

            //var img = @"_data\image\calibration\00.jpg";
            //var mainForm = new ImageViewer(img);
            //Application.Run(mainForm);
        }

        static void InitalizeNeighbors(Mat neighbor, Size gridSize)
        {
            neighbor.SetTo(-1);
            for (int idx = 0; idx < neighbor.Rows; idx++)
            {
                //var NB9 = getNB9(i, gridSize);
                //int* data = neighbor.ptr<int>(i);
                //memcpy(data, &NB9[0], sizeof(int) * 9);

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
