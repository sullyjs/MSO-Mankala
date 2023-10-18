using System;
namespace MSO2
{
	public class MankalaBord : Spelbord
	{
		Kuiltje thuiskuiltjeSpeler1;
		Kuiltje thuiskuiltjeSpeler2;

        //int aantalKuiltjes = 6;
        //int steentjes = 4;

        public MankalaBord() : base(6, 4)
		{
			thuiskuiltjeSpeler1 = new Kuiltje(0);
			thuiskuiltjeSpeler2 = new Kuiltje(0);
		}


		public bool CheckAlleKuiltjesLeeg()
		{
			for (int i = 0; i < 6; i++)
			{
				if (!kuiltjesSpeler1[i].CheckLeeg())
				{
					return false;
				}

				if (!kuiltjesSpeler1[i].CheckLeeg())
				{
					return false;
				}
			}

			return true;
		}
	}
}

