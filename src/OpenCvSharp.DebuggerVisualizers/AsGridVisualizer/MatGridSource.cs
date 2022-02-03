using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Microsoft.VisualStudio.DebuggerVisualizers;

namespace OpenCvSharp.DebuggerVisualizers
{
    /// <summary>
    /// シリアライズ処理
    /// </summary>
    public class MatGridSource : VisualizerObjectSource
    {
        public override void GetData(object target, Stream outgoingData)
        {
            var serializable = new MatProxyGrid((Mat)target);
            base.GetData(serializable, outgoingData);
            //File.AppendAllText(@"c:\temp\DebuggerVisualizer.txt", $"GetData: {target}\n");
            //var bf = new BinaryFormatter();
            //bf.Serialize(outgoingData, new MatProxyGrid((Mat)target));

            //outgoingData.Seek(0, SeekOrigin.Begin);
            //var obj = bf.Deserialize(outgoingData);
            //File.AppendAllText(@"c:\temp\DebuggerVisualizer.txt", $"Deserialized: {obj}\n");
            //var mat = (MatProxyGrid)obj;
            //File.AppendAllText(@"c:\temp\DebuggerVisualizer.txt", $"rows={mat.Rows}, cols={mat.Cols}, channels={mat.Channels}, data[0,0]={mat.Data[0,0]}\n");
            //outgoingData.Seek(0, SeekOrigin.Begin);
            //using var fileStream = File.Create(@"c:\temp\DebuggerVisualizer.bin");
            //outgoingData.CopyTo(fileStream);
        }
    }
}