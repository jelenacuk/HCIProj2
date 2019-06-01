using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;


namespace HCIProj2
{
    class Datum_Provera : ValidationRule
    {

        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            try
            {
                var datum = value as string;
               
                string format = "MM/dd/yyyy HH:mm";
                try
                {
                    
                    DateTime.ParseExact(datum, format, System.Globalization.CultureInfo.InvariantCulture);
                    return new ValidationResult(true, "");
                }
                catch
                {
                    return new ValidationResult(false, "Format datuma: MM/dd/yyyy HH:mm");
                }


            }
            catch
            {
                return new ValidationResult(false, "Format datuma: MM/dd/yyyy HH:mm");
            }
          
        }
    }
}
