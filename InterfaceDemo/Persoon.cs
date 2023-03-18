using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceDemo
{
    internal class Persoon:IOuderdom
    {
        private string _familieNaam;
        private string _voorNaam;
        private int _geboortejaar;

        public Persoon(string eenFamilieNaam, string eenVoorNaam, int eenGeboortejaar)
        {
            _familieNaam = eenFamilieNaam;
            _voorNaam = eenVoorNaam;
            _geboortejaar = eenGeboortejaar;
        }

        public int Ouderdom
        {
            get { return DateTime.Now.Year - _geboortejaar;}
        }
        
        public string Naam
        {
            get { return _voorNaam + " " + _familieNaam; }
        }
        
    }
}
