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

        private Tip tip;
        public Tip Tip
        {
            get { return tip; }
            set { tip = value; }
        }

        private bool id_Eror;
        private bool opis_Error;
        private bool ikonica_Error;
        private bool naziv_Error;

        public dodajTip()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            tip = new Tip();
            DataContext = tip;
            id_Eror = false;
            opis_Error = false;
            naziv_Error = false;
            ikonica_Error = false;
        }

        private void dodajTipBtn_Click(object sender, RoutedEventArgs e)
        {
            id_Eror = false; naziv_Error = false; opis_Error = false; ikonica_Error = false;
            textB_id.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            textB_naziv.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            textB_opis.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            textB_ikonica.GetBindingExpression(TextBox.TextProperty).UpdateSource();

            if (id_Eror == false && opis_Error == false && naziv_Error == false && ikonica_Error == false)
            {
                textB_id.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                textB_naziv.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                textB_ikonica.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                textB_opis.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                Podaci.dodajTip(tip);
                Close();
            }

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

        private void textB_id_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (textB_id.Text.Length > 0)
                dodajTipBtn.IsEnabled = true;
            else
                dodajTipBtn.IsEnabled = false;
        }

        private void textB_id_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
                id_Eror = true;
        }


        private void textB_naziv_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
                naziv_Error = true;
        }

        private void textB_opis_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
                opis_Error = true;
        }

        private void textB_ikonica_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
                ikonica_Error = true;
        }

        private void zatvoriProzor(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Help_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            PrikaziPomoc pomoc = new PrikaziPomoc("Tip", this);
            pomoc.Show();
        }
    }
}
