using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Xml.Serialization;
using System.IO;

namespace HCIProj2
{
    public class Podaci : INotifyPropertyChanged
    {

        private static Podaci instance = null;
        private string grad;
        private ObservableCollection<Lokal> lokali;
        public ObservableCollection<Lokal> Lokali {
            get { return lokali; }
            set {
                if (value != lokali)
                {
                    lokali = value;
                    OnPropertyChanged("Lokali");
                }
            }
        }
        private ObservableCollection<Lokal> lokaliNaMapi;
        public ObservableCollection<Lokal> LokaliNaMapi {
            get { return lokaliNaMapi; }
            set {
                if (value != lokaliNaMapi)
                {
                    lokaliNaMapi = value;
                    OnPropertyChanged("LokaliNaMapi");
                }
            }
        }
        private ObservableCollection<Tip> tipovi;
        public ObservableCollection<Tip> Tipovi {
            get { return tipovi; }
            set {
                if (value != tipovi)
                {
                    tipovi = value;
                    OnPropertyChanged("Tipovi");
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

        public static void dodajTip(Tip tip)
        {
            getInstance().tipovi.Add(tip);
        }

        public static void dodajEtiketu(Etiketa etiketa)
        {
            getInstance().etikete.Add(etiketa);
        }

        public static Etiketa getEtiketa(String id)
        {
            foreach (Etiketa etiketa in instance.Etikete)
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
            instance.Lokali.Add(lokal);
        }

        private Podaci()
        {
            lokali = new ObservableCollection<Lokal>();
            tipovi = new ObservableCollection<Tip>();
            etikete = new ObservableCollection<Etiketa>();
            lokaliNaMapi = new ObservableCollection<Lokal>();
        }

        public static Podaci getInstance(string grad)
        {
            if (instance != null)
            {
                if (instance.grad != grad)
                {
                    instance = new Podaci();
                    instance.grad = grad;
                    String fileName = "./" + grad + "_lokali" + ".xml";
                    if (File.Exists(fileName) == false)
                    {
                        FileStream fs = File.Create(fileName);
                        return instance;
                    }
                    using (var stream = new FileStream(fileName, FileMode.OpenOrCreate))
                    {
                        XmlSerializer XML = new XmlSerializer(typeof(ObservableCollection<Lokal>));
                        try
                        {
                            var lokali = (ObservableCollection < Lokal >)XML.Deserialize(stream);
                            if (lokali != null)
                            {
                                instance.Lokali = lokali;
                            }
                        }
                        catch
                        {
                            return new Podaci();
                        }

                    }

                    fileName = "./" + grad + "_lokali_na_mapi" + ".xml";
                    if (File.Exists(fileName) == false)
                    {
                        FileStream fs = File.Create(fileName);
                        return instance;
                    }
                    using (var stream = new FileStream(fileName, FileMode.OpenOrCreate))
                    {
                        XmlSerializer XML = new XmlSerializer(typeof(ObservableCollection<Lokal>));
                        try
                        {
                            var lokali = (ObservableCollection<Lokal>)XML.Deserialize(stream);
                            if (lokali != null)
                            {
                                instance.LokaliNaMapi = lokali;
                            }
                        }
                        catch
                        {
                            return new Podaci();
                        }

                    }

                    fileName = "./" +  "_tipovi" + ".xml";
                    if (File.Exists(fileName) == false)
                    {
                        FileStream fs = File.Create(fileName);
                        return instance;
                    }
                    using (var stream = new FileStream(fileName, FileMode.OpenOrCreate))
                    {
                        XmlSerializer XML = new XmlSerializer(typeof(ObservableCollection<Tip>));
                        try
                        {
                            var tipovi = (ObservableCollection<Tip>)XML.Deserialize(stream);
                            if (tipovi != null)
                            {
                                instance.Tipovi = tipovi;
                               
                            }
                        }
                        catch
                        {
                            return new Podaci();
                        }

                    }

                    fileName = "./" +  "_etikete" + ".xml";
                    if (File.Exists(fileName) == false)
                    {
                        FileStream fs = File.Create(fileName);
                        return instance;
                    }
                    using (var stream = new FileStream(fileName, FileMode.OpenOrCreate))
                    {
                        XmlSerializer XML = new XmlSerializer(typeof(ObservableCollection<Etiketa>));
                        try
                        {
                            var etikete = (ObservableCollection<Etiketa>)XML.Deserialize(stream);
                            if (etikete != null)
                            {
                                instance.Etikete = etikete;
                            }
                        }
                        catch
                        {
                            return new Podaci();
                        }

                    }
                }

            }
            if (instance == null)
            {
                instance = new Podaci();
                instance.grad = grad;
                String fileName = "./" + grad + "_lokali" + ".xml";
                if (File.Exists(fileName) == false)
                {
                    FileStream fs = File.Create(fileName);
                    return instance;
                }
                using (var stream = new FileStream(fileName, FileMode.OpenOrCreate))
                {
                    XmlSerializer XML = new XmlSerializer(typeof(ObservableCollection<Lokal>));
                    try
                    {
                        var lokali = (ObservableCollection<Lokal>)XML.Deserialize(stream);
                        if (lokali != null)
                        {
                            instance.Lokali = lokali;
                        }
                    }
                    catch
                    {
                        return new Podaci();
                    }

                }

                fileName = "./" + grad + "_lokali_na_mapi" + ".xml";
                if (File.Exists(fileName) == false)
                {
                    FileStream fs = File.Create(fileName);
                    return instance;
                }
                using (var stream = new FileStream(fileName, FileMode.OpenOrCreate))
                {
                    XmlSerializer XML = new XmlSerializer(typeof(ObservableCollection<Lokal>));
                    try
                    {
                        var lokali = (ObservableCollection<Lokal>)XML.Deserialize(stream);
                        if (lokali != null)
                        {
                            instance.LokaliNaMapi = lokali;
                        }
                    }
                    catch
                    {
                        return new Podaci();
                    }

                }

                fileName = "./" +  "_tipovi" + ".xml";
                if (File.Exists(fileName) == false)
                {
                    FileStream fs = File.Create(fileName);
                    return instance;
                }
                using (var stream = new FileStream(fileName, FileMode.OpenOrCreate))
                {
                    XmlSerializer XML = new XmlSerializer(typeof(ObservableCollection<Tip>));
                    try
                    {
                        var tipovi = (ObservableCollection<Tip>)XML.Deserialize(stream);
                        if (tipovi != null)
                        {
                            instance.Tipovi = tipovi;
                        }
                    }
                    catch
                    {
                        return new Podaci();
                    }

                }

                fileName = "./" + "_etikete" + ".xml";
                if (File.Exists(fileName) == false)
                {
                    FileStream fs = File.Create(fileName);
                    return instance;
                }
                using (var stream = new FileStream(fileName, FileMode.OpenOrCreate))
                {
                    XmlSerializer XML = new XmlSerializer(typeof(ObservableCollection<Etiketa>));
                    try
                    {
                        var lokali = (ObservableCollection<Etiketa>)XML.Deserialize(stream);
                        if (lokali != null)
                        {
                            instance.Etikete = lokali;
                        }
                    }
                    catch
                    {
                        return new Podaci();
                    }

                }
            }
            return instance;

        }

        public static Podaci getInstance()
        {
            return instance;
        }

        public static void SacuvajPodatke(string grad)
        {
            String fileName = "./" + grad + "_lokali" + ".xml";
            using (var stream = new FileStream(fileName, FileMode.Create))
            {
                XmlSerializer XML = new XmlSerializer(typeof(ObservableCollection<Lokal>));
                XML.Serialize(stream, instance.Lokali);
            }
            fileName = "./" + grad + "_lokali_na_mapi" + ".xml";
            using (var stream = new FileStream(fileName, FileMode.Create))
            {
                XmlSerializer XML = new XmlSerializer(typeof(ObservableCollection<Lokal>));
                XML.Serialize(stream, instance.LokaliNaMapi);
            }
            fileName = "./" + "_tipovi" + ".xml";
            using (var stream = new FileStream(fileName, FileMode.Create))
            {
                XmlSerializer XML = new XmlSerializer(typeof(ObservableCollection<Tip>));
                XML.Serialize(stream, instance.Tipovi);
            }
            fileName = "./" + "_etikete" + ".xml";
            using (var stream = new FileStream(fileName, FileMode.Create))
            {
                XmlSerializer XML = new XmlSerializer(typeof(ObservableCollection<Etiketa>));
                XML.Serialize(stream, instance.Etikete);
            }
        }
        public static Podaci JustGiveMeInstance()
        {
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
