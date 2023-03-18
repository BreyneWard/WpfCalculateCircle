using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
		private DispatcherTimer Timer1
        {
            get { return _timer1; } 
            set { _timer1 = value; } 
        }
		//private Timer1_Tick(object sender, EventArgs e);
		private Random wilgetal = new Random();

        //default constructor
        public Trein()
        {
        }


        // Overloaded constructor
        public Trein(int eenKentekennr, string eenBestemming,
             int eenVertrekNaXSeconden)
        {
            this.KentekenNummer = eenKentekennr;
            this.Bestemming = eenBestemming;
            this.Vertrek = DateTime.Now.AddSeconds(eenVertrekNaXSeconden);

            //Dit doe je elke keer je een nieuw object aanmaakt. 
            Timer1 = new DispatcherTimer();
            Timer1.Interval = new TimeSpan(0, 0, 0, 1);
            Timer1.Tick += Timer1_Tick;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            DateTime nu = DateTime.Now;

            if (DateTime.Compare(nu, Vertrek) >= 0)
            {
                this.Spoor.Vrij = true;
                Timer1.Stop();
            }

            //if (nu.Hour.Equals(Vertrek.Hour) && nu.Minute.Equals(Vertrek.Minute) && nu.Second.Equals(Vertrek.Second))
            //{
            //    this.Spoor.Vrij = true;
            //}
        }

       

        public void PassagiersStappenOp()
		{
            this.AantalPassagiersOpgestapt = wilgetal.Next(0, this.MaxAantalPassagiers + 1);
        }

		public void StartTimer() 
        {
            Timer1.Start();    
        }

        public override string ToString()
        {
            return this.KentekenNummer + " - " + this.Bestemming + " - " + this.Vertrek.ToString("HH:mm:ss");
        }

    }
    class SpoorComparer : IComparer<Trein>
    {
        public int Compare(Trein x, Trein y)
        {
            return x.SpoorNummer.CompareTo(y.SpoorNummer);
        }
    }

    class BestemmingComparer : IComparer<Trein>
    {
        public int Compare(Trein x, Trein y)
        {
            return x.Bestemming.CompareTo(y.Bestemming);
        }
    }
}
