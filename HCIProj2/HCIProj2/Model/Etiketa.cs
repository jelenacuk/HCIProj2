using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace HCIProj2
{
    public class Etiketa
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
        private string boja;
        public string Boja {
            get { return boja; }
            set {
                if (value != boja)
                {
                    boja = value;
                    OnPropertyChanged("Boja");
                }
            }
        }

        public Etiketa()
        {
        }

        public Etiketa(string id, string opis, string boja)
        {
            Id = id;
            Opis = opis;
            Boja = boja;
        }

        public Etiketa(Etiketa etiketa)
        {
            Id = etiketa.Id;
            Opis = etiketa.Opis;
            Boja = etiketa.Boja;
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
