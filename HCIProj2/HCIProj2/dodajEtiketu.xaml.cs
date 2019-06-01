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
using HCIProj2;

namespace HCIProj2
{
    /// <summary>
    /// Interaction logic for dodajEtiketu.xaml
    /// </summary>
    public partial class dodajEtiketu : Window
    {
        private Etiketa etiketa;
        public Etiketa Etiketa // Tag name Overshadows Tag from .NET library
        {
            get { return etiketa; }
            set { etiketa = value; }
        }

        public dodajEtiketu()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;

            etiketa = new Etiketa();
            DataContext = etiketa;
        }

        
        private void Button_Click_dodajEtiketu(object sender, RoutedEventArgs e)
        {
            textB_id.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            textB_opis.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            var item = (combo_color.SelectedItem as ComboBoxItem).Content as TextBlock;
            etiketa.Boja = item.Text;
            Podaci.dodajEtiketu(etiketa);
            Close();
        }

        private void Button_Click_Odustani(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
