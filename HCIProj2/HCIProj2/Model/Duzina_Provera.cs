using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace HCIProj2
{
    public class Duzina_Provera : ValidationRule
    {

        public String polje { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }

        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            try
            {
                if (value != null)
                {
                    var text = value as string;
                    if (text.Length < Min)
                    {
                        return new ValidationResult(false, polje + ": minimum " + Min + " karaktera");
                    }
                    else if (text.Length > Max)
                    {
                        return new ValidationResult(false, polje + ": maksimum " + Max + " karaktera");
                    }
                    if (text.Length == 0 || text == null)
                    {
                        return new ValidationResult(false, "Popunjavanje polja '" + polje + "'  je obavezno");
                    }
                    return new ValidationResult(true, null);
                }
                else if (Min == 0)
                {
                    return new ValidationResult(true, null);
                }
                else
                {
                    return new ValidationResult(false, "Popunjavanje polja '" + polje + "' je obavezno");
                }
            }
            catch
            {
                return new ValidationResult(false, "Neočekivana greška.");
            }
        }
    }
}
