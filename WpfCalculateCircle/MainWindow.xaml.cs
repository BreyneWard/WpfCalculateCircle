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

namespace WpfCalculateCircle
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            txtInput.Focus();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            bool validInput = double.TryParse(txtInput.Text, out double value);
            if(validInput)
            {
                double oppervlakte = value * value * Math.PI;
                double omtrek = 2*value* Math.PI;
                tbResult.Text = $"Omtrek: {omtrek.ToString("0.00")} \nOppervlakte: {oppervlakte.ToString("0.00")}";
                tbResult.Visibility = Visibility.Visible;   
            }
            else
            {
                MessageBox.Show($"{txtInput.Text} is an invalid input, only numbers allowed","Error",MessageBoxButton.OK,MessageBoxImage.Error);
                txtInput.Text= string.Empty ;
                txtInput.Focus();
            }
        }

       

        private void txtInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            tbResult.Text = string.Empty;
        }
    }
}
