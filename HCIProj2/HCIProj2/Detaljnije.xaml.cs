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
            else if(lokal.DostupanHendikepiranim == "NE")
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
        }

        private void Hendikepirani_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            TextBlock tb = (TextBlock)cb.SelectedValue;
            hendikepirani = tb.Text;
        }

        private void Pušenje_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            TextBlock tb = (TextBlock)cb.SelectedValue;
            pusenje = tb.Text;
        }

        private void Alkohol_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            TextBlock tb = (TextBlock)cb.SelectedValue;
            alkohol = tb.Text;
        }

        private void Cena_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            TextBlock tb = (TextBlock)cb.SelectedValue;
            cena = tb.Text;
        }

        private void Sacuvaj_Click(object sender, RoutedEventArgs e)
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
    }
}
