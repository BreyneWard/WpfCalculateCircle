using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breyne_Ward_WPF_Ev_Deel1
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
        public ControleKamer(List<Spoor> sporen) 
        {
            Sporen= sporen;
        }

        public Trein ControleerSporen(Trein eenTrein) 
        {
            //foreach(Spoor sp in Sporen) 
            //{
            //    if (sp.Vrij == true)
            //    {
            //        eenTrein.SpoorNummer = sp.Spoornr;
            //        //sp.Vrij= false;
            //        //etc.
            //    }
            //    else
            //    {
            //        // do nothing
            //    }
            //}



            //return eenTrein; 
            Trein nieuweTrein = new Trein(eenTrein.KentekenNummer, eenTrein.Bestemming, eenTrein.VertrekNaXSeconden);
            foreach (Spoor spoor in Sporen)
            {
                if (spoor.Vrij == true)
                {
                    spoor.Vrij = false;

                    nieuweTrein.StartTimer();
                    nieuweTrein.SpoorNummer = spoor.Spoornr;

                    nieuweTrein.MaxAantalPassagiers = eenTrein.MaxAantalPassagiers;
                    nieuweTrein.PassagiersStappenOp();
                    nieuweTrein.AantalPassagiers = nieuweTrein.AantalPassagiersOpgestapt;
                    spoor.Scherm = nieuweTrein.ToString();

                    nieuweTrein.TicketPrijs = 15;
                    nieuweTrein.ConducAanwezig = true;

                    nieuweTrein.Spoor = spoor;

                    DataManager.InsertTrein(nieuweTrein);

                    break;
                }
            }


            return nieuweTrein;

        }



    }
}
