using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breyne_Ward_WPF_Ev_Deel1
{
    class DataManager
    {
        public static int InsertTrein(Trein t)
        {
            int antwoord = 0;
            using (var mijnentities = new WardStationDBEntities())
            {
                mijnentities.Treins.Add(t);
                if (0 < mijnentities.SaveChanges())
                {
                    antwoord = t.TreinID;
                }
            }
            return antwoord;
        }
    }
}
