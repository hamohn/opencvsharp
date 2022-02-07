using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace OpenCvSharp.DebuggerVisualizers.ImageVisualizer
{
    public class ZoomBorder : Border
    {
        private UIElement            _child = null;
        private System.Windows.Point _origin;
        private System.Windows.Point _start;



        private TranslateTransform GetTranslateTransform(UIElement element) => (TranslateTransform)((TransformGroup)element.RenderTransform).Children.First(tr => tr is TranslateTransform);
        private ScaleTransform     GetScaleTransform    (UIElement element) => (ScaleTransform)((TransformGroup)element.RenderTransform).Children.First(tr => tr is ScaleTransform);

        public override UIElement Child
        {
            get { return base.Child; }
            set
            {
                if (value != null && value != Child)
                    Initialize(value);
                base.Child = value;
            }
        }

        
        
        public void Initialize(UIElement element)
        {
            _child = element;
            if (_child != null)
            {
                var group = new TransformGroup();
                var st = new ScaleTransform();
                var tt = new TranslateTransform();
                group.Children.Add(st);
                group.Children.Add(tt);
                _child.RenderTransform       = group;
                _child.RenderTransformOrigin = new ();
                MouseWheel                  += ChildMouseWheel;
                MouseLeftButtonDown         += ChildMouseLeftButtonDown;
                MouseLeftButtonUp           += ChildMouseLeftButtonUp;
                MouseMove                   += ChildMouseMove;
                PreviewMouseRightButtonDown += ChildPreviewMouseRightButtonDown;
            }
        }



        public void Reset()
        {
            if (_child != null)
            {
                var st = GetScaleTransform(_child);
                st.ScaleX = 1.0;
                st.ScaleY = 1.0;

                var tt = GetTranslateTransform(_child);
                tt.X = 0.0;
                tt.Y = 0.0;
            }
        }



        #region Child Events

        private void ChildMouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (_child != null)
            {
                var st = GetScaleTransform(_child);
                var tt = GetTranslateTransform(_child);

                var zoom = e.Delta > 0 ? 1.2 : 1 / 1.2;

                var relative = e.GetPosition(_child);
                var absoluteX = relative.X * st.ScaleX + tt.X;
                var absoluteY = relative.Y * st.ScaleY + tt.Y;

                st.ScaleX *= zoom;
                st.ScaleY *= zoom;

                tt.X = absoluteX - relative.X * st.ScaleX;
                tt.Y = absoluteY - relative.Y * st.ScaleY;
            }
        }

        private void ChildMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (_child != null)
            {
                var tt = GetTranslateTransform(_child);
                _start = e.GetPosition(this);
                _origin = new System.Windows.Point(tt.X, tt.Y);
                Cursor = Cursors.Hand;
                _child.CaptureMouse();
            }
        }

        private void ChildMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (_child != null)
            {
                _child.ReleaseMouseCapture();
                Cursor = Cursors.Arrow;
            }
        }

        void ChildPreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            Reset();
        }

        private void ChildMouseMove(object sender, MouseEventArgs e)
        {
            if (_child != null)
            {
                if (_child.IsMouseCaptured)
                {
                    var tt = GetTranslateTransform(_child);
                    Vector v = _start - e.GetPosition(this);
                    tt.X = _origin.X - v.X;
                    tt.Y = _origin.Y - v.Y;
                }
            }
        }

        #endregion Child Events
    }
}
