using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Breyne_Ward_WPF_Ev_Deel1
{
	// todo delegate toe te voegen
    public partial class Spoor
    {
		public Spoor() { }
		public Spoor(int spoornr, bool vrij)
		{
			Spoornr = spoornr;
			Vrij = vrij;
			this.Scherm = "";
		}

        public delegate void SpoorStatusHandler(Color kleur, string scherm);
        public event SpoorStatusHandler onSpoorStatus;

        private bool _vrij;

		public bool Vrij
		{
			get { return _vrij; }
			set
			{
				_vrij = value;
				if(_vrij == false)
				{
					if(onSpoorStatus != null)
					{
                        onSpoorStatus(Colors.Red, Scherm);
                    }
				}
				else
				{
                    Scherm = "";
                    if (onSpoorStatus != null)
                    {
                        onSpoorStatus(Colors.Green, Scherm);
                    }
                }
			
			
			
			}
		}

		private int _spoornr;

		public int Spoornr
		{
			get { return _spoornr; }
			set { _spoornr = value; }
		}

		private string _scherm;

		public string Scherm
        {
			get { return _scherm; }
			set { _scherm = value; }
		}

		

	}
}
