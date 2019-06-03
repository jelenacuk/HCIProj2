using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.IO;


namespace HCIProj2
{
    public class Lokal
    {
        private string id;
        public string Id {
            get { return id; }
            set {
                if (value != id)
                {
                    id = value;
                    OnPropertyChanged("Id");
                }
            }
        }

        private string naziv;
        public string Naziv {
            get { return naziv; }
            set {
                if (value != naziv)
                {
                    naziv = value;
                    OnPropertyChanged("Naziv");
                }
            }
        }

        private string opis;
        public string Opis {
            get { return opis; }
            set {
                if (value != opis)
                {
                    opis = value;
                    OnPropertyChanged("Opis");
                }
            }
        }

        private String datumOtvaranja;
        public String DatumOtvaranja {
            get { return datumOtvaranja; }
            set {
                if (value != datumOtvaranja)
                {
                    datumOtvaranja = value;
                    OnPropertyChanged("DatumOtvaranja");
                }
            }
        }

        private string dozvoljenoPusenje;
        public string DozvoljenoPusenje {
            get { return dozvoljenoPusenje; }
            set {
                if (value != dozvoljenoPusenje)
                {
                    dozvoljenoPusenje = value;
                    OnPropertyChanged("DozvoljenoPusenje");
                }
            }
        }

        private int kapacitet;
        public int Kapacitet {
            get { return kapacitet; }
            set {
                if (value != kapacitet)
                {
                    kapacitet = value;
                    OnPropertyChanged("Kapacitet");
                }
            }
        }

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

        private string dostupanHendikepiranim;
        public string DostupanHendikepiranim {
            get { return dostupanHendikepiranim; }
            set {
                if (value != dostupanHendikepiranim)
                {
                    dostupanHendikepiranim = value;
                    OnPropertyChanged("DostupanHendikepiranim");
                }
            }
        }

        private string sluziAlkohol;
        public string SluziAlkohol {
            get { return sluziAlkohol; }
            set {
                if (value != sluziAlkohol)
                {
                    sluziAlkohol = value;
                    OnPropertyChanged("SluziAlkohol");
                }
            }
        }

        private string cenovnaKategorija;
        public string CenovnaKategorija {
            get { return cenovnaKategorija; }
            set {
                if (value != cenovnaKategorija)
                {
                    cenovnaKategorija = value;
                    OnPropertyChanged("CenovnaKategorija");
                }
            }
        }

        private ObservableCollection<Etiketa> etikete;
        public ObservableCollection<Etiketa> Etikete {
            get { return etikete; }
            set {
                if (value != etikete)
                {
                    etikete = value;
                    OnPropertyChanged("Etikete");
                }
            }
        }

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

        private string ikonica;
        public string Ikonica {
            get { return ikonica; }
            set {
                if (value != ikonica)
                {
                    ikonica = value;
                    OnPropertyChanged("Ikonica");
                }
            }
        }

        private int x;
        public int X {
            get { return x; }
            set {
                if (value != x)
                {
                    x = value;
                    OnPropertyChanged("X");
                }
            }
        }

        private int y;
        public int Y {
            get { return y; }
            set {
                if (value != y)
                {
                    y = value;
                    OnPropertyChanged("Y");
                }
            }
        }

        private bool visible;
        public bool Visible
        {
            get { return visible; }
            set
            {
                if (value != visible)
                {
                    visible = value;
                    OnPropertyChanged("Visible");
                }
            }
        }

        public Lokal()
        {
            Etikete = new ObservableCollection<Etiketa>();
            Visible = true;
        }

        public Lokal(string id, string naziv, string opis, String datumOtvaranja, string dozvoljenoPusenje, int kapacitet, string primaRezervacije, string dostupanHendikepiranim, string sluziAlkohol, string cenovnaKategorija, ObservableCollection<Etiketa> etikete, Tip tip, string ikonica)
        {
            Id = id;
            Naziv = naziv;
            Opis = opis;
            DatumOtvaranja = datumOtvaranja;
            DozvoljenoPusenje = dozvoljenoPusenje;
            Kapacitet = kapacitet;
            PrimaRezervacije = primaRezervacije;
            DostupanHendikepiranim = dostupanHendikepiranim;
            SluziAlkohol = sluziAlkohol;
            CenovnaKategorija = cenovnaKategorija;
            Etikete = etikete;
            Tip = tip;
            Ikonica = ikonica;
            Visible = true;
        }
        public Lokal(Lokal l)
        {
            Id = l.Id;
            Naziv = l.Naziv;
            Opis = l.Opis;
            DatumOtvaranja = l.DatumOtvaranja;
            DozvoljenoPusenje = l.DozvoljenoPusenje;
            Kapacitet = l.Kapacitet;
            PrimaRezervacije = l.PrimaRezervacije;
            DostupanHendikepiranim = l.DostupanHendikepiranim;
            SluziAlkohol = l.SluziAlkohol;
            CenovnaKategorija = l.CenovnaKategorija;
            Etikete = l.Etikete;
            Tip = l.Tip;
            Ikonica = l.Ikonica;
            Visible = true;
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
