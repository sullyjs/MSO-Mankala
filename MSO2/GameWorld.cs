using System;
namespace MSO2
{
    class GameWorld
    {

        Spel mankalaspel = new MankalaSpel();
        UserInputHandler inputHandler = UserInputHandler.GetInstance();
        bool gameActive = true;

        protected GameWorld()
        {

        }

        public void RunGame()
        {

            //Console.WriteLine("Welcome to a new game of mankala: choose A to play classic mankala, and B for a variant.");
            Console.WriteLine("You've created a new game of Mankala! It is player 1's turn, choose which of your holes you wanna use, by clicking a number 1-6.");
            Console.WriteLine("Voor speler 1 zal de gekozen nummer 1 tot 6 worden gebruikt. Voor speler 2 ook, maar moet dit worden gezien als 1 is 7, 2 is 8, 3 is 9.. etc.");

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