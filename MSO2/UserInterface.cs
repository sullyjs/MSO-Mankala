using System;
namespace MSO2
{
	public abstract class UserInterface
	{
		protected Spel spel;

		public UserInterface(Spel huidigeSpel)
		{
			spel = huidigeSpel;
		}

		// voor het tekenen van een overview van het bord aan het begin van het spel voor de spelers
		public abstract void OverviewBordTekenen();

        public abstract void TekenBord();

		public abstract void TekenSpelerKant(int speler);

		// voor het tekenen van de thuiskuiltjes/verzamelkuiltjes
		public abstract void TekenTussenkuiltje(Kuiltje kSpeler1, Kuiltje kSpeler2);
    }
}

