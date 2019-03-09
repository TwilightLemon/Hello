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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Hello
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            gb.Children.Clear();
            Paint(int.Parse(count.Text));
        }

        private void Paint(int count=1) {
            Rt lastrt = new Rt { jd = 0 };
            double alljd = 0;
            for (int i = 0; i < count; i++)
            {
                Rt rt = new Rt();
                if (i == 0) rt.Width = 100;
                else rt.Width = lastrt.xb;
                rt.Height = 100;
                rt.set();
                rt.HorizontalAlignment = HorizontalAlignment.Center;
                rt.VerticalAlignment = VerticalAlignment.Center;
                rt.Margin = new Thickness(0, rt.Height, rt.Width, 0);
                RotateTransform rtf = new RotateTransform(0 - (lastrt.jd + alljd));
                rt.RenderTransformOrigin = new Point(1, 0);
                rt.RenderTransform = rtf;
                alljd += lastrt.jd;
                gb.Children.Add(rt);
                lastrt = rt;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            RotateTransform rtf = new RotateTransform();
            hb.RenderTransform = rtf;
            hb.RenderTransformOrigin = new Point(0.5,0.5);
            DoubleAnimation dbAscending = new DoubleAnimation(0, 360, new Duration
            (TimeSpan.FromSeconds(1)));
            dbAscending.RepeatBehavior = RepeatBehavior.Forever;
            rtf.BeginAnimation(RotateTransform.AngleProperty, dbAscending);
        }
    }
}
