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

        public MainWindow()
        {
            InitializeComponent();
            ErstelleVorlesung();
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
            string nameVorlesung = textBox.Text;
            textBox.Text = "";
            vorlesungen.Add(new Vorlesung(nameVorlesung));
            updateList();
        }

        private void updateList()
        {
            makeArray();
            listView.ItemsSource = makeArray();
        }
    }
}
