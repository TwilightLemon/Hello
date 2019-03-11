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
            hb.Children.Clear();
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
                hb.Children.Insert(0, rt);
                lastrt = rt;
            }
        }
        int xz = 0;
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var bo = Resources["sx"] as Storyboard;
            if (xz == 0)
            { bo.Begin(); xz = 1; }
            else { bo.Pause(); xz = 0; }

        }
        int ss = 0;
        private async void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (ss == 0)
            {
                ss = 1;
                sx.IsEnabled = false;
                foreach (Rt rt in hb.Children)
                {
                    rt.BeginAnimation(OpacityProperty, new DoubleAnimation(0, TimeSpan.FromSeconds(0.1)));
                    await Task.Delay(100);
                }
                sx.IsEnabled = true;
            }
            else {
                ss = 0;
                sx.IsEnabled = false;
                for (int i=hb.Children.Count-1;i>-1;i--)
                {
                    hb.Children[i].BeginAnimation(OpacityProperty, new DoubleAnimation(1, TimeSpan.FromSeconds(0.1)));
                    await Task.Delay(100);
                }
                sx.IsEnabled = true;
            }
        }
    }
}
