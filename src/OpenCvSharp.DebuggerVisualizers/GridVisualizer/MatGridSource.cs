using System.IO;
using Microsoft.VisualStudio.DebuggerVisualizers;

namespace OpenCvSharp.DebuggerVisualizers.GridVisualizer
{
    /// <summary>
    /// シリアライズ処理
    /// </summary>
    public class MatGridSource : VisualizerObjectSource
    {
        public override void GetData(object target, Stream outgoingData)
        {
            var serializable = new MatGridProxy((Mat)target);
            base.GetData(serializable, outgoingData);
        }
    }
}