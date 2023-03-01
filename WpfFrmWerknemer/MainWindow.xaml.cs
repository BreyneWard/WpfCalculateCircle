using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http.Headers;
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
using static System.Net.Mime.MediaTypeNames;

namespace WpfFrmWerknemer
{

    public partial class MainWindow : Window
    {
        // Test gedaan met creatie van een list van Werknemers met de bedoeling dat ik de toegevoegde werknemer records die in de view
        // Toegevoegd worden in een interne list collection bijgehouden worden om deze bijvoorbeeld dan weg te schrijven naar een file en/of
        // database
        List<Werknemer> werknemerList = new List<Werknemer>();
        public MainWindow()
        {

            InitializeComponent();

        }


        private void btnToevoegen_Click(object sender, RoutedEventArgs e)
        {
            //Creer werknemer object en voeg toe aan werknemerList
            Werknemer w = new Werknemer(tbAchternaam.Text, tbVoornaam.Text, decimal.Parse(tbVerdiensten.Text, CultureInfo.InvariantCulture));
            werknemerList.Add(w);
            lvDisplayWerknemer.Items.Add(w.GetDisplayText("\t"));
            // Maak na toevoegen de invoervelden leeg
            ClearInputFields();
        }

        public void ClearInputFields()
        {
            tbAchternaam.Text = string.Empty;
            tbVoornaam.Text = string.Empty;
            tbVerdiensten.Text = string.Empty;
            tbAchternaam.Focus();
        }

        private void btnVerwijderen_Click(object sender, RoutedEventArgs e)
        {
            
            object item = lvDisplayWerknemer.SelectedItem;



            var result = MessageBox.Show($"Are you sure you want to delete: {item}?", "warning", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                // remove werknemer record from wpf form
                lvDisplayWerknemer.Items.Remove(item);

                // also remove werknemer from internal list werknemerList
                string[] fields = item.ToString().Split('\t');
                //split method not available on object item warning in VS Studio, oplossing gevonden je moet object
                //naar string brengen via de ToString method dan pas is de Split method available enkel beschikbaar op strings en niet op object.
                
                // quick check door te itereren over mijn array en resultaat te printen in een MessageBox -> Gaat rapper in debugger maar wou eens checken of je dit zo
                // kan testen werkt effectief
                //foreach(string field in fields)
                //{
                //    MessageBox.Show($"{field}");
                //}

                //Onderstaande commented code werkte niet omdat dit het object niet uit mijn list verwijderde vermoedelijk omdat hij
                // geen match vond??
                //Werknemer w = new Werknemer();
                //w.Achternaam = fields[0];
                //w.Voornaam = fields[1];
                //w.Verdiensten = decimal.Parse(fields[2]);

                //remove from list
                //werknemerList.Remove(w);

                // betere manier die werkt, dit retourneerd null als er geen object in list gevonden werd, throw error when duplicate values to remove
                // nog exception handling nodig in dit geval!
                var itemToRemove = werknemerList.SingleOrDefault(r => r.Achternaam == fields[0] && r.Voornaam == fields[1] && r.Verdiensten == decimal.Parse(fields[2]));
             
                if (itemToRemove != null)
                    werknemerList.Remove(itemToRemove);
                else
                {
                    MessageBox.Show("no items were removed from internal list");
                }

                // via show messagebox resultaat geprint kon makkelijker via debugger ook.
                //foreach (Werknemer x in werknemerList)
                //{
                //    MessageBox.Show($"{x.GetDisplayText(" ")}");

                //}


                // ik had hier een voorbeeld voor multiselect gemaakt
                // multiselect example -> change selectionmode multiple or extended
                //var items = lvDisplayWerknemer.SelectedItems;
                //var result = MessageBox.Show($"Are you sure you want to delete {items.count}","warning", MessageBoxButton.YesNo, MessageBoxImage.Question); 
                //if(result == MessageBoxResult.Yes)
                //{
                //    var itemsList = new ArrayList(items);
                //    foreach (var item in itemsList)
                //    {
                //        lvDisplayWerknemer.Items.Remove(item);
                //
                //    }

                //}

            }

        }
    }
}
