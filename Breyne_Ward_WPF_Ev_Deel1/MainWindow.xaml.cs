using Breyne_Ward_WPF_Ev_Deel1.Classes;
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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        private List<Spoor> _sporenLijst;

        public List<Spoor> LijstSporen
        {
            get { return _sporenLijst; }
            set { _sporenLijst = value; }
        }

        private List<Trein> _treinenlijst;

        public List<Trein> LijstTreinen
        {
            get { return _treinenlijst; }
            set { _treinenlijst = value; }
        }

        private ControleKamer _mijnControleKamer;
        private int _teller;

        private DispatcherTimer _timer1;

        private List<TreinPlus> loadedTreinen = new List<TreinPlus>();

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
                    TreinPlus trein = new TreinPlus();
                    trein.KentekenNummer = int.Parse(treinNode.SelectSingleNode("kentekennr").InnerText);
                    trein.Bestemming = treinNode.SelectSingleNode("bestemming").InnerText;
                    trein.MaxAantalPassagiers = int.Parse(treinNode.SelectSingleNode("maxAantalPassagiers").InnerText);
                    trein.VertrekNaXSeconden = int.Parse(treinNode.SelectSingleNode("vertrekNaXSeconden").InnerText);

                    loadedTreinen.Add(trein);
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
            
            _mijnControleKamer = new ControleKamer(LijstSporen);
            foreach(TreinPlus t in loadedTreinen)
            {
                Trein treinOpSpoor = new Trein();
                treinOpSpoor = _mijnControleKamer.ControleerSporen(t);
                //treinOpSpoor.
            }
            

        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("Loaded");
        }
        private void rbBestemming_Check(object sender, RoutedEventArgs e)
        {

        }

        private void rbSpoor_Check(object sender, RoutedEventArgs e)
        {

        }






        


        public MainWindow()
        {

            InitializeComponent();

            // Testing with DispatcherTimer bind it to textblock tbSpoor1 to fire after 12seconds
            _teller = 12; // 12 sec
            _timer1 = new DispatcherTimer();
            _timer1.Interval = TimeSpan.FromSeconds(_teller);
            _timer1.Tick += timer1_Tick;
            _timer1.Start();


            InkomendeTreinen();
            SporenVanDitTreinStationHardCoded();
           
            


            
            
            

           // DeserializeTreinenXML();
           //tbSpoor1.Text = "Spoor 1 is bezet.";
           // tbSpoor1.Background = Brushes.Red;
            //lvTreinen.Items.Add(tbSpoor1.Text);
        }


        public void DeserializeTreinenXML()
        {
            
            // path to xml
            //string path = Combine(CurrentDirectory, "Treinen.xml");

            //using (FileStream xmlLoad = File.Open(path, FileMode.Open))
            //{

            //    // deserialize and cast the object graph into a List of Trein
            //    XmlSerializer xs = new XmlSerializer(loadedTreinen.GetType());
            //    List<Trein> loadedTreinen = xs.Deserialize(xmlLoad) as List<Trein>;

            //    if (loadedTreinen is not null) //not possible in .NET framework 4.8??
            //    {
            //        foreach(Trein t in loadedTreinen) 
            //        {
            //            WriteLine("{}{}{}");
            //        }
            //    }
            //}

        }

        private void btn_loadxml_Click(object sender, RoutedEventArgs e)
        {
            //bevat nog bug -> maakt aantal keer zelfde treinen aan, maar leest nu wel mijn xml al uit 
            // intereer over loop en print values van treinen
            foreach (TreinPlus tp in loadedTreinen)
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
