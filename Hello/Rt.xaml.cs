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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Hello
{
    /// <summary>
    /// Rt.xaml 的交互逻辑
    /// </summary>
    public partial class Rt : UserControl
    {
        public Rt()
        {
            InitializeComponent();
        }
        public double xb = 0;
        public double jd = 0;
        public void set() {
            xb = Math.Sqrt(Math.Pow(Width, 2) + Math.Pow(Height, 2));
            jd = Math.Asin(Height / xb) * 180 / Math.PI;
        }
        public void set(int i) {
            Color c=(Application.Current.Resources["color"] as SolidColorBrush).Color;
            p.Stroke = new SolidColorBrush(ChangeColor(c,0.5f));
        }
        private void UserControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            xb = Math.Sqrt(Math.Pow(Width, 2) + Math.Pow(Height, 2));
            jd = Math.Asin(Height / xb) * 180 / Math.PI;
        }

        public static Color ChangeColor(Color color, float correctionFactor)
        {
            float red = (float)color.R;
            float green = (float)color.G;
            float blue = (float)color.B;

            if (correctionFactor < 0)
            {
                correctionFactor = 1 + correctionFactor;
                red *= correctionFactor;
                green *= correctionFactor;
                blue *= correctionFactor;
            }
            else
            {
                red = (255 - red) * correctionFactor + red;
                green = (255 - green) * correctionFactor + green;
                blue = (255 - blue) * correctionFactor + blue;
            }

            if (red < 0) red = 0;

            if (red > 255) red = 255;

            if (green < 0) green = 0;

            if (green > 255) green = 255;

            if (blue < 0) blue = 0;

            if (blue > 255) blue = 255;



            return Color.FromArgb(color.A, (byte)(int)red, (byte)(int)green, (byte)(int)blue);
        }
    }
}
