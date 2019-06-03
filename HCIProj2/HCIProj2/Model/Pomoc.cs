using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HCIProj2
{
    class Pomoc
    {
        public static readonly DependencyProperty HelpKeyProperty = DependencyProperty.RegisterAttached("HelpKey", typeof(string), typeof(Pomoc), 
            new PropertyMetadata("MainWindow", HelpKey));

        public static void ShowHelp(string key, Window originator)
        {
            PrikaziPomoc help = new PrikaziPomoc(key, originator);
            help.Show();
        }
        private static void HelpKey(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {

        }

        public static string GetHelpKey(DependencyObject obj)
        {
            return obj.GetValue(HelpKeyProperty) as string;
        }

        public static void SetHelpKey(DependencyObject obj, string value)
        {
            obj.SetValue(HelpKeyProperty, value);
        }
    }
   
}
