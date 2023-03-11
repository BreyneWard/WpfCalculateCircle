﻿using Breyne_Ward_WPF_Ev_Deel1.Classes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Xml;
using System.Xml.Serialization;
using static System.Console;
using static System.Environment;
using static System.IO.Path;

namespace Breyne_Ward_WPF_Ev_Deel1
{
    
    public partial class MainWindow : Window
    {
        
        private List<Spoor> _sporenLijst = new List<Spoor>();

        public List<Spoor> LijstSporen
        {
            get { return _sporenLijst; }
            set { _sporenLijst = value; }
        }

        private List<Trein> _treinenlijst = new List<Trein> { };

        public List<Trein> LijstTreinen
        {
            get { return _treinenlijst; }
            set { _treinenlijst = value; }
        }

        private ControleKamer _mijnControleKamer;
        private int _teller;

        private DispatcherTimer _timer1;

        //private List<TreinPlus> loadedTreinen = new List<TreinPlus>();

        private void InkomendeTreinen() 
        {
            XmlNodeList treinNodes;
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load("Treinen.xml");
                treinNodes = doc.SelectNodes("//trein");

                foreach (XmlNode treinNode in treinNodes)
                {
                    Trein trein = new Trein();
                    trein.KentekenNummer = int.Parse(treinNode.SelectSingleNode("kentekennr").InnerText);
                    trein.Bestemming = treinNode.SelectSingleNode("bestemming").InnerText;
                    trein.MaxAantalPassagiers = int.Parse(treinNode.SelectSingleNode("maxAantalPassagiers").InnerText);
                    trein.VertrekNaXSeconden = int.Parse(treinNode.SelectSingleNode("vertrekNaXSeconden").InnerText);

                    LijstTreinen.Add(trein);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading Treinen.xml: " + ex.Message);
            }
        }

        
        
        private void RefreshTextBox() { }
        private void Spoor1_onSpoorStatus(Color kleur, string scherm) 
        {
            SolidColorBrush brush = new SolidColorBrush(kleur);
            tbSpoor1.Background = brush;
            tbSpoor1.Text = scherm;
        }
        private void Spoor2_onSpoorStatus(Color kleur, string scherm) 
        {
            SolidColorBrush brush = new SolidColorBrush(kleur);
            tbSpoor2.Background = brush;
            tbSpoor2.Text = scherm;

        }
        private void Spoor3_onSpoorStatus(Color kleur, string scherm)
        {
            SolidColorBrush brush = new SolidColorBrush(kleur);
            tbSpoor3.Background = brush;
            tbSpoor3.Text = scherm;
        }
        private void SporenVanDitTreinStationHardCoded() 
        {
            LijstSporen = new List<Spoor>();
            Spoor spoor1 = new Spoor(1, true);
            Spoor spoor2 = new Spoor(2, true);
            Spoor spoor3 = new Spoor(3, true);
            LijstSporen.Add(spoor1);
            LijstSporen.Add(spoor2);
            LijstSporen.Add(spoor3);
    
            Color green = Colors.Green;
            Spoor1_onSpoorStatus(green, "Spoor 1 is leeg.");
            Spoor2_onSpoorStatus(green, "Spoor 2 is leeg.");
            Spoor3_onSpoorStatus(green, "Spoor 3 is leeg.");

        }

        private void timer1_Tick(object sender, EventArgs e) 
        {
            //test Dispatcher timer on textblock tbSpoor1
            //tbSpoor1.Text = DateTime.Now.ToLongTimeString();
            try
            {
                Trein treinOpSpoor = LijstTreinen[0];
                treinOpSpoor = _mijnControleKamer.ControleerSporen(treinOpSpoor);



            }
            catch (Exception)
            {

                throw;
            }
            
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // instantiate controlekamer
            _mijnControleKamer = new ControleKamer(LijstSporen);
            // xml to trein list
            InkomendeTreinen();
            // sporen to sporen list
            SporenVanDitTreinStationHardCoded();

            rbBestemming.IsChecked = true;

            // Testing with DispatcherTimer bind it to textblock tbSpoor1 to fire after 12seconds

            int counter = 12; // 12 sec
            _timer1 = new DispatcherTimer();
            _timer1.Interval = TimeSpan.FromSeconds(counter);
            _timer1.Tick += timer1_Tick;
            _timer1.Start();

        }
        private void rbBestemming_Checked(object sender, RoutedEventArgs e)
        {
            string displayTreinen = "";
            //var sortedTrains = LijstTreinen.OrderBy(t => t.Bestemming);

            //foreach (var train in sortedTrains)
            //{
            //   displayTreinen += $"Trein {train.KentekenNummer} to {train.Bestemming}{Environment.NewLine}";
            //}

            // group the trains by destination
            var groupedTrains = LijstTreinen.GroupBy(t => t.Bestemming);

            // iterate over each destination group and print out the destination followed by the trains that have that destination
            foreach (var group in groupedTrains)
            {
                displayTreinen += $"{group.Key}:{Environment.NewLine}";
                foreach (var train in group)
                {
                    displayTreinen += $"Trein {train.KentekenNummer} to {train.Bestemming}{Environment.NewLine}";
                }
                displayTreinen += Environment.NewLine;
            }

            txtTreinen.Text= displayTreinen;
        }

        private void rbSpoor_Checked(object sender, RoutedEventArgs e)
        {
            // Not implemented
        }











        public MainWindow()
        {

            InitializeComponent();

            // DeserializeTreinenXML();
            //tbSpoor1.Text = "Spoor 1 is bezet.";
            // tbSpoor1.Background = Brushes.Red;
            //lvTreinen.Items.Add(tbSpoor1.Text);
        }


        private void btn_loadxml_Click(object sender, RoutedEventArgs e)
        {
            //bevat nog bug -> maakt aantal keer zelfde treinen aan, maar leest nu wel mijn xml al uit 
            // intereer over loop en print values van treinen
            foreach (Trein tp in LijstTreinen)
            {
                MessageBox.Show($"Train {tp.KentekenNummer} gaat naar {tp.Bestemming} met een max aantal" +
                    $"passagiers van: {tp.MaxAantalPassagiers} en vertrekt na {tp.VertrekNaXSeconden} seconden");
            }
        }

        



        //not asked
        //private void Window_ContentRendered(object sender, EventArgs e)
        //{
        //    MessageBox.Show("ContentRendered");
        //}





        // manual naar sql connecten, maar niet gebruikt.
        // try 
        //{	        
        //	SqlConnection con = new SqlConnection(@"Data Source=.\MMDEMO;Initial Catalog=WardStationDB;Integrated Security=True");

        //}
        //catch (global::System.Exception)
        //{

        //	throw;
        //}



        //Entity framework gekoppeld geen idee of dit ok is
        // via NuGet Package manager: Install-Package Microsoft.EntityFramework geinstalleerd, dan een ADO.NET DATA entity model gekoppeld en hier optie database
        // first genomen, volgens ik gezien heb maakt dit een een databasecontext class aan die inherit van dbContext
        // nl. DataModel.Context.cs, deze dient dan geïnstantieerd  te worden om met database WardStationDB en tabel Trein te werken
        // maar dit moet ik nog verder uitwerken en proberen.

    }
}
