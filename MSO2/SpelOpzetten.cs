using System;
namespace MSO2
{
	public class SpelOpzetten
	{
        SpelUitvoeren spelLogica;
        UserInputHandler inputHandler = UserInputHandler.GetInstance();

        public SpelOpzetten()
		{
            spelLogica = new SpelUitvoeren();
		}

		void VariantSpelKiezen()
		{
            Console.WriteLine("Welcome to a new game of mankala: choose A to play classic mankala, and B for a variant.");

            if (inputHandler.ChooseGame() == 1)
            {
                spelLogica.spel = new MankalaSpel();
                Console.WriteLine("\nYou've created a new game of classic Mankala!");
                spelLogica.spel.DrawMancalaBoard();
                spelLogica.gameActive = true;
            }
            else if (inputHandler.ChooseGame() == 2)
            {
                spelLogica.spel = new VariantSpel();
                Console.WriteLine("\nThis is a variant game mode that isn't implemented yet.");
                spelLogica.gameActive = true;
            }
            else if (inputHandler.ChooseGame() == 3)
            {
                spelLogica.spel = new WariSpel();
                Console.WriteLine("\nThis is Wari.");
                spelLogica.spel.DrawMancalaBoard();
                spelLogica.gameActive = true;
            }
            else
            {
                Console.WriteLine("invalid choice. escaping program..");
            }
        }

        public static void Main()
        {
            SpelOpzetten spel = new SpelOpzetten();

            spel.VariantSpelKiezen();

            spel.spelLogica.RunGame();
        }
    }
}

