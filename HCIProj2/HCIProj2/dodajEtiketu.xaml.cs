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

        private bool id_Error;
        private bool opis_Error;

        public dodajEtiketu()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;

            etiketa = new Etiketa();
            DataContext = etiketa;
            id_Error = false;
            opis_Error = false;
        }


        private void Button_Click_dodajEtiketu(object sender, RoutedEventArgs e)
        {
            id_Error = false; opis_Error = false;
            textB_id.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            textB_opis.GetBindingExpression(TextBox.TextProperty).UpdateSource();

            if (id_Error == false && opis_Error == false)
            {
                textB_id.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                textB_opis.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                var item = (combo_color.SelectedItem as ComboBoxItem).Content as TextBlock;
                etiketa.Boja = item.Text;
                Podaci.dodajEtiketu(etiketa);
                Close();
            }
        }

        private void Button_Click_Odustani(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void textB_id_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
                id_Error = true;
        }

        private void textB_opis_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
                opis_Error = true;
        }

        private void textB_id_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (textB_id.Text.Length > 0)
                Didaj_Btn.IsEnabled = true;
            else
                Didaj_Btn.IsEnabled = false;
        }

        private void zatvoriProzor(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Help_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            PrikaziPomoc pomoc = new PrikaziPomoc("Etiketa", this);
            pomoc.Show();
        }
       
    }
}
