using System;
using Microsoft.VisualStudio.DebuggerVisualizers;

namespace OpenCvSharp.DebuggerVisualizers
{


    /// <summary>
    /// DialogDebuggerVisualizer that displays a Mat in a grid
    /// </summary>
    public class MatAsGridVisualizer : DialogDebuggerVisualizer
    {
        protected override void Show(IDialogVisualizerService windowService, IVisualizerObjectProvider objectProvider)
        {
            using var mat = objectProvider.GetObject() as MatProxyGrid;
            if (mat is null)
                throw new ArgumentException();

            using var form = new FormGridViewer(mat);
            windowService.ShowDialog(form);
        }



        /// <summary>
        /// Method to call from a test executable in order to easily test the visualizer in a debugger
        /// </summary>
        /// <param name="objectToVisualize"></param>
        public static void TestShowVisualizer(object objectToVisualize)
        {
            var proxy = new MatProxyGrid((Mat)objectToVisualize);
            VisualizerDevelopmentHost myHost = new(proxy, typeof(MatAsGridVisualizer));
            myHost.ShowVisualizer();
        }

    }
}
