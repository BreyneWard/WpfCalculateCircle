namespace InterfaceDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Persoon ward = new Persoon("Breyne", "Ward", 1981);
            BerekenLeeftijd(ward);
            Boom mijnBoom = new Boom(1971);
            BerekenLeeftijd(mijnBoom);
        }

        public static void BerekenLeeftijd(IOuderdom ouderdom)
        {
            Console.WriteLine("Naam: " + ouderdom.Naam + " Leeftijd: "+ouderdom.Ouderdom);
        }
    }
}