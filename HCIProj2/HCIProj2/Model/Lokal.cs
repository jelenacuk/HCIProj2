using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCIProj2.Model
{
    class Lokal
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Opis { get; set; }
        public DateTime DatumOtvaranja { get; set; }
        public string DozvoljenoPusenje { get; set; }
        public int Kapacitet { get; set; }
        public string PrimaRezervacije { get; set; }
        public string DostupanHendikepiranim { get; set; }
        public string SluziAlkohol { get; set; }
        public string CenovnaKategorija { get; set; }
        public IObservable<Etiketa> Etikete { get; set; }
        public Tip Tip { get; set; }
    }
}
