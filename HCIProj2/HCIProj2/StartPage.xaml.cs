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

namespace HCIProj2
{
    /// <summary>
    /// Interaction logic for StartPage.xaml
    /// </summary>
    public partial class StartPage : Window
    {
        public StartPage()
        {
            InitializeComponent();
        }

        private void NoviSad_Click(object sender, RoutedEventArgs e)
        {
            if (Podaci.JustGiveMeInstance() != null)
            {
                while (Podaci.JustGiveMeInstance().doneWritingEt == false || Podaci.JustGiveMeInstance().doneWrittingTip == false)
                {

                }
            }
            
            MainWindow mw = new MainWindow("novisad");
            mw.Show();
            Close();
        }

        private void Beograd_Click(object sender, RoutedEventArgs e)
        {
            if (Podaci.JustGiveMeInstance() != null)
            {
                while (Podaci.JustGiveMeInstance().doneWritingEt == false || Podaci.JustGiveMeInstance().doneWrittingTip == false)
                {

                }
            }
            MainWindow mw = new MainWindow("beograd");
            mw.Show();
            Close();
        }

        private void Nis_Click(object sender, RoutedEventArgs e)
        {
            if (Podaci.JustGiveMeInstance() != null)
            {
                while (Podaci.JustGiveMeInstance().doneWritingEt == false || Podaci.JustGiveMeInstance().doneWrittingTip == false)
                {

                }
            }
            MainWindow mw = new MainWindow("nis");
            mw.Show();
            Close();
        }

        private void Zrenjanin_Click(object sender, RoutedEventArgs e)
        {
            if (Podaci.JustGiveMeInstance() != null)
            {
                while (Podaci.JustGiveMeInstance().doneWritingEt == false || Podaci.JustGiveMeInstance().doneWrittingTip == false)
                {

                }
            }
            MainWindow mw = new MainWindow("zrenjanin");
            mw.Show();
            Close();
        }

        private void Help_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            while (Podaci.JustGiveMeInstance().doneWritingEt == false || Podaci.JustGiveMeInstance().doneWrittingTip == false)
            {

            }
            PrikaziPomoc pomoc = new PrikaziPomoc("index", this);
            pomoc.Show();
        }
    }
}
