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
        //List<Trein> treinen;
        List<TreinPlus> loadedTreinen = new List<TreinPlus>();

        public MainWindow()
        {
            InitializeComponent();
            //SerializeTreinenToXML();
            DeserializeTreinenXML();
        }

        
        public void DeserializeTreinenXML()
        {
            XmlNodeList treinNodes;
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load("Treinen.xml");
                treinNodes = doc.SelectNodes("//trein");
                //foreach (XmlNode node in treinNodes)
                //{
                    // Hier zat foutje in omdat mijn xml aparte xml tags gebruikte en niet alles als attribuut onder de trein tag zat, vermoed ik
                    // Manier hieronder werkte dan wel
                    //
                    //TreinPlus trein = new TreinPlus
                    //{
                    //    KentekenNummer = int.Parse(node.Attributes["kentekennr"].Value),
                    //    Bestemming = node.Attributes["bestemming"].Value,
                    //    MaxAantalPassagiers = int.Parse(node.Attributes["maxAantalPassagiers"].Value),
                    //    VertrekNaXSeconden = int.Parse(node.Attributes["vertrekNaXSeconden"].Value)
                    //};

                   

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
