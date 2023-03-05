using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breyne_Ward_WPF_Ev_Deel1
{
    internal class TreinPlus : Trein
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

		// Methods
		
		public TreinPlus(int eenKentekennr, string eenBestemming, int eenMaxAantalPassagiers,int eenVertrekNaXSeconden)
        {
            KentekenNummer = eenKentekennr;
            Bestemming = eenBestemming;
			MaxAantalPassagiers = eenMaxAantalPassagiers;
            VertrekNaXSeconden = eenVertrekNaXSeconden;
        }

        public TreinPlus()
        {
        }

        public void PassagiersStappenOp()
		{

		}

		public void StartTime() { }
		
	}
}
