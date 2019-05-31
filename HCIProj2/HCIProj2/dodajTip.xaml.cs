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
using Microsoft.Win32;

namespace HCIProj2
{
    /// <summary>
    /// Interaction logic for dodajTip.xaml
    /// </summary>
    public partial class dodajTip : Window
    {
        public dodajTip()
        {
            InitializeComponent();
        }

        private void dodajTipBtn_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void Button_Click_UcitajIkonicu(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files (*.png;*.jpg,*.ico)|*.ico;*.png;*.jpg";
            if (dialog.ShowDialog() == true)
            {
                IconPath.Text = dialog.FileName;
            }

        }

        private void odustaniBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
