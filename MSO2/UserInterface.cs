using System;
namespace MSO2
{
	public abstract class UserInterface
	{
        protected Spel spel;
        protected Spelbord spelbord;

		public UserInterface(Spel huidigeSpel)
		{
			spel = huidigeSpel;
			spelbord = spel.bord;
		}

		// voor het tekenen van een overview van het bord aan het begin van het spel voor de spelers
		public abstract void OverviewBordTekenen();

		//Observer pattern methode
		public abstract void Update();

        public abstract void TekenBord();

		public abstract void VariantSpelKiezen(int spelKeuze);

        public abstract void VariantKeuzeMenu();

		public abstract void HuidigeSpeler();

		public abstract void Winnaar(int winnaar);

		public abstract void GekozenKuiltje();

		public abstract void KuiltjeKiezen();

		// error message voor als een ongeldig kuiltje wordt gekozen
		public abstract void VerkeerdKuiltjeInput();
    }
}

