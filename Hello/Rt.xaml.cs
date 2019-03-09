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
        private void UserControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            xb = Math.Sqrt(Math.Pow(Width, 2) + Math.Pow(Height, 2));
            jd = Math.Asin(Height / xb) * 180 / Math.PI;
        }
    }
}
