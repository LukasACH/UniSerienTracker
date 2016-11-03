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

namespace UniSerienTracker
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Vorlesung> vorlesungen = new List<Vorlesung>();
        private int indexListeVorlesung = -1;

        public MainWindow()
        {
            InitializeComponent();
            ErstelleVorlesung();
            updateList();
            string[,] vorlesungubersicht = new string[2, 3] { {"fdf","fdf","fdfd" },{"fdf","fdf","dfdf" } };
        }

        public void ErstelleVorlesung()
        {
            vorlesungen.Add(new Vorlesung("Lineare Algebra I"));
            vorlesungen[0].AddSerie("Serie 1", 16, 10.5);
            Console.WriteLine(vorlesungen[0].GetNameVonSerien()[0]);
            Console.WriteLine(vorlesungen[0].GetPercentage());
        }

        public string[] makeArray()
        {
            string[] vorlesungenArray = new string[vorlesungen.Count];
            int i = 0;
            foreach (Vorlesung v in vorlesungen)
            {
                vorlesungenArray[i] = v.ToString();
                i++;
            }
            return vorlesungenArray;
        }

        public void AddVorlesung(string name)
        {
            vorlesungen.Add(new Vorlesung(name));
        }

        private void buttonSubmit_Click(object sender, RoutedEventArgs e)
        {
            string nameVorlesung = nameNeueVorlesung.Text;
            nameNeueVorlesung.Text = "";
            if (!(nameVorlesung == ""))
                vorlesungen.Add(new Vorlesung(nameVorlesung));
            updateList();
        }

        private void updateList()
        {
            makeArray();
            listeVorlesungen.ItemsSource = makeArray();
            updateDataGrid();
        }

        private void updateDataGrid()
        {
            List<UebersichtVorlesung> listeUebersichtVorlesungen = new List<UebersichtVorlesung>();
            foreach (Vorlesung v in vorlesungen)
            {
                string prozent = "";
                try
                {
                    prozent = String.Format("{0}%", Convert.ToInt16(v.GetPercentage() * 100));
                }
                catch
                {
                    prozent = "0%";
                }
                string testat = String.Format("{0}%", Convert.ToInt16(v.testat * 100));
                listeUebersichtVorlesungen.Add(new UebersichtVorlesung { Vorlesung = v.ToString(), Prozent = prozent, Testat = testat });
            }
            uebersichtVorlesungen.Items.Clear();
            uebersichtVorlesungen.Items.Add(listeUebersichtVorlesungen);
        }

        private void buttonLöschen_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MessageBoxResult result = MessageBox.Show(String.Format("Willst du die Vorlesung \"{0:s}\" löschen?", listeVorlesungen.SelectedItem), "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    vorlesungen.RemoveAt(indexListeVorlesung);
                }
                
            }
            catch { }
            finally
            {
                updateList();
            }
        }

        private void listeVorlesungen_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            indexListeVorlesung = listeVorlesungen.SelectedIndex;
        }

        private void nameNeueVorlesung_KeyDown(object sender, KeyEventArgs e)
        { 
            if (e.Key == Key.Enter)
            {
                buttonSubmit_Click(this, new RoutedEventArgs());
            }
        }
    }

    class UebersichtVorlesung
    {
        public string Vorlesung { get; set; }
        public string Prozent { get; set; }
        public string Testat { get; set; }
    }
}
