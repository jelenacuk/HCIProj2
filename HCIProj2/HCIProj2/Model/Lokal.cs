using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.IO;


namespace HCIProj2.Model
{
    class Lokal
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

        private string name;
        public string Name {
            get { return name; }
            set {
                if (value != name)
                {
                    name = value;
                    OnPropertyChanged("Name");
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

        private DateTime datumOtvaranja;
        public DateTime DatumOtvaranja {
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
                    string newPath = Directory.GetCurrentDirectory() + "\\" + @ikonica.Split('\\').Last();
                    if (!File.Exists(newPath) && newPath != null && !string.IsNullOrEmpty(newPath) && !string.IsNullOrWhiteSpace(newPath))
                    {
                        File.Copy(@ikonica, @newPath, true);
                    }
                    ikonica = newPath;
                    OnPropertyChanged("Ikonica");
                }
            }
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
