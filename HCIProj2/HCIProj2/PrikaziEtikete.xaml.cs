
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
    /// Interaction logic for PrikaziEtikete.xaml
    /// </summary>
    public partial class PrikaziEtikete : Window, INotifyPropertyChanged
    {

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

        public Etiketa SelektovanaEtiketa { get; set; }
        public PrikaziEtikete()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;

            SelektovanaEtiketa = null;
            DataContext = this;
            Etikete = Podaci.getInstance().Etikete;
        }

        private void buttonPretraziClick(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBoxIdEtikete.Text))
            {
                var pronadjene= new ObservableCollection<Etiketa>();

                foreach (var data in Podaci.getInstance().Etikete)
                {
                    if (data.Id.Contains(textBoxIdEtikete.Text))
                    {
                        pronadjene.Add(new Etiketa(data));
                    }
                }
                Etikete = pronadjene;
            }
        }

        private void buttonPonistiClick(object sender, RoutedEventArgs e)
        {
            Etikete = Podaci.getInstance().Etikete;
            textBoxIdEtikete.Text = "";
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
    }
}
