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
using System.ComponentModel;
using System.Collections.ObjectModel;
using Microsoft.Win32;


namespace HCIProj2
{
    /// <summary>
    /// Interaction logic for Detaljnije.xaml
    /// </summary>
    public partial class Detaljnije : Window, INotifyPropertyChanged
    {
        private string primaRezervacije;
        public string PrimaRezervacije {
            get { return primaRezervacije; }
            set {
                if (value != primaRezervacije)
                {
                    primaRezervacije = value;
                    OnPropertyChanged("PrimaRezervacije");
                }
            }
        }
        private string hendikepirani;
        private string pusenje;
        private string alkohol;
        private string cena;


        private bool id_Eror;
        private bool opis_Error;
        private bool ikonica_Error;
        private bool naziv_Error;
        private bool datum_Error;

        private int selectedRez;
        public int SelectedRez {
            get { return selectedRez; }
            set {
                if (value != selectedRez)
                {
                    selectedRez = value;
                    OnPropertyChanged("selectedRez");
                }
            }
        }
        private int selectedCena;
        public int SelectedCena {
            get { return selectedCena; }
            set {
                if (value != selectedCena)
                {
                    selectedCena = value;
                    OnPropertyChanged("SelectedCena");
                }
            }
        }

        private ObservableCollection<Etiketa> izabraneEtikete;
        public ObservableCollection<Etiketa> IzabraneEtikete {
            get { return izabraneEtikete; }
            set {
                if (value != izabraneEtikete)
                {
                    izabraneEtikete = value;
                    OnPropertyChanged("IzabraneEtikete");
                }
            }
        }

        private int selectedHen;
        public int SelectedHen {
            get { return selectedHen; }
            set {
                if (value != selectedHen)
                {
                    selectedHen = value;
                    OnPropertyChanged("SelectedHen");
                }
            }
        }
        private int selectedAlk;
        public int SelectedAlk {
            get { return selectedAlk; }
            set {
                if (value != selectedAlk)
                {
                    selectedAlk = value;
                    OnPropertyChanged("SelectedAlk");
                }
            }
        }
        private int selectedPus;
        public int SelectedPus {
            get { return selectedPus; }
            set {
                if (value != selectedPus)
                {
                    selectedPus = value;
                    OnPropertyChanged("SelectedPus");
                }
            }
        }
        private Lokal lokalOrig;
        public Lokal LokalOrig {
            get { return lokalOrig; }
            set {
                if (value != lokalOrig)
                {
                    lokalOrig = value;
                    OnPropertyChanged("LokalOrig");
                }
            }
        }

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
        public Detaljnije()
        {
            InitializeComponent();
        }
        public Detaljnije(Lokal l)
        {
            InitializeComponent();
            this.DataContext = this;
            LokalOrig = l;
            lokal = new Lokal(lokalOrig);
            SelectedCena = -1;
            izabraneEtikete = l.Etikete;
            id_Eror = false;
            opis_Error = false;
            naziv_Error = false;
            ikonica_Error = false;
            datum_Error = false;
            if (lokal.PrimaRezervacije == "DA")
            {
                SelectedRez = 0;
            }
            else
            {
                SelectedRez = 1;
            }
            if (lokal.DostupanHendikepiranim == "DA")
            {
                SelectedHen = 0;
            }
            else if (lokal.DostupanHendikepiranim == "NE")
            {
                SelectedHen = 1;
            }
            if (lokal.DozvoljenoPusenje == "Dozvoljeno")
            {
                SelectedPus = 0;
            }
            else if (lokal.DozvoljenoPusenje == "Zabranjeno")
            {
                SelectedPus = 1;
            }
            if (lokal.SluziAlkohol == "Ne služi")
            {
                SelectedAlk = 0;
            }
            else if (lokal.SluziAlkohol == "Služi do 23h")
            {
                SelectedAlk = 1;
            }
            else if (lokal.SluziAlkohol == "Služi i kasno noću")
            {
                SelectedAlk = 2;
            }
            if (lokal.CenovnaKategorija == "Niska")
            {
                SelectedCena = 0;
            }
            else if (lokal.CenovnaKategorija == "Srednja")
            {
                SelectedCena = 1;
            }
            else if (lokal.CenovnaKategorija == "Visoka")
            {
                SelectedCena = 2;
            }
            else if (lokal.CenovnaKategorija == "Izuzetno visoka")
            {
                SelectedCena = 3;
            }
        }
        private void ListBoxItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }
        private void ListViewScrollViewer_PreviewMouseWheel(object sender, System.Windows.Input.MouseWheelEventArgs e)
        {
            ScrollViewer scv = (ScrollViewer)sender;
            scv.ScrollToVerticalOffset(scv.VerticalOffset - e.Delta);
            e.Handled = true;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }


