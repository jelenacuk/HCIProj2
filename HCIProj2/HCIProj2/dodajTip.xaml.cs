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
using HCIProj2.Model;

namespace HCIProj2
{
    /// <summary>
    /// Interaction logic for dodajTip.xaml
    /// </summary>
    public partial class dodajTip : Window
    {

        private Tip tip;
        public Tip Tip
        {
            get { return tip; }
            set { tip = value; }
        }

        public dodajTip()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            tip = new Tip();
            DataContext = tip;
        }

        private void dodajTipBtn_Click(object sender, RoutedEventArgs e)
        {
            textB_id.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            textB_naziv.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            textB_ikonica.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            textB_opis.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            Podaci.dodajTip(tip);
            Close();
        }

        private void Button_Click_UcitajIkonicu(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files (*.png;*.jpg,*.ico)|*.ico;*.png;*.jpg";
            if (dialog.ShowDialog() == true)
            {
                textB_ikonica.Text = dialog.FileName;
            }

        }

        private void odustaniBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
