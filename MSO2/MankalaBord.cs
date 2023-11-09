using System;
namespace MSO2
{
    public class MankalaBord : Spelbord
    {

        const int aantalKuiltjes = 6;
        const int steentjes = 4;

        public MankalaBord() : base(aantalKuiltjes, steentjes)
        {
            thuiskuiltjeSpeler1 = new Kuiltje(0);
            thuiskuiltjeSpeler2 = new Kuiltje(0);
        }
    }
}

