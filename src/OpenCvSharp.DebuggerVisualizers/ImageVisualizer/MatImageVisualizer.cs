using System;
using System.Windows;
using Microsoft.VisualStudio.DebuggerVisualizers;

namespace OpenCvSharp.DebuggerVisualizers.ImageVisualizer
{
    /// <summary>
    /// DialogDebuggerVisualizer that displays a Mat as an image
    /// </summary>
    public class MatImageVisualizer : DialogDebuggerVisualizer
    {
        protected override void Show(IDialogVisualizerService windowService, IVisualizerObjectProvider objectProvider)
        {
            using var image = objectProvider.GetObject() as MatImageProxy;
            if (image is null)
                throw new ArgumentException();

            //using var form = new FormImageViewer(image);
            //windowService.ShowDialog(form);
            var control = new ControlImageViewer { DataContext = image };
            var win = new System.Windows.Window
            {
                Title         = "Image Viewer",
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
            var proxy = new MatImageProxy((Mat)objectToVisualize);
            VisualizerDevelopmentHost myHost = new(proxy, typeof(MatImageVisualizer));
            myHost.ShowVisualizer();
        }

    }

}
