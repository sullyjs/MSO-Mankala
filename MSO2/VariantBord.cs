using System;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Linq;

namespace MSO2
{
	public class VariantBord : Spelbord
	{
        const int aantalKuiltjes = 5;
        const int steentjes = 5;

        public VariantBord() : base(aantalKuiltjes, steentjes)
        {
        }

        public override int Winnaar()
        {
            bool kuiltjesSpeler1Leeg = kuiltjesSpeler1.All(k => k.CheckLeeg());

            if (kuiltjesSpeler1Leeg)
            {
                return 1;
            }
            else
            {
                return 2;
            }
        }
    }
}

