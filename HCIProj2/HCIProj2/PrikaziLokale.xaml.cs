
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    /// Interaction logic for PrikaziLokale.xaml
    /// </summary>
    public partial class PrikaziLokale : Window, INotifyPropertyChanged
    {
        private ObservableCollection<Lokal> lokali;
        public ObservableCollection<Lokal> Lokali
        {
            get { return lokali; }
            set
            {
                if (value != lokali)
                {
                    lokali = value;
                    OnPropertyChanged("Lokali");
                }
            }
        }

        private ObservableCollection<Etiketa> etikete;
        public ObservableCollection<Etiketa> Etikete
        {
            get { return etikete; }
            set
            {
                if (value != etikete)
                {
                    etikete = value;
                    OnPropertyChanged("Etikete");
                }
            }
        }

        private ObservableCollection<Tip> tipovi;
        public ObservableCollection<Tip> Tipovi
        {
            get { return tipovi; }
            set
            {
                if (value != tipovi)
                {
                    tipovi = value;
                    OnPropertyChanged("Tipovi");
                }
            }
        }

        public Tip selektovanTip { get; set; }
        public Etiketa selektovanaEtiketa { get; set; }
        public Lokal SelektovaniLokal { get; set; }

        public PrikaziLokale()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;

            selektovanTip = null;
            selektovanaEtiketa = null;
            SelektovaniLokal = null;
            DataContext = this;
            Lokali = Podaci.getInstance().Lokali;
            Etikete = Podaci.getInstance().Etikete;
            Tipovi = Podaci.getInstance().Tipovi;
        }

        private void buttonPretraziClick(object sender, RoutedEventArgs e)
        {
            var pronadjene1 = new ObservableCollection<Lokal>();
            var pronadjene2 = new ObservableCollection<Lokal>();
            Lokali = Podaci.getInstance().Lokali;
            pronadjene2 = Lokali;
            if (!string.IsNullOrWhiteSpace(textBoxIdLokala.Text))
            {


                foreach (var data in Podaci.getInstance().Lokali)
                {
                    if (data.Id.Contains(textBoxIdLokala.Text))
                    {
                        pronadjene1.Add(new Lokal(data));
                    }
                }
                Lokali = pronadjene1;
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(textBoxKapacitetOd.Text))
                {

                    foreach (var data in pronadjene2)
                    {
                        // Konvertuje string u int.
                        int i = 0;
                        if (!Int32.TryParse(textBoxKapacitetOd.Text, out i))
                        {
                            i = 0;
                        }

                        if (data.Kapacitet >= i)
                        {
                            pronadjene1.Add(new Lokal(data));
                        }
                    }
                    pronadjene2 = new ObservableCollection<Lokal>(pronadjene1);
                    pronadjene1.Clear();
                }

                if (!string.IsNullOrWhiteSpace(textBoxKapacitetDo.Text))
                {
                    foreach (var data in pronadjene2)
                    {
                        // Konvertuje string u int.
                        int i = 0;
                        if (!Int32.TryParse(textBoxKapacitetDo.Text, out i))
                        {
                            i = 0;
                        }

                        if (data.Kapacitet <= i)
                        {
                            pronadjene1.Add(new Lokal(data));
                        }
                    }
                    pronadjene2 = new ObservableCollection<Lokal>(pronadjene1);
                    pronadjene1.Clear();
                }
                if (!string.IsNullOrWhiteSpace(textBoxNazivLokala.Text))
                {
                    foreach (var data in pronadjene2)
                    {
                        if (data.Naziv.Contains(textBoxNazivLokala.Text))
                        {
                            pronadjene1.Add(new Lokal(data));
                        }
                    }
                    pronadjene2 = new ObservableCollection<Lokal>(pronadjene1);
                    pronadjene1.Clear();
                }
                if (!string.IsNullOrWhiteSpace(comboBoxRezervacija.Text))
                {
                    foreach (var data in pronadjene2)
                    {
                        if (data.PrimaRezervacije.Contains(comboBoxRezervacija.Text))
                        {
                            pronadjene1.Add(new Lokal(data));
                        }
                    }
                    pronadjene2 = new ObservableCollection<Lokal>(pronadjene1);
                    pronadjene1.Clear();
                }
                if (!string.IsNullOrWhiteSpace(comboBoxHendikep.Text))
                {
                    foreach (var data in pronadjene2)
                    {
                        if (data.DostupanHendikepiranim.Contains(comboBoxHendikep.Text))
                        {
                            pronadjene1.Add(new Lokal(data));
                        }
                    }
                    pronadjene2 = new ObservableCollection<Lokal>(pronadjene1);
                    pronadjene1.Clear();
                }
                if (!string.IsNullOrWhiteSpace(comboBoxPusenje.Text))
                {

                    foreach (var data in pronadjene2)
                    {
                        if (data.DozvoljenoPusenje.Contains(comboBoxPusenje.Text))
                        {
                            pronadjene1.Add(new Lokal(data));
                        }
                    }
                    pronadjene2 = new ObservableCollection<Lokal>(pronadjene1);
                    pronadjene1.Clear();
                }
                if (!string.IsNullOrWhiteSpace(comboBoxAlkohol.Text))
                {
                    foreach (var data in pronadjene2)
                    {
                        if (data.SluziAlkohol.Contains(comboBoxAlkohol.Text))
                        {
                            pronadjene1.Add(new Lokal(data));
                        }
                    }
                    pronadjene2 = new ObservableCollection<Lokal>(pronadjene1);
                    pronadjene1.Clear();
                }
                if (!string.IsNullOrWhiteSpace(comboBoxCene.Text))
                {
                    foreach (var data in pronadjene2)
                    {
                        if (data.CenovnaKategorija.Contains(comboBoxCene.Text))
                        {
                            pronadjene1.Add(new Lokal(data));
                        }
                    }
                    pronadjene2 = new ObservableCollection<Lokal>(pronadjene1);
                    pronadjene1.Clear();
                }
                if (!string.IsNullOrWhiteSpace(comboBoxEtikete.Text))
                {

                    foreach (var data in pronadjene2)
                    {
                        foreach (var data2 in data.Etikete)
                        {
                            if (data2.Id.Equals(comboBoxEtikete.Text))
                            {
                                pronadjene1.Add(new Lokal(data));
                            }
                        }

                    }
                    pronadjene2 = new ObservableCollection<Lokal>(pronadjene1);
                    pronadjene1.Clear();
                }
                if (!string.IsNullOrWhiteSpace(comboBoxTip.Text))
                {
                    foreach (var data in pronadjene2)
                    {
                        if (data.Tip.Naziv.Contains(comboBoxTip.Text))
                        {
                            pronadjene1.Add(new Lokal(data));
                        }
                    }
                    pronadjene2 = new ObservableCollection<Lokal>(pronadjene1);
                }
                Lokali = pronadjene2;
            }
        }

        private void buttonPonistiClick(object sender, RoutedEventArgs e)
        {
            textBoxIdLokala.Text = "";
            textBoxKapacitetOd.Text = "";
            textBoxKapacitetDo.Text = "";
            textBoxNazivLokala.Text = "";
            comboBoxRezervacija.Text = "";
            comboBoxHendikep.Text = "";
            comboBoxPusenje.Text = "";
            comboBoxAlkohol.Text = "";
            comboBoxCene.Text = "";
            comboBoxEtikete.Text = "";
            comboBoxTip.Text = "";
            Lokali = Podaci.getInstance().Lokali;

        }

        private void tableRightClick(object sender, RoutedEventArgs e)
        {
            Detaljnije detaljnijiPrikazLokala = new Detaljnije(this.SelektovaniLokal);
            detaljnijiPrikazLokala.Show();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
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
    }
}
