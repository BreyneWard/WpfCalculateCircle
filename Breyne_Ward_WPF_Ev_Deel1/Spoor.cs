using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breyne_Ward_WPF_Ev_Deel1
{
	// todo delegate toe te voegen
    internal class Spoor
    {
		public Spoor() { }
		public Spoor(int spoornr, bool vrij)
		{
			Spoornr = spoornr;
			Vrij = vrij;
		}
		private bool _vrij;

		public bool Vrij
		{
			get { return _vrij; }
			set { _vrij = value; }
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
