using System.IO;
using Microsoft.VisualStudio.DebuggerVisualizers;

namespace OpenCvSharp.DebuggerVisualizers.TableVisualizer
{
    /// <summary>
    /// シリアライズ処理
    /// </summary>
    public class MatTableSource : VisualizerObjectSource
    {
        public override void GetData(object target, Stream outgoingData)
        {
            var serializable = new MatTableProxy((Mat)target);
            base.GetData(serializable, outgoingData);
        }
    }
}