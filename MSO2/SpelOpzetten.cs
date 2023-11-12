using System;
namespace MSO2
{
	public class SpelOpzetten
	{
        public SpelUitvoeren spelLogica;
        public UserInputHandler inputHandler = UserInputHandler.GetInstance();
        public UserInterface ui;
        UserInterface uiSpelOpzetten;   // is nodig om functies uit UserInterface te kunnen gebruiken die geen gebruik maken van het bord

        public SpelOpzetten()
		{
            uiSpelOpzetten = new ConsoleUI(new MankalaSpel());  //random Mankala spel, want bord wordt niet gebruikt

            spelLogica = new SpelUitvoeren();
            VariantSpelKiezen();
            
            ui = new ConsoleUI(spelLogica.spel);
            // ervoor zorgen dat de UI een observer wordt van het Spel
            spelLogica.spel.Subscribe(ui);
            ui.OverviewBordTekenen();
		}

		public void VariantSpelKiezen()
		{
            uiSpelOpzetten.VariantKeuzeMenu();

            int variantSpel = inputHandler.ChooseGame();

            if (variantSpel == 1)
            {
                spelLogica.spel = new MankalaSpel();
                uiSpelOpzetten.VariantSpelKiezen(1);
                spelLogica.gameActive = true;
            }
            else if (variantSpel == 2)
            {
                spelLogica.spel = new WariSpel();
                uiSpelOpzetten.VariantSpelKiezen(2);
                spelLogica.gameActive = true;
            }
            else if (variantSpel == 3)
            {
                spelLogica.spel = new UUSpel();
                uiSpelOpzetten.VariantSpelKiezen(3);
                spelLogica.gameActive = true;
            }
            else
            {
                // ongeldige keuze
                uiSpelOpzetten.VariantSpelKiezen(0);
                VariantSpelKiezen();
            }
        }

        public static void Main()
        {
            SpelOpzetten spel = new SpelOpzetten();

            spel.spelLogica.RunGame();
        }
    }
}

