using System;
namespace MSO2
{
	public abstract class UserInterface
	{
		protected Spelbord spelbord;

		public UserInterface(Spelbord huidigeSpelbord)
		{
			spelbord = huidigeSpelbord;
		}

		// voor het tekenen van een overview van het bord aan het begin van het spel voor de spelers
		public abstract void OverviewBordTekenen();

        public abstract void TekenBord();

		// kuiltjes van 1 speler tekenen
		public abstract void TekenSpelerKant(int speler);

		// voor het tekenen van de thuiskuiltjes/verzamelkuiltjes
		public abstract void TekenTussenkuiltje(Kuiltje kSpeler1, Kuiltje kSpeler2);

		public abstract void VariantSpelKiezen(int spelKeuze);

        public abstract void VariantKeuzeMenu();

		public abstract void HuidigeSpeler(int speler);

		public abstract void Winnaar(int winnaar);
    }
}

