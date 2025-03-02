using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace IskolaWPF
{
    public partial class MainWindow : Window
    {
        public List<Tanulo> tanulok = new List<Tanulo>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            tanulok = BeolvasTanulok("nevek.txt");
            tanuloListBox.ItemsSource = tanulok;
        }

        private List<Tanulo> BeolvasTanulok(string fajlnev)
        {
            List<Tanulo> tanulok = new List<Tanulo>();
            try
            {
                foreach (string sor in File.ReadLines(fajlnev))
                {
                    string[] adatok = sor.Split(';');
                    if (adatok.Length == 3)
                    {
                        tanulok.Add(new Tanulo
                        {
                            Ev = int.Parse(adatok[0]),
                            Osztaly = adatok[1],
                            Nev = adatok[2]
                        });
                    }
                }
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("A 'nevek.txt' fájl nem található.");
            }
            return tanulok;
        }

        private void Torles_Click(object sender, RoutedEventArgs e)
        {
            if (tanuloListBox.SelectedItem != null)
            {
                tanulok.Remove((Tanulo)tanuloListBox.SelectedItem);
                tanuloListBox.ItemsSource = null;
                tanuloListBox.ItemsSource = tanulok;
            }
            else
            {
                MessageBox.Show("Válasszon ki egy tanulót a törléshez.");
            }
        }

        private void Mentes_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter("nevekNEW.txt"))
                {
                    foreach (Tanulo tanulo in tanulok)
                    {
                        writer.WriteLine($"{tanulo.Ev} {tanulo.Osztaly} {tanulo.Nev}");
                    }
                }
                MessageBox.Show("Az adatok mentése sikeres.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hiba a fájlmentés során: {ex.Message}");
            }
        }
    }
}