using System;
using System.Windows;
using System.Windows.Media.Imaging;
using Microsoft.VisualStudio.DebuggerVisualizers;

namespace OpenCvSharp.DebuggerVisualizers.TableVisualizer
{


    /// <summary>
    /// DialogDebuggerVisualizer that displays a Mat in a grid
    /// </summary>
    public class MatTableVisualizer : DialogDebuggerVisualizer
    {
        protected override void Show(IDialogVisualizerService windowService, IVisualizerObjectProvider objectProvider)
        {
            var objectProvider2 = objectProvider as IVisualizerObjectProvider2;
            using var matTableProxy = (objectProvider2 != null ? objectProvider2.GetObject() : objectProvider.GetObject()) as MatTableProxy;
            if (matTableProxy is null)
                throw new ArgumentException();

            var control = new ControlTableViewer { DataContext = matTableProxy };
            var win = new System.Windows.Window
            {
                Title         = "Mat Table Viewer",
                Content       = control,
                SizeToContent = SizeToContent.WidthAndHeight,
                Icon          = new BitmapImage(new Uri("pack://application:,,,/OpenCvSharp.DebuggerVisualizers;component/logo.png")),
            };
            win.ShowDialog();
        }



        /// <summary>
        /// Method to call from a test executable in order to easily test the visualizer in a debugger
        /// </summary>
        /// <param name="objectToVisualize"></param>
        public static void TestShowVisualizer(object objectToVisualize)
        {
            var proxy = new MatTableProxy((Mat)objectToVisualize);
            VisualizerDevelopmentHost myHost = new(proxy, typeof(MatTableVisualizer));
            myHost.ShowVisualizer();
        }

    }
}
