using System;
using System.Windows;
using Microsoft.VisualStudio.DebuggerVisualizers;

namespace OpenCvSharp.DebuggerVisualizers.GridVisualizer
{


    /// <summary>
    /// DialogDebuggerVisualizer that displays a Mat in a grid
    /// </summary>
    public class MatGridVisualizer : DialogDebuggerVisualizer
    {
        protected override void Show(IDialogVisualizerService windowService, IVisualizerObjectProvider objectProvider)
        {
            var objectProvider2 = objectProvider as IVisualizerObjectProvider2;
            using var mat = (objectProvider2 != null ? objectProvider2.GetObject() : objectProvider.GetObject()) as MatGridProxy;
            if (mat is null)
                throw new ArgumentException();

            var control = new ControlGridViewer { DataContext = mat };
            var win = new System.Windows.Window
            {
                Title         = "Mat Viewer",
                Content       = control,
                SizeToContent = SizeToContent.WidthAndHeight,
                //Icon          = new BitmapImage(new Uri("pack://application:,,,/OpenCvSharp.DebuggerVisualizers;component/logo.png")),
                //Icon          = BitmapFrame.Create(Application.GetResourceStream(new Uri("logo.png", UriKind.RelativeOrAbsolute)).Stream),
            };
            win.ShowDialog();
        }



        /// <summary>
        /// Method to call from a test executable in order to easily test the visualizer in a debugger
        /// </summary>
        /// <param name="objectToVisualize"></param>
        public static void TestShowVisualizer(object objectToVisualize)
        {
            var proxy = new MatGridProxy((Mat)objectToVisualize);
            VisualizerDevelopmentHost myHost = new(proxy, typeof(MatGridVisualizer));
            myHost.ShowVisualizer();
        }

    }
}
