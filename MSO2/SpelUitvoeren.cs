using System;
namespace MSO2
{
    public class SpelUitvoeren
    {

        public Spel spel;
        UserInputHandler inputHandler = UserInputHandler.GetInstance();
        public bool gameActive;
        private UserInterface ui;

        public SpelUitvoeren()
        {
            gameActive = false;
        }

        public void RunGame()
        {
            ui = new ConsoleUI(spel);
            while (gameActive)
            {
                ui.KuiltjeKiezen();
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
                    }
                }
                else
                {
                    ui.VerkeerdKuiltjeInput();
                    ui.HuidigeSpeler();
                }

             }

        }
    }
}