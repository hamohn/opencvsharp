using System;
using Microsoft.VisualStudio.DebuggerVisualizers;

namespace OpenCvSharp.DebuggerVisualizers
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

            using var form = new FormImageViewer(image);
            windowService.ShowDialog(form);
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
