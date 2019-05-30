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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HCIProj2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Mapa_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void Mapa_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void Mapa_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void Mapa_DragEnter(object sender, DragEventArgs e)
        {

        }

        private void Mapa_Drop(object sender, DragEventArgs e)
        {

        }

        private void ListView_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void ListView_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(this.ListaLokala.Visibility == Visibility.Hidden)
            {
                this.ListaLokala.Visibility = Visibility.Visible;
                ((MenuItem)sender).Header = "Sakrij Lokale";
            }
            else
            {
                this.ListaLokala.Visibility = Visibility.Hidden;
                ((MenuItem)sender).Header = "Izlistaj lokale";
            }

        }
    }
}
