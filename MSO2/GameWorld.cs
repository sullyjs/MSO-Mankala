using System;
namespace MSO2
{
    class GameWorld
    {
        private GameWorld()
        {
            Spel mankalaspel;
            UserInputHandler inputhandler = UserInputHandler.GetInstance();

        }

        public void RunGame()
        {
            bool gameActive = true;

            while (gameActive)
            {
                //if (isgameover) -- determine winner, gameactive is false
                //otherwise, play mankalagame
                //choose what game to play with input handler?
            }
            //run mankala game version or sth
            
        }

        public static void Main()
        {
            GameWorld game = new GameWorld();
            game.RunGame();
        }

    }
}
