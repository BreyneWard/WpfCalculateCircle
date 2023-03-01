using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
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
using static System.Net.Mime.MediaTypeNames;

namespace WpfFrmWerknemer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Werknemer> werknemerList = new List<Werknemer>();
        public MainWindow()
        {
            
            InitializeComponent();
            
            
            
        }

      
        private void btnToevoegen_Click(object sender, RoutedEventArgs e)
        {
            Werknemer w = new Werknemer(tbAchternaam.Text, tbVoornaam.Text, decimal.Parse(tbVerdiensten.Text, CultureInfo.InvariantCulture));
            werknemerList.Add(w);
            lvDisplayWerknemer.Items.Add(w.GetDisplayText("\t"));
          
            EmptyInputFields();
        }

        public void EmptyInputFields()
        {
            tbAchternaam.Text = string.Empty;
            tbVoornaam.Text = string.Empty;
            tbVerdiensten.Text = string.Empty;
            tbAchternaam.Focus();
        }

        private void btnVerwijderen_Click(object sender, RoutedEventArgs e)
        {
            object item = lvDisplayWerknemer.SelectedItem;
            //lvDisplayWerknemer.Items.Remove(item);
            var result = MessageBox.Show($"Are you sure you want to delete: {item}?","warning", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                lvDisplayWerknemer.Items.Remove(item);

            }

            // multiselect example -> change selectionmode multiple or extended
            //var items = lvDisplayWerknemer.SelectedItems;
            //var result = MessageBox.Show($"Are you sure you want to delete {items.count}","warning", MessageBoxButton.YesNo, MessageBoxImage.Question); 
            //if(result == MessageBoxResult.Yes)
            //{
            //    var itemsList = new ArrayList(items);
            //    foreach (var item in itemsList)
            //    {
            //        lvDisplayWerknemer.Items.Remove(item);

            //        //werknemerList.Remove(objet item);

            //    }

            //}


            // How to remove the item also from the internal collection werknemersList????
            // string[] fields = (string)item.Split('\t'); //split method not available on object item

            //Werknemer werknemer = new Werknemer();
            //Werknemer.Achternaam = fields[0];
            //Werknemer.Voornaam = fields[1];
            //employee.Verdiensten = decimal.Parse(fields[2])
        }









    }
}
