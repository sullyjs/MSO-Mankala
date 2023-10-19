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
            bool gameActive = false;
        }

        public void RunGame()
        {

            Console.WriteLine("Welcome to a new game of mankala: choose A to play classic mankala, and B for a variant.");

            if (inputHandler.ChooseGame() == 1)
            {
                mankalaspel = new MankalaSpel();
                Console.WriteLine("You've created a new game of Mankala!");
                Console.WriteLine("Voor speler 1 zal de gekozen nummer 1 tot 6 worden gebruikt. Voor speler 2 ook, maar moet dit worden gezien als 1 is 8, 2 is 9, 3 is 10.. etc.");
                Console.WriteLine("kuiltje 0 en 7 werken als thuiskuiltjes.");
                gameActive = true;
            } else if (inputHandler.ChooseGame() == 2)
            {
                mankalaspel = new VariantSpel();
                Console.WriteLine("this is a variant game mode that isn't implemented yet.");
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