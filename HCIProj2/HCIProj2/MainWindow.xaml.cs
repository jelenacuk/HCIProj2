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
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.IO;
namespace HCIProj2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow instance;
        private string grad;
        private bool nazad;

        public MainWindow()
        {
            InitializeComponent();
            instance = this;
            this.DataContext = this;
            Lokali = Podaci.getInstance().Lokali;
            LokaliNaMapi = Podaci.getInstance().LokaliNaMapi;
            LokaliPins_Draw();
        }

        public MainWindow(string grad)
        {
            InitializeComponent();
            instance = this;
            this.DataContext = this;
            this.grad = grad;
            nazad = false;
            MapaPath = Directory.GetCurrentDirectory() + "\\Images\\" + grad+".png";
            Lokali = Podaci.getInstance(this.grad).Lokali;
            LokaliNaMapi = Podaci.getInstance(this.grad).LokaliNaMapi;
            LokaliPins_Draw();
            Nazad.IsEnabled = true;
        }

        
        private string mapaPath;
        public string MapaPath {
            get { return mapaPath; }
            set {
                if (value != mapaPath)
                {
                    mapaPath = value;
                    OnPropertyChanged("MapaPath");
                }
            }
        }
        private ObservableCollection<Lokal> lokali;
        private Lokal lokalSelektovanNaListi;
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
        private Lokal selektovanLokal;


        private void Mapa_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Point mousePosition = e.GetPosition(Mapa);
            selektovanLokal = Lokal_Click((int)mousePosition.X, (int)mousePosition.Y);
            if (e.ChangedButton == MouseButton.Left && e.ClickCount == 2)
            {
                if (selektovanLokal != null)
                {
                    Detaljnije detaljnije = new Detaljnije(selektovanLokal);
                    detaljnije.Show();
                }
            }
        }

        private void Mapa_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            Point mousePosition = e.GetPosition(Mapa);
            selektovanLokal = Lokal_Click((int)mousePosition.X, (int)mousePosition.Y);

            if (selektovanLokal != null)
            {
                var Map = sender as Canvas;
                Map.ContextMenu.IsOpen = true;
                Map.ContextMenu.Visibility = Visibility.Visible;

            }
            else
            {
                var Map = sender as Canvas;
                Map.ContextMenu.Visibility = Visibility.Hidden;
            }
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(this.ListaLokala.Visibility == Visibility.Hidden)
            {
                this.ListaLokala.Visibility = Visibility.Visible;
                Izlistaj.Header = "Sakrij Lokale";
            }
            else
            {
                this.ListaLokala.Visibility = Visibility.Hidden;
                Izlistaj.Header = "Izlistaj lokale";
            }

        }

        private void dodajLokal(object sender, RoutedEventArgs e)
        {
            DodajLokal dodaj = new DodajLokal();
            dodaj.Show();
        }

        private void dodajTip(object sender, RoutedEventArgs e)
        {
            dodajTip dodajTip = new dodajTip();
            dodajTip.Show();
        }

        private void dodajEtiketu(object sender, RoutedEventArgs e)
        {
            dodajEtiketu dodajEtiketu = new dodajEtiketu();
            dodajEtiketu.Show();
        }

        private void prikaziLokale(object sender, RoutedEventArgs e)
        {
            PrikaziLokale prikaziLokale = new PrikaziLokale();
            prikaziLokale.Show();
        }
        private void prikaziEtikete(object sender, RoutedEventArgs e)
        {
            PrikaziEtikete prikaziEtikete = new PrikaziEtikete();
            prikaziEtikete.Show();
        }
        private void prikaziTipove(object sender, RoutedEventArgs e)
        {
            PrikaziTipove prikaziTipove = new PrikaziTipove();
            prikaziTipove.Show();
        }


        Point startPoint = new Point();

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        private void Mapa_MouseMove(object sender, MouseEventArgs e)
        {
            Point mousePosition = e.GetPosition(Mapa);
            Vector diff = startPoint - mousePosition;

            if (e.LeftButton == MouseButtonState.Pressed &&
                (Math.Abs(diff.X) > SystemParameters.MinimumHorizontalDragDistance ||
                Math.Abs(diff.Y) > SystemParameters.MinimumVerticalDragDistance))
            {
                Lokal lokal = Lokal_Click((int)mousePosition.X, (int)mousePosition.Y);

                if (lokal != null)
                {
                    DataObject dragData = new DataObject("myFormat", lokal);
                    DragDrop.DoDragDrop(Mapa, dragData, DragDropEffects.Move);
                }
            }
        }

        private void Mapa_DragEnter(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent("myFormat") || sender == e.Source)
            {
                e.Effects = DragDropEffects.None;
            }
        }

        private void Mapa_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("myFormat"))
            {
                Point dropPosition = e.GetPosition(Mapa);
                Lokal lokalPin = e.Data.GetData("myFormat") as Lokal;


                if (lokalPin != null)
                {
                    lokalPin.X = (int)dropPosition.X - 8;
                    lokalPin.Y = (int)dropPosition.Y - 8;
                }
                // if it is close to the edge, move it a little bit
                else if ((int)dropPosition.Y > -30 && (int)dropPosition.Y < 10)
                {
                    lokalPin.X = (int)dropPosition.X - 16;
                    lokalPin.Y = (int)dropPosition.Y + 8;
                }
                else if ((int)dropPosition.X > -30 && (int)dropPosition.X < 10)
                {
                    lokalPin.X = (int)dropPosition.X + 8;
                    lokalPin.Y = (int)dropPosition.Y - 16;
                }
                else
                {
                    lokalPin.X = (int)dropPosition.X - 16;
                    lokalPin.Y = (int)dropPosition.Y - 16;
                }
                lokali.Remove(lokalPin);
                LokaliNaMapi.Add(lokalPin);
                LokaliPins_Draw();

            }
        }
        private Lokal Lokal_Click(int x, int y)
        {
            foreach (Lokal lokal in LokaliNaMapi)
            {
                if (lokal.X != -1 && lokal.Y != -1)
                {
                    if (Math.Sqrt(Math.Pow((x - lokal.X - 16), 2) + Math.Pow((y - lokal.Y - 16), 2)) < 20)
                    {
                        return lokal;
                    }
                }
            }
            return null;
        }

        public void LokaliPins_Draw()
        {
            Mapa.Children.RemoveRange(1, lokaliNaMapi.Count +1);
            foreach (Lokal lokal in lokaliNaMapi)
            {
                if (lokal.X != -1 && lokal.Y != -1)
                {
                    Image lokalIkonica = new Image();
                    lokalIkonica.Width = 32;
                    lokalIkonica.Height = 32;
                    lokalIkonica.ToolTip = lokal.Id + " " + lokal.Naziv;
                    if (File.Exists(lokal.Ikonica))
                    {
                        lokalIkonica.Source = new BitmapImage(new Uri(lokal.Ikonica, UriKind.RelativeOrAbsolute));
                    }
                    else
                    {
                        MessageBox.Show("Izabrana je nepostojeca ikonica");
                        break;
                    }

                    Mapa.Children.Add(lokalIkonica);

                    Canvas.SetLeft(lokalIkonica, lokal.X);
                    Canvas.SetTop(lokalIkonica, lokal.Y);

                }
            }

            // To scroll down in list, for easier drag and dropping recent item
            if (ListaLokala != null && ListaLokala.Items.Count != 0)
            {
                ListaLokala.ScrollIntoView(ListaLokala.Items.GetItemAt(ListaLokala.Items.Count - 1));
            }
        }


        private void ListView_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            startPoint = e.GetPosition(null);
        }

        private void ListView_MouseMove(object sender, MouseEventArgs e)
        {
            Point mousePos = e.GetPosition(null);
            Vector diff = startPoint - mousePos;

            if (e.LeftButton == MouseButtonState.Pressed &&
                (Math.Abs(diff.X) > SystemParameters.MinimumHorizontalDragDistance ||
                Math.Abs(diff.Y) > SystemParameters.MinimumVerticalDragDistance))
            {
                // Get the dragged ListViewItem
                ListView listView = sender as ListView;
                ListViewItem listViewItem =
                    FindAncestor<ListViewItem>((DependencyObject)e.OriginalSource);

                // Find the data behind the ListViewItem
                try
                {
                    Lokal lokal = (Lokal)listView.ItemContainerGenerator.
                                        ItemFromContainer(listViewItem);

                    // Initialize the drag & drop operation
                    DataObject dragData = new DataObject("myFormat", lokal);
                    DragDrop.DoDragDrop(listViewItem, dragData, DragDropEffects.Move);
                }
                catch
                {

                }


            }
        }
        private static T FindAncestor<T>(DependencyObject current) where T : DependencyObject
        {
            do
            {
                if (current is T)
                {
                    return (T)current;
                }
                current = VisualTreeHelper.GetParent(current);
            }
            while (current != null);
            return null;
        }

        private void Azuriraj_Click(object sender, RoutedEventArgs e)
        {
            if (selektovanLokal != null)
            {
                Detaljnije detaljnije = new Detaljnije(selektovanLokal);
                detaljnije.Show();
            }
        }
        private void Ukloni_Click(object sender, RoutedEventArgs e)
        {
            if (selektovanLokal != null)
            {
                LokaliNaMapi.Remove(selektovanLokal);
                Lokali.Add(selektovanLokal);
                LokaliPins_Draw();
            }
        }

        private void Obrisi_Click(object sender, RoutedEventArgs e)
        {
            if (selektovanLokal != null)
            {
                LokaliNaMapi.Remove(selektovanLokal);
                LokaliPins_Draw();
            }
        }
        private void Obrisi_Click_List(object sender, RoutedEventArgs e)
        {
            if (lokalSelektovanNaListi != null)
            {
                Lokali.Remove(lokalSelektovanNaListi);
            }
        }
        private void Azuriraj_Click_List(object sender, RoutedEventArgs e)
        {
            if (lokalSelektovanNaListi != null)
            {
                Detaljnije detaljnije = new Detaljnije(lokalSelektovanNaListi);
                detaljnije.Show();
            }
        }

        private void ListaLokala_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            Point mousePos = e.GetPosition(null);
            // Get the dragged ListViewItem
            ListView listView = sender as ListView;
            ListViewItem listViewItem =
                FindAncestor<ListViewItem>((DependencyObject)e.OriginalSource);

            // Find the data behind the ListViewItem
            try
            {
                Lokal lokal = (Lokal)listView.ItemContainerGenerator.
                                    ItemFromContainer(listViewItem);
                if (lokal != null)
                {
                    lokalSelektovanNaListi = lokal;
                }
                else
                {
                }

            }
            catch
            {

            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            if (!nazad)
            {
                Podaci.SacuvajPodatke(this.grad);
            }
        }

        private void Nazad_Click(object sender, RoutedEventArgs e)
        {
            nazad = true;
            StartPage sp = new StartPage();
            Podaci.SacuvajPodatke(this.grad);
            sp.Show();
            this.Close();
        }
    }
}
