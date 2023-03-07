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


        private void InkomendeTreinen() { }

        private void rbBestemming_Checked(object sender, RoutedEventArgs e) { }
        private void rbSpoor_Checked(object sender, RoutedEventArgs e) { }
        private void RefreshTextBox() { }
        private void Spoor1_onSpoorStatus(Color kleur, string scherm) { }
        private void Spoor2_onSpoorStatus(Color kleur, string scherm) { }
        private void Spoor3_onSpoorStatus(Color kleur, string scherm) { }
        private void SporenVanDitTreinStationHardCoded() { }
        private void timer1_Tick(object sender, EventArgs e) { }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("Loaded");
        }






        //List<Trein> treinen;
        List<TreinPlus> loadedTreinen = new List<TreinPlus>();


        public MainWindow()
        {

            InitializeComponent();
            //SerializeTreinenToXML();
            DeserializeTreinenXML();
            tbSpoor1.Text = "Spoor 1 is bezet.";
            tbSpoor1.Background = Brushes.Red;
        }


        public void DeserializeTreinenXML()
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
