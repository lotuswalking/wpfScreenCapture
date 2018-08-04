using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using System.Drawing;
using System.Drawing.Imaging;

using System.Windows.Interop;



namespace wpfScreenCapture
{
    /// <summary>
    /// win_capture.xaml 的交互逻辑
    /// </summary>
    public partial class win_capture : Window
    {
        public win_capture()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            setLable();
            this.Topmost = true;
        }

        private void setLable()
        {
            this.frm_Location.Content = this.Left.ToString() +","+ this.Top.ToString();
            this.frm_width.Content = "Width:"+this.Width.ToString();
            
            this.frm_height.Content = "Height:" + this.Height.ToString();

        }

        private void Canvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed) DragMove();
            if (Mouse.RightButton == MouseButtonState.Pressed) Close();

        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            setLable();
        }

        private void Window_LocationChanged(object sender, EventArgs e)
        {
            setLable();
        }

        private void Window_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Bitmap bmp = new Bitmap((int)this.Width, (int)this.Height);
            Graphics g = Graphics.FromImage(bmp);
            this.Hide();
            
            g.CopyFromScreen((int)this.Left, (int)this.Top, 0, 0, bmp.Size);
            //Clipboard.Clear();
            //Clipboard.SetImage(Imaging.CreateBitmapSourceFromHBitmap(bmp.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty,bmp.Size));
            bmp.Save(@"d:\bmp.png");
            MessageBox.Show("Screen Captured!");
            Close();
        }
    }
}
