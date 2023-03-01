using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;

namespace WpfFrmWerknemer
{
    public class Werknemer
    {
        private decimal _verdiensten;
        public string Achternaam { get; set; }
        public string Voornaam { get; set; }
        
        public decimal Verdiensten
        {
            get { return _verdiensten; }
            set
            {
                if (value > 0)
                {
                    _verdiensten = value;
                }
            }
        }
                
                

        public Werknemer() { }
        public Werknemer(string achternaam, string voornaam, decimal verdiensten)
        {
            
            Achternaam = achternaam;
            Voornaam = voornaam;
            Verdiensten = verdiensten;
        }

        public string GetDisplayText(string sep)
        {
            return Achternaam + sep + Voornaam + sep +
            Verdiensten.ToString("0.00") + Environment.NewLine;
        }
        //method overloading
        public string GetDisplayText()
        {
            //return code + "-" + price.ToString("c") + "-" + 
            //description;
            return GetDisplayText("-");
        }

    }
}
