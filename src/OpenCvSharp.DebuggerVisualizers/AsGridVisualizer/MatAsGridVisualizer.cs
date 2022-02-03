using System;
using System.IO;
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
            var objProvider = (IVisualizerObjectProvider2)objectProvider;
            File.AppendAllText(@"c:\temp\DebuggerVisualizer.txt", $"Show: starting\n");
            //var obj = objectProvider.GetObject();
            var obj = objProvider.GetObject();
            File.AppendAllText(@"c:\temp\DebuggerVisualizer.txt", $"Show: objectProvider.GetObject() returned {obj}\n");
            using var mat = objectProvider.GetObject() as MatProxyGrid;
            if (mat is null)
                throw new ArgumentException();

            File.AppendAllText(@"c:\temp\DebuggerVisualizer.txt", $"Show: got mat {mat}\n");

            using var form = new FormGridViewer(mat);
            File.AppendAllText(@"c:\temp\DebuggerVisualizer.txt", $"Show: created form\n");
            windowService.ShowDialog(form);
            File.AppendAllText(@"c:\temp\DebuggerVisualizer.txt", $"Show: displayed form\n");
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
