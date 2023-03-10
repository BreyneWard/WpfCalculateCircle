using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Breyne_Ward_WPF_Ev_Deel1
{
    public partial class Trein
    {
		// Fields and properties
		private int _aantalPassagiersOpgestapt;

		public int  AantalPassagiersOpgestapt
		{
			get { return _aantalPassagiersOpgestapt; }
			set { _aantalPassagiersOpgestapt = value; }
		}

		private int _vertrekNaXSeconden;

		public int VertrekNaXSeconden

		{
			get { return _vertrekNaXSeconden; }
			set { _vertrekNaXSeconden = value; }
		}

		private Spoor _Spoor;

		public Spoor Spoor
		{
			get { return _Spoor; }
			set { _Spoor = value; }
		}

		private DispatcherTimer _timer1;
		private DispatcherTimer Timer1 { get; set; }
		//private Timer1_Tick(object sender, EventArgs e);
		private Random wilgetal;


		// Methods
		// Default constructor
		//public TreinPlus() { }


		// Overloaded constructor
		public Trein()
		{
				
		}

		public Trein(int kentekenNummer, string bestemming, int spoorNummer, DateTime vertrek, int? aantalPassagiers, int maxAantalPassagiers, decimal? ticketPrijs, bool? conducAanwezig, int aantalPassagiersOpgestapt, int vertrekNaXSeconden, Spoor spoor, DispatcherTimer timer1, Random getal)
		{
            KentekenNummer = kentekenNummer;
            Bestemming = bestemming;
            SpoorNummer = spoorNummer;
            Vertrek = vertrek;
            AantalPassagiers = aantalPassagiers;
            MaxAantalPassagiers = maxAantalPassagiers;
            TicketPrijs = ticketPrijs;
            ConducAanwezig = conducAanwezig;
			AantalPassagiersOpgestapt = aantalPassagiersOpgestapt;
			VertrekNaXSeconden = vertrekNaXSeconden;
			Spoor = spoor;
			Timer1 = timer1;
			wilgetal = getal;
        }

        public void PassagiersStappenOp()
		{

		}

		public void StartTimer() { }

        public override string ToString()
        {
            return ToString();
        }

    }
}
