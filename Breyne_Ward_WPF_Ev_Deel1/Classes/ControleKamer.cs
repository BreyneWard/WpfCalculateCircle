using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breyne_Ward_WPF_Ev_Deel1.Classes
{
    public partial class ControleKamer
    {
        // fields and properties
        private List<Spoor> _sporen;

        public List<Spoor> Sporen
        {
			get { return _sporen; }
			set { _sporen = value; }
		}

        // methods
        //constructors
        public ControleKamer() { }
        public ControleKamer(List<Spoor> sporen) { }

        public Trein ControleerSporen(Trein eenTrein) { return new Trein(); }
        


	}
}
