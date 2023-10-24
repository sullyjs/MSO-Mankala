using System;
namespace MSO2
{
    class SpelUitvoeren
    {

        internal Spel spel;
        UserInputHandler inputHandler = UserInputHandler.GetInstance();
        internal bool gameActive;

        public SpelUitvoeren()
        {
            gameActive = false;
        }

        public void RunGame()
        {
            while (gameActive)
            {

                inputHandler.IfKeyPressed();
                int gekozenKuiltje = inputHandler.GekozenKuiltje;

                if (gekozenKuiltje != -1)
                {
                    spel.gekozenKuiltje = gekozenKuiltje;
                    spel.Speel();

                    if (spel.IsGameOver())
                    {
                        spel.DeterMineWinner();
                        gameActive = false;
                        Console.WriteLine("Game Over!");
                    }
                } 

             }

        }
    }
}