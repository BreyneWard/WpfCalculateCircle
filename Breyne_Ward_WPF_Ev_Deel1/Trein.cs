//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Breyne_Ward_WPF_Ev_Deel1
{
    using System;
    using System.Collections.ObjectModel;
    
    public partial class Trein
    {
        public int TreinID { get; set; }
        public int KentekenNummer { get; set; }
        public string Bestemming { get; set; }
        public int SpoorNummer { get; set; }
        public System.DateTime Vertrek { get; set; }
        public Nullable<int> AantalPassagiers { get; set; }
        public int MaxAantalPassagiers { get; set; }
        public Nullable<decimal> TicketPrijs { get; set; }
        public Nullable<bool> ConducAanwezig { get; set; }
    }
}
