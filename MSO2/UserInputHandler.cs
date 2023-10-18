using System;
using System.Reflection;
using System.Windows.Input;


namespace MSO2
{
    public class UserInputHandler
    {
        public static UserInputHandler _instance;
        public static readonly object _instanceLock = new object();
        ConsoleKeyInfo keyInfo;
        public Spel mankala;
        public UserInputHandler()
        {

        }

        public int gekozenKuiltje = -1; //begin met een invalid getal

        public int GekozenKuiltje
        {
            get { return gekozenKuiltje; }
        }


        public static UserInputHandler GetInstance() //create an instance
        {
            if (_instance == null)
            {
                lock (_instanceLock)
                {
                    if (_instance == null)
                    {
                        _instance = new UserInputHandler();
                    }
                }
            }
            return _instance;
        }

        public void IfKeyPressed()
        {
            keyInfo = Console.ReadKey();
            HandleUserInput();

            //  if (keyInfo.Key == ConsoleKey.A)
            //   {
            //        mankala = new MankalaSpel();

            //       Console.WriteLine("You've created a new game of Mankala! It is player 1's turn, choose which of your holes you wanna use, by clicking a number 1-6.");

            //       HandleUserInput();

            //   }

            if (mankala is VariantSpel)
            {
                Console.WriteLine("this is a variant game mode that isn't implemented yet.");
            }
        }

          //  } else if (mankala is null)
         //   {
       //         Console.WriteLine("Wtf you doin");
       //     }
        

        public void HandleUserInput()
        {
            if (keyInfo.Key == ConsoleKey.NumPad1 || keyInfo.Key == ConsoleKey.D1)
            {
                gekozenKuiltje = 1;
            }
            if (keyInfo.Key == ConsoleKey.D2 || keyInfo.Key == ConsoleKey.D2)
            {
                gekozenKuiltje = 2;
            }
            if (keyInfo.Key == ConsoleKey.NumPad3 || keyInfo.Key == ConsoleKey.D3)
            {
                gekozenKuiltje = 3;
            }
            if (keyInfo.Key == ConsoleKey.NumPad4 || keyInfo.Key == ConsoleKey.D4)
            {
                gekozenKuiltje = 4;
            }
            if (keyInfo.Key == ConsoleKey.NumPad5 || keyInfo.Key == ConsoleKey.D5)
            {
                gekozenKuiltje = 5;
            }
            if (keyInfo.Key == ConsoleKey.NumPad6 || keyInfo.Key == ConsoleKey.D6)
            {
                gekozenKuiltje = 6;
            }

            
        }

    }
}