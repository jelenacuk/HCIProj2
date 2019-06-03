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
    /// Interaction logic for izmenaEtikete.xaml
    /// </summary>
    public partial class izmenaEtikete : Window
    {
        private Etiketa etiketa;
        public Etiketa Etiketa // Tag name Overshadows Tag from .NET library
        {
            get { return etiketa; }
            set { etiketa = value; }
        }

        private Etiketa origEtiketa;
        public Etiketa OrigEtiketa // Tag name Overshadows Tag from .NET library
        {
            get { return origEtiketa; }
            set { origEtiketa = value; }
        }


        private bool id_Error;
        private bool opis_Error;

        public izmenaEtikete(Etiketa e)
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            OrigEtiketa = e;
            etiketa = new Etiketa(e);
            DataContext = etiketa;
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


        private void Brisanje_Click(object sender, RoutedEventArgs e)
        {
            Podaci.getInstance().Etikete.Remove(origEtiketa);
            Close();
        }

        private void Izlaz_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Sacuvaj_Click(object sender, RoutedEventArgs e)
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
                for(int i = 0; i< Podaci.JustGiveMeInstance().Etikete.Count;i++)
                {
                    if (Podaci.JustGiveMeInstance().Etikete[i].Id == origEtiketa.Id)
                    {
                        Podaci.JustGiveMeInstance().Etikete[i] = etiketa;
                    }
                }
                Close();
            }
        }

        private void TextB_id_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (textB_id.Text.Length > 0)
                Sacuvaj.IsEnabled = true;
            else
                Sacuvaj.IsEnabled = false;
        }
    }
}
