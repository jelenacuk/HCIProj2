using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HCIProj2.Shortcuts
{
    public static class Precice
    {
        public static readonly RoutedUICommand IzlistajSakrijLokale = new RoutedUICommand(
            "lista lokala",
            "IzlistajSakrijLokale",
            typeof(RoutedCommand),
            new InputGestureCollection()
            {
                new KeyGesture(Key.I, ModifierKeys.Control)
            }
            );

        public static readonly RoutedUICommand DodajLokalCmd = new RoutedUICommand(
            "dodaj lokal",
            "DodajLokalCmd",
            typeof(RoutedCommand),
            new InputGestureCollection()
            {
                new KeyGesture(Key.Q, ModifierKeys.Control)
            }
            );

        public static readonly RoutedUICommand DodajEtiketuCmd = new RoutedUICommand(
            "dodaj etiketu",
            "DodajEtiketuCmd",
            typeof(RoutedCommand),
            new InputGestureCollection()
            {
                new KeyGesture(Key.W, ModifierKeys.Control)
            }
            );

        public static readonly RoutedUICommand DodajTipCmd = new RoutedUICommand(
            "dodaj tip",
            "DodajTipCmd",
            typeof(RoutedCommand),
            new InputGestureCollection()
            {
                new KeyGesture(Key.E, ModifierKeys.Control)
            }
            );

        public static readonly RoutedUICommand PrikaziLokaleCmd = new RoutedUICommand(
            "prikazi lokal",
            "PrikaziLokalCmd",
            typeof(RoutedCommand),
            new InputGestureCollection()
            {
                new KeyGesture(Key.Q, ModifierKeys.Alt)
            }
            );

        public static readonly RoutedUICommand PrikaziEtiketeCmd = new RoutedUICommand(
            "prikazi etiketu",
            "PrikaziEtiketuCmd",
            typeof(RoutedCommand),
            new InputGestureCollection()
            {
                new KeyGesture(Key.W, ModifierKeys.Alt)
            }
            );

        public static readonly RoutedUICommand PrikaziTipoveCmd = new RoutedUICommand(
            "prikazi tip",
            "PrikaziTipCmd",
            typeof(RoutedCommand),
            new InputGestureCollection()
            {
                new KeyGesture(Key.E, ModifierKeys.Alt)
            }
            );

        public static readonly RoutedUICommand ZatvoriProzorCmd = new RoutedUICommand(
            "zatvori prozor",
            "ZatvoriProzorCmd",
            typeof(RoutedCommand),
            new InputGestureCollection()
            {
                new KeyGesture(Key.Escape)
            }
            );

        public static readonly RoutedUICommand EtiketaEnterCmd = new RoutedUICommand(
            "dodaj etiketu",
            "EtiketaEnterCmd",
            typeof(RoutedCommand),
            new InputGestureCollection()
            {
                new KeyGesture(Key.Enter,ModifierKeys.Control)
            }
            );

        public static readonly RoutedUICommand PonistiPretraguCmd = new RoutedUICommand(
            "ponisti pretragu",
            "PonistiPretraguCmd",
            typeof(RoutedCommand),
            new InputGestureCollection()
            {
                new KeyGesture(Key.Enter,ModifierKeys.Alt)
            }
            );
        public static readonly RoutedUICommand PomocCmd = new RoutedUICommand(
            "pomoc",
            "pomocCmd",
            typeof(RoutedCommand),
            new InputGestureCollection()
            {
                new KeyGesture(Key.F1,ModifierKeys.Control)
            }
            );
    }
}
