using System;
using System.IO;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace OpenCvSharp.DebuggerVisualizers
{
    /// <summary>
    /// シリアライズ不可能なクラスをやり取りするために使うプロキシ。
    /// 送る際に、このProxyに表示に必要なシリアライズ可能なデータを詰めて送り、受信側で復元する。
    /// </summary>
    [Serializable]
    public class MatImageProxy : IDisposable
    {
        [NonSerialized] private ImageSource _imageSource;

        public byte[] ImageData { get; private set; }
        public ImageSource ImageSource => _imageSource ??= CreateBitmap();


        public MatImageProxy(Mat image)
        {
            ImageData = image.ToBytes(".png");
        }

        public void Dispose()
        {
            ImageData = null;
        }

        private ImageSource CreateBitmap()
        {
            if (ImageData == null)
                throw new Exception("ImageData == null");

            using var stream = new MemoryStream(ImageData);
            var imageSource = new BitmapImage();
            imageSource.BeginInit();
            imageSource.StreamSource = stream;
            imageSource.CacheOption = BitmapCacheOption.OnLoad;
            imageSource.EndInit();
            return imageSource;
        }
    }

 }