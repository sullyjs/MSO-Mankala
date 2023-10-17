using System;
namespace MSO2
{
	public class MankalaBord : Spelbord
	{
		Kuiltje thuiskuiltjeSpeler1;
		Kuiltje thuiskuiltjeSpeler2;

        int aantalKuiltjes = 6;
        int steentjes = 4;

        public MankalaBord(int aantalKuiltjesPerSpeler, int steentjesPerKuiltje) : base(6, 4)
		{
			thuiskuiltjeSpeler1 = new Kuiltje(0);
			thuiskuiltjeSpeler2 = new Kuiltje(0);
		}
	}
}

