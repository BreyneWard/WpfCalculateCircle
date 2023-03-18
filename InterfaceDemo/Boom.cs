using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceDemo
{
    public class Boom: IOuderdom
    {
        private int _ringen;

        public int Ouderdom
        {
            get { return _ringen; }
        }
        

        public string Naam
        {
            get { return "Boom"; }
        }

        public Boom(int eenJaarGeplant)
        {
            _ringen = DateTime.Now.Year - eenJaarGeplant;    
           
        }
    }
}
