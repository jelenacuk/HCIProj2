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
using System.IO;
using Microsoft.Win32;
using System.ComponentModel;
using System.Collections.ObjectModel;


namespace HCIProj2
{
    /// <summary>
    /// Interaction logic for dodajTip.xaml
    /// </summary>
    public partial class izmenaTipa : Window, INotifyPropertyChanged
    {

        private Tip tip;
        public Tip Tip {
            get { return tip; }
            set {
                if (value != tip)
                {
                    tip = value;
                    OnPropertyChanged("Tip");
                }
            }
        }
        private Tip origTip;
        public Tip OrigTip {
            get { return origTip; }
            set {
                if (value != origTip)
                {
                    origTip = value;
                    OnPropertyChanged("OrigTip");
                }
            }
        }

        private bool id_Eror;
        private bool opis_Error;
        private bool ikonica_Error;
        private bool naziv_Error;

        public izmenaTipa(Tip t)
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            OrigTip = t;
            tip = new Tip(t);
            DataContext = tip;
            id_Eror = false;
            opis_Error = false;
            naziv_Error = false;
            ikonica_Error = false;
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

        private void textB_id_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (textB_id.Text.Length > 0)
                Sacuvaj.IsEnabled = true;
            else
                Sacuvaj.IsEnabled = false;
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

        private void Sacuvaj_Click(object sender, RoutedEventArgs e)
        {
            id_Eror = false; naziv_Error = false; opis_Error = false; ikonica_Error = false;
            textB_id.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            textB_naziv.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            textB_opis.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            textB_ikonica.GetBindingExpression(TextBox.TextProperty).UpdateSource();

            if (textB_id.Text == OrigTip.Id)
            {
                id_Eror = false;
            }
            else
            {
                for(int i = 0; i < Podaci.getInstance().Tipovi.Count; i++)
                {
                    if(Podaci.getInstance().Tipovi[i].Id == textB_id.Text)
                    {
                        id_Eror = true;
                        MessageBox.Show("Vec postoji tip sa tim ID-om");
                    }
                }
            }
            if (id_Eror == false && opis_Error == false && naziv_Error == false && ikonica_Error == false)
            {
                textB_id.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                textB_naziv.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                textB_ikonica.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                textB_opis.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                for (int i = 0; i < Podaci.getInstance().Tipovi.Count; i++)
                {
                    if(Podaci.getInstance().Tipovi[i].Id == OrigTip.Id)
                    {
                        Podaci.getInstance().Tipovi[i] = tip;
                    }
                }
                Close();
            }
        }

        private void Izlaz_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Brisanje_Click(object sender, RoutedEventArgs e)
        {
            Podaci.getInstance().Tipovi.Remove(origTip);
            Close();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
