﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;


namespace HCIProj2.Model
{
    class Tip
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
            get {
                return opis;
            }
            set {
                if (value != opis)
                {
                    opis = value;
                    OnPropertyChanged("Opis");
                }
            }
        }
        private string ikonica;
        public string Ikonica {
            get {
                return ikonica;
            }
            set {
                if (value != ikonica)
                {
                    ikonica = value;
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