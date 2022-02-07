using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace OpenCvSharp.DebuggerVisualizers.ImageVisualizer
{
    /// <summary>
    /// Interaction logic for ControlImageViewer.xaml
    /// </summary>
    public partial class ControlImageViewer : UserControl
    {
        public ControlImageViewer()
        {
            InitializeComponent();
        }


        private void UIElement_OnMouseWheel(object sender, MouseWheelEventArgs e)
        {
            var image = sender as Image;
            var matrix = image.LayoutTransform.Value;

            if (e.Delta > 0)
            {
                matrix.ScaleAt(2, 2, e.GetPosition(this).X, e.GetPosition(this).Y);
            }
            else
            {
                matrix.ScaleAt(0.5, 0.5, e.GetPosition(this).X, e.GetPosition(this).Y);
            }

            image.LayoutTransform = new MatrixTransform(matrix);
            UpdateLayout();
            //image.Arrange(new System.Windows.Rect(0, 0, Width, Height));
        }
    }
}
