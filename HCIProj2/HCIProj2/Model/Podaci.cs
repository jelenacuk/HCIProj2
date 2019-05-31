using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace HCIProj2.Model
{
    public class Podaci : INotifyPropertyChanged
    {

        private static Podaci instance = null;

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

        public static void dodajTip( Tip tip)
        {
            getInstance().tipovi.Add(tip);
        }

        public static void dodajEtiketu(Etiketa etiketa)
        {
            getInstance().etikete.Add(etiketa);
        }

        public static Etiketa getEtiketa(String id)
        {
            foreach(Etiketa etiketa in Podaci.getInstance().Etikete)
            {
                if (etiketa.Id == id)
                {
                    return etiketa;
                }
            }
            return null;
        }

        public static void dodajLokal(Lokal lokal)
        {
            getInstance().lokali.Add(lokal);
        }

        private Podaci()
        {
            lokali = new ObservableCollection<Lokal>();
            tipovi = new ObservableCollection<Tip>();
            etikete = new ObservableCollection<Etiketa>();
        }

        public static Podaci getInstance()
        {
            if (instance == null)
            {
                instance = new Podaci();
            }
            return instance;
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
    }
}
