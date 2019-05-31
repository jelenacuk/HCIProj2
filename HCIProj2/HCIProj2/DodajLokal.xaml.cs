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
using HCIProj2.Model;
using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace HCIProj2
{
    public partial class DodajLokal : Window
    {

        private Lokal lokal;
        public Lokal Lokal
        {
            get { return lokal; }
            set { lokal = value; }
        }

        private ObservableCollection<Etiketa> izabraneEtikete;
        public ObservableCollection<Etiketa> IzabraneEtikete
        {
            get { return izabraneEtikete; }
            set
            {
                if (value != izabraneEtikete)
                {
                    izabraneEtikete = value;
                    OnPropertyChanged("Etikete");
                }
            }
        }

        public DodajLokal()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            lokal = new Lokal();

            autoCompleteBoxTags.DataContext = Podaci.getInstance();
            DataContext = lokal;

            izabraneEtikete = new ObservableCollection<Etiketa>();
            comboBoxTags.DataContext = this;

        }

        private void dodajLokal_Click(object sender, RoutedEventArgs e)
        {
            textB_id.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            textB_naziv.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            textB_opis.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            textB_kapacitet.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            textB_ikonica.GetBindingExpression(TextBox.TextProperty).UpdateSource();

            lokal.Tip = (combo_tipovi.SelectedItem) as Tip;
            lokal.DatumOtvaranja = Convert.ToDateTime(textB_datum.Text); //05/05/2019

            lokal.CenovnaKategorija = ((combo_cene.SelectedItem as ComboBoxItem).Content as TextBlock).Text;
            lokal.DostupanHendikepiranim = ((combo_hendikepirani.SelectedItem as ComboBoxItem).Content as TextBlock).Text;
            lokal.PrimaRezervacije = ((combo_rezervacije.SelectedItem as ComboBoxItem).Content as TextBlock).Text;
            lokal.SluziAlkohol = ((combo_alkohol.SelectedItem as ComboBoxItem).Content as TextBlock).Text;
            Podaci.dodajLokal(lokal);
            Close();
        }

        //=====================ETIKETE======================
        private void dodajEtiketuBtn_Click(object sender, RoutedEventArgs e)
        {

            Etiketa etiketa = Podaci.getEtiketa(autoCompleteBoxTags.Text);
            if (etiketa != null)
            {
                bool found = false;
                foreach (var et in lokal.Etikete)
                {
                    if (etiketa.Id.Equals(et.Id))
                    {
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    lokal.Etikete.Add(etiketa);
                    IzabraneEtikete.Add(etiketa);
                }
                autoCompleteBoxTags.SelectedItem = null;
                autoCompleteBoxTags.Text = string.Empty;
            }
            else
            {
                dodajEtiketu navaEtiketa = new dodajEtiketu();
                navaEtiketa.Show();
            }
        }
        private void autoCompleteBoxTag_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                dodajEtiketuBtn_Click(null, null);
            }
        }

        //===================== TIPOVI======================
        private void combo_tipovi_Loaded(object sender, RoutedEventArgs e)
        {
            var combo = sender as ComboBox;
            combo.ItemsSource = Podaci.getInstance().Tipovi;
            combo.DisplayMemberPath = "Naziv";
        }
        private void noviTip_Click(object sender, RoutedEventArgs e)
        {
            dodajTip noviTip = new dodajTip();
            noviTip.Show();
        }


        //=====================IKONICA======================
        private void loadIcon_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files (*.png;*.jpg,*.ico)|*.ico;*.png;*.jpg";
            if (dialog.ShowDialog() == true)
            {
                textB_ikonica.Text = dialog.FileName;
            }
        }

        private void odustaniBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
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
