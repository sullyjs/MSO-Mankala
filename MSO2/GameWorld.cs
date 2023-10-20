using System;
namespace MSO2
{
    class GameWorld
    {

        Spel mankalaspel;
        UserInputHandler inputHandler = UserInputHandler.GetInstance();
        bool gameActive;

        protected GameWorld()
        {
            gameActive = false;
        }

        public void RunGame()
        {

            Console.WriteLine("Welcome to a new game of mankala: choose A to play classic mankala, and B for a variant.");

            if (inputHandler.ChooseGame() == 1)
            {
                mankalaspel = new MankalaSpel();
                Console.WriteLine("\nYou've created a new game of classic Mankala!");
                Console.WriteLine("Gebruik de nummers 1-6 op de keyboard voor beide spelers. Zie 1 als 8, 2 als 9 etc voor speler 2.");
                Console.WriteLine("Kuiltje 0 en 7 werken als thuiskuiltjes.");
                gameActive = true;
            } else if (inputHandler.ChooseGame() == 2)
            {
                mankalaspel = new VariantSpel();
                Console.WriteLine("\nthis is a variant game mode that isn't implemented yet.");
                gameActive = true;
            } else
            {
                 Console.WriteLine("invalid choice.");
            }

            while (gameActive)
            {

                inputHandler.IfKeyPressed();
                int gekozenKuiltje = inputHandler.GekozenKuiltje;

                if (gekozenKuiltje != -1)
                {
                    mankalaspel.gekozenKuiltje = gekozenKuiltje;

                    mankalaspel.Speel();

                    if (mankalaspel.IsGameOver())
                    {
                        mankalaspel.DeterMineWinner();
                        gameActive = false;
                        Console.WriteLine("Game Over!");
                    }
                } 

             }

            }

        public static void Main()
        {
            GameWorld game = new GameWorld();
            game.RunGame();
        }

    }
}