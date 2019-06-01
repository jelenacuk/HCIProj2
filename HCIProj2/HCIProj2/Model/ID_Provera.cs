using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace HCIProj2
{
    public class ID_Provera : ValidationRule
    {
        public String klasa { get; set; }

        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            try
            {
                String id = value as string;
                if (string.IsNullOrWhiteSpace(id))
                {
                    return new ValidationResult(false, "Id: ne može se sastojati samo iz razmaka");
                }
                if (id.Any(ch => char.IsPunctuation(ch)))
                {
                    return new ValidationResult(false, "Id: znakovi interpunkcije nisu dozvoljeni.");
                }
                else
                {
                    if (klasa.Equals("etiketa"))
                    {
                        foreach (Etiketa etiketa in Podaci.getInstance().Etikete)
                        {
                            if (etiketa.Id.Equals(id))
                            {
                                return new ValidationResult(false, "Id mora biti jedinstven.");
                            }
                        }
                        return new ValidationResult(true, "");
                    }
                    else if (klasa.Equals("tip"))
                    {
                        foreach (Tip tip in Podaci.getInstance().Tipovi)
                        {
                            if (tip.Id.Equals(id))
                            {
                                return new ValidationResult(false, "Id mora biti jedinstven.");
                            }
                        }
                        return new ValidationResult(true, "");
                    }
                    else
                    {
                        foreach (Lokal lokal in Podaci.getInstance().Lokali)
                        {
                            if (lokal.Id.Equals(id))
                            {
                                return new ValidationResult(false, "Id mora biti jedinstven.");
                            }
                        }
                        return new ValidationResult(true, "");
                    }
                }
            }
            catch
            {
                return new ValidationResult(false, "Neočekivana greška.");
            }
        }
    }
}
