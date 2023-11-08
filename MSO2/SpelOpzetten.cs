using System;
namespace MSO2
{
	public class SpelOpzetten
	{
        SpelUitvoeren spelLogica;
        UserInputHandler inputHandler = UserInputHandler.GetInstance();
        UserInterface ui;
        UserInterface uiSpelOpzetten;   // is nodig om functies uit UserInterface te kunnen gebruiken die geen gebruik maken van het bord

        public SpelOpzetten()
		{
            uiSpelOpzetten = new ConsoleUI(new MankalaSpel());

            spelLogica = new SpelUitvoeren();
            VariantSpelKiezen();
            
            ui = new ConsoleUI(spelLogica.spel);
            // ervoor zorgen dat de UI een observer wordt van het Spel
            spelLogica.spel.Subscribe(ui);
            ui.OverviewBordTekenen();
		}

		void VariantSpelKiezen()
		{
            uiSpelOpzetten.VariantKeuzeMenu();

            if (inputHandler.ChooseGame() == 1)
            {
                spelLogica.spel = new MankalaSpel();
                uiSpelOpzetten.VariantSpelKiezen(1);
                spelLogica.gameActive = true;
            }
            else if (inputHandler.ChooseGame() == 2)
            {
                spelLogica.spel = new WariSpel();
                uiSpelOpzetten.VariantSpelKiezen(2);
                spelLogica.gameActive = true;
            }
            else if (inputHandler.ChooseGame() == 3)
            {
                spelLogica.spel = new VariantSpel();
                uiSpelOpzetten.VariantSpelKiezen(3);
                spelLogica.gameActive = true;
            }
            else
            {
                // ongeldige keuze
                uiSpelOpzetten.VariantSpelKiezen(0);
            }
        }

        public static void Main()
        {
            SpelOpzetten spel = new SpelOpzetten();

            //spel.VariantSpelKiezen();

            //UserInterface ui = new ConsoleUI(spel.spelLogica.spel);
            //ui.TekenBord();

            spel.spelLogica.RunGame();
        }
    }
}

