using System;
namespace MSO2
{
	public class MankalaBord : Spelbord
	{
		Kuiltje thuiskuiltjeSpeler1;
		Kuiltje thuiskuiltjeSpeler2;

		public MankalaBord(int aantalKuiltjesPerSpeler, int steentjesPerKuiltje) : base(aantalKuiltjesPerSpeler, steentjesPerKuiltje)
		{
			thuiskuiltjeSpeler1 = new Kuiltje(0);
			thuiskuiltjeSpeler2 = new Kuiltje(0);
		}
	}
}

