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
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace HCIProj2
{
    public partial class DodajLokal : Window, INotifyPropertyChanged
    {

        private Lokal lokal;
        public Lokal Lokal {
            get { return lokal; }
            set {
                if (value != lokal)
                {
                    lokal = value;
                    OnPropertyChanged("Lokal");
                }
            }
        }

        private ObservableCollection<Etiketa> izabraneEtikete;
        public ObservableCollection<Etiketa> IzabraneEtikete
        {
            get { return izabraneEtikete; }
            set
            {
                if (value != izabraneEtikete)
                {
                    izabraneEtikete = value;
                    OnPropertyChanged("Etikete");
                }
            }
        }
        private bool id_Eror;
        private bool opis_Error;
        private bool ikonica_Error;
        private bool naziv_Error;
        private bool datum_Error;
        private bool kapacitet_Error;



        public DodajLokal()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            lokal = new Lokal();

            autoCompleteBoxTags.DataContext = Podaci.JustGiveMeInstance();
            DataContext = lokal;

            izabraneEtikete = new ObservableCollection<Etiketa>();
            comboBoxTags.DataContext = this;
            id_Eror = false;
            opis_Error = false;
            naziv_Error = false;
            ikonica_Error = false;
            datum_Error = false;
            kapacitet_Error = false;

        }

        private void dodajLokal_Click(object sender, RoutedEventArgs e)
        {
            id_Eror = false; naziv_Error = false; opis_Error = false; ikonica_Error = false; datum_Error = false;
            textB_id.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            textB_naziv.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            textB_opis.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            textB_ikonica.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            textB_datum.GetBindingExpression(TextBox.TextProperty).UpdateSource();

            if (kapacitet_Error == false && id_Eror == false && opis_Error == false && naziv_Error == false && ikonica_Error == false && datum_Error == false && proveraComboBox() == true)
            {
                lokal.Tip = (combo_tipovi.SelectedItem) as Tip;
                textB_id.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                textB_naziv.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                textB_opis.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                textB_kapacitet.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                textB_ikonica.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                textB_datum.GetBindingExpression(TextBox.TextProperty).UpdateSource();

                if (textB_ikonica.Text.Equals(""))
                {
                    lokal.Ikonica = lokal.Tip.Ikonica;
                }
                lokal.DozvoljenoPusenje = ((combo_pusenje.SelectedItem as ComboBoxItem).Content as TextBlock).Text;
                lokal.CenovnaKategorija = ((combo_cene.SelectedItem as ComboBoxItem).Content as TextBlock).Text;
                lokal.DostupanHendikepiranim = ((combo_hendikepirani.SelectedItem as ComboBoxItem).Content as TextBlock).Text;
                lokal.PrimaRezervacije = ((combo_rezervacije.SelectedItem as ComboBoxItem).Content as TextBlock).Text;
                lokal.SluziAlkohol = ((combo_alkohol.SelectedItem as ComboBoxItem).Content as TextBlock).Text;
                Podaci.JustGiveMeInstance().Lokali.Add(lokal);
                Close();
            }
        }
        private bool proveraComboBox()
        {
            bool returnValue = true;
            if (textB_kapacitet.Equals(""))
            {
                kapacitetError_tb.Visibility = Visibility.Visible;
                returnValue = false;
            }
            if (combo_cene.SelectedItem == null)
            {
                ceneError_tb.Visibility = Visibility.Visible;
                returnValue = false;
            }
            if ((combo_rezervacije.SelectedItem == null))
            {
                rezervacijeError_tb.Visibility = Visibility.Visible;
                returnValue = false;

            }
            if ((combo_pusenje.SelectedItem == null))
            {
                pusenjeError_tb.Visibility = Visibility.Visible;
                returnValue = false;

            }
            if ((combo_hendikepirani.SelectedItem == null))
            {
                hendikepiraniError_tb.Visibility = Visibility.Visible;
                returnValue = false;

            }
            if ((combo_alkohol.SelectedItem == null))
            {
                alkoholError_tb.Visibility = Visibility.Visible;
                returnValue = false;

            }
            if ((combo_tipovi.SelectedItem == null))
            {
                tipoviError_tb.Visibility = Visibility.Visible;
                returnValue = false;

            }
            return returnValue;
        }
        //=====================ETIKETE======================
        private void dodajEtiketuBtn_Click(object sender, RoutedEventArgs e)
        {

            Etiketa etiketa = Podaci.getEtiketa(autoCompleteBoxTags.Text);
            if (etiketa != null)
            {
                bool found = false;
                foreach (var et in lokal.Etikete)
                {
                    if (etiketa.Id.Equals(et.Id))
                    {
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    lokal.Etikete.Add(etiketa);
                    IzabraneEtikete.Add(etiketa);
                }
                autoCompleteBoxTags.SelectedItem = null;
                autoCompleteBoxTags.Text = string.Empty;
            }
            else
            {
                dodajEtiketu navaEtiketa = new dodajEtiketu();
                navaEtiketa.Show();
            }
        }
        private void autoCompleteBoxTag_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                dodajEtiketuBtn_Click(null, null);
            }
        }

        //===================== TIPOVI======================
        private void combo_tipovi_Loaded(object sender, RoutedEventArgs e)
        {
            var combo = sender as ComboBox;
            combo.ItemsSource = Podaci.getInstance().Tipovi;
            combo.DisplayMemberPath = "Naziv";
        }
        private void noviTip_Click(object sender, RoutedEventArgs e)
        {
            dodajTip noviTip = new dodajTip();
            noviTip.Show();
        }


        //=====================IKONICA======================
        private void loadIcon_Click(object sender, RoutedEventArgs e)
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


        #region PropertyChangedNotifier
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        #endregion

        private void textB_id_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (textB_id.Text.Length > 0)
                dodajLokal.IsEnabled = true;
            else
                dodajLokal.IsEnabled = false;
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

        private void textB_datum_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
                datum_Error = true;
        }

        private void textB_ikonica_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
                ikonica_Error = true;
        }

        private void combo_cene_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ceneError_tb.Visibility = Visibility.Hidden;
        }

        private void combo_rezervacije_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            rezervacijeError_tb.Visibility = Visibility.Hidden;
        }

        private void combo_hendikepirani_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            hendikepiraniError_tb.Visibility = Visibility.Hidden;
        }

        private void combo_pusenje_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            pusenjeError_tb.Visibility = Visibility.Hidden;
        }

        private void combo_alkohol_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            alkoholError_tb.Visibility = Visibility.Hidden;
        }

        private void combo_tipovi_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            tipoviError_tb.Visibility = Visibility.Hidden;
        }

        private void zatvoriProzor(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Help_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            PrikaziPomoc pomoc = new PrikaziPomoc("Lokal", this);
            pomoc.Show();
        }
        private void TextB_kapacitet_TextChanged(object sender, TextChangedEventArgs e)
        {
            var kapacitet = textB_kapacitet.Text;
            int n = 0;
            bool isNumeric = int.TryParse(kapacitet, out n);
            if (!isNumeric)
            {
                kapacitetError_tb.Text = "Morate uneti broj.";
                kapacitetError_tb.Visibility = Visibility.Visible;
                kapacitet_Error = true;
            }
            else
            {
                if (n <= 0)
                {
                    kapacitetError_tb.Visibility = Visibility.Visible;
                    kapacitetError_tb.Text = "Broj mora biti veci od nule.";
                    kapacitet_Error = true;
                }
                else
                {
                    kapacitetError_tb.Visibility = Visibility.Hidden;
                    kapacitet_Error = false;
                }
            }
        }
    }
}
