using System;
namespace MSO2
{
    public class MankalaBord : Spelbord
    {
        public Kuiltje thuiskuiltjeSpeler1;
        public Kuiltje thuiskuiltjeSpeler2;

        const int aantalKuiltjes = 6;
        const int steentjes = 4;

        public MankalaBord() : base(aantalKuiltjes, steentjes)
        {
            thuiskuiltjeSpeler1 = new Kuiltje(0);
            thuiskuiltjeSpeler2 = new Kuiltje(0);
        } 

        public int Winnaar()
        {
            // 1 is speler 1, 2 is speler 2, 0 is gelijkspel

            if (thuiskuiltjeSpeler1.Steentjes > thuiskuiltjeSpeler2.Steentjes)
            {
                return 1;
            }
            else if (thuiskuiltjeSpeler1.Steentjes < thuiskuiltjeSpeler2.Steentjes)
            {
                return 2;
            }
            else
            {
                return 0;
            }
        }
    }
}

