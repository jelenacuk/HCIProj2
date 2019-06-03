
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
    /// Interaction logic for PrikaziTipove.xaml
    /// </summary>
    public partial class PrikaziTipove : Window, INotifyPropertyChanged
    {
        
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

        private void buttonPretraziClick(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBoxIdTipa.Text))
            {
                var pronadjene = new ObservableCollection<Tip>();

                foreach (var data in Podaci.getInstance().Tipovi)
                {
                    if (data.Id.Contains(textBoxIdTipa.Text))
                    {
                        pronadjene.Add(new Tip(data));
                    }
                }
                Tipovi = pronadjene;
            } else
            {
                if(!string.IsNullOrWhiteSpace(textBoxNazivTipa.Text))
                {
                    var pronadjene = new ObservableCollection<Tip>();

                    foreach (var data in Podaci.getInstance().Tipovi)
                    {
                        if (data.Naziv.Contains(textBoxNazivTipa.Text))
                        {
                            pronadjene.Add(new Tip(data));
                        }
                    }
                    Tipovi = pronadjene;
                }
            }
        }

        private void buttonPonistiClick(object sender, RoutedEventArgs e)
        {
            Tipovi = Podaci.getInstance().Tipovi;
            textBoxIdTipa.Text = "";
            textBoxNazivTipa.Text = "";
        }

        public Etiketa SelektovanTip { get; set; }
        public PrikaziTipove()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;

            SelektovanTip = null;
            DataContext = this;
            Tipovi = Podaci.getInstance().Tipovi;
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
            PrikaziPomoc pomoc = new PrikaziPomoc("Tip", this);
            pomoc.Show();
        }

        private void TypesGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Tip t = typesGrid.SelectedItem as Tip;
            izmenaTipa iz = new izmenaTipa(t);
            iz.Show();
        }
    }
}
