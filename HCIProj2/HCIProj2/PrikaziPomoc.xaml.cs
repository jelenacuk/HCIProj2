using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;

namespace HCIProj2
{
    /// <summary>
    /// Interaction logic for PrikaziPomoc.xaml
    /// </summary>
    public partial class PrikaziPomoc : Window
    {
        public PrikaziPomoc(string key, Window originator)
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;

            string path = string.Format("{0}\\Html\\{1}.html", Directory.GetCurrentDirectory(), key);

            if (!File.Exists(path))
                key = "Error";

            Uri url = new Uri(string.Format("file:///{0}\\Html\\{1}.html", Directory.GetCurrentDirectory(), key));

            PrikazPomoci.Navigate(url);
        }
    }
}