        //Event se poziva pri svakoj promeni combobox-a prima rezervacije
        private void Rezervacije_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            TextBlock tb = (TextBlock)cb.SelectedValue;
            PrimaRezervacije = tb.Text;
            rezervacijeError_tb.Visibility = Visibility.Hidden;
        }

        private void Hendikepirani_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            TextBlock tb = (TextBlock)cb.SelectedValue;
            hendikepirani = tb.Text;
            hendikepiraniError_tb.Visibility = Visibility.Hidden;
        }

        private void Pušenje_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            TextBlock tb = (TextBlock)cb.SelectedValue;
            pusenje = tb.Text;
            pusenjeError_tb.Visibility = Visibility.Hidden;
        }

        private void Alkohol_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            TextBlock tb = (TextBlock)cb.SelectedValue;
            alkohol = tb.Text;
            alkoholError_tb.Visibility = Visibility.Hidden;

        }

        private void Cena_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            TextBlock tb = (TextBlock)cb.SelectedValue;
            cena = tb.Text;
            rezervacijeError_tb.Visibility = Visibility.Hidden;
        }

        private void Sacuvaj_Click(object sender, RoutedEventArgs e)
        {
            if (id_Eror == false && opis_Error == false && naziv_Error == false && ikonica_Error == false && datum_Error == false)
            {
                LokalOrig.CenovnaKategorija = cena;
                LokalOrig.DostupanHendikepiranim = hendikepirani;
                LokalOrig.DozvoljenoPusenje = pusenje;
                LokalOrig.Opis = lokal.Opis;
                LokalOrig.Naziv = lokal.Naziv;
                LokalOrig.Kapacitet = lokal.Kapacitet;
                LokalOrig.DatumOtvaranja = lokal.DatumOtvaranja;
                LokalOrig.Id = lokal.Id;
            }
            if (combo_cene.SelectedItem == null)
            {
                ceneError_tb.Visibility = Visibility.Visible;
            }
            if ((combo_rezervacije.SelectedItem == null))
            {
                rezervacijeError_tb.Visibility = Visibility.Visible;
            }
            if ((combo_pusenje.SelectedItem == null))
            {
                pusenjeError_tb.Visibility = Visibility.Visible;
            }
            if ((combo_hendikepirani.SelectedItem == null))
            {
                hendikepiraniError_tb.Visibility = Visibility.Visible;
            }
            if ((combo_alkohol.SelectedItem == null))
            {
                alkoholError_tb.Visibility = Visibility.Visible;
            }
            if ((combo_tipovi.SelectedItem == null))
            {
                tipoviError_tb.Visibility = Visibility.Visible;
            }

        }

        private void TextB_id_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (textB_id.Text.Length > 0)
                Sacuvaj.IsEnabled = true;
            else
                Sacuvaj.IsEnabled = false;
        }

        private void TextB_id_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
                id_Eror = true;
        }

        private void TextB_naziv_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
                naziv_Error = true;
        }

        private void TextB_opis_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
                opis_Error = true;
        }

        private void TextB_datum_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
                datum_Error = true;
        }

        private void TextB_ikonica_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
                ikonica_Error = true;
        }

        private void LoadIcon_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files (*.png;*.jpg,*.ico)|*.ico;*.png;*.jpg";
            if (dialog.ShowDialog() == true)
            {
                textB_ikonica.Text = dialog.FileName;
            }
        }

        private void AutoCompleteBoxTags_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                DodajEtiketuBtn_Click(null, null);
            }
        }

        private void DodajEtiketuBtn_Click(object sender, RoutedEventArgs e)
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

        private void Combo_tipovi_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            tipoviError_tb.Visibility = Visibility.Hidden;
        }

        private void Combo_tipovi_Loaded(object sender, RoutedEventArgs e)
        {
            var combo = sender as ComboBox;
            combo.ItemsSource = Podaci.getInstance().Tipovi;
            combo.DisplayMemberPath = "Naziv";
        }

        private void NoviTip_Click(object sender, RoutedEventArgs e)
        {
            dodajTip noviTip = new dodajTip();
            noviTip.Show();
        }


        private void Brisanje_Click(object sender, RoutedEventArgs e)
        {
            Podaci.getInstance().Lokali.Remove(LokalOrig);
            Podaci.getInstance().LokaliNaMapi.Remove(LokalOrig);
            MainWindow.instance.LokaliPins_Draw();
            Close();

        }

        private void Izlaz_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void Help_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            PrikaziPomoc pomoc = new PrikaziPomoc("Lokal", this);
            pomoc.Show();
        }
    }
}
