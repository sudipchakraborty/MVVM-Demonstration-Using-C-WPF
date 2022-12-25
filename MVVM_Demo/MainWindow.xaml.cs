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

namespace MVVM_Demo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void txt_A_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void txt_B_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void btn_result_Click(object sender, RoutedEventArgs e)
        {
            int a = Convert.ToInt16(txt_A.Text);
            int b = Convert.ToInt16(txt_B.Text);
            txt_Result.Text=(a+b).ToString();
        }
    }
}
