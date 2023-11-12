using System;
using System.Reflection;
using System.Windows.Input;


namespace MSO2
{
    public class UserInputHandler
    {
        public static UserInputHandler _instance;
        public static readonly object _instanceLock = new object();
        public ConsoleKeyInfo keyInfo;

        private int gekozenKuiltje = -1; //begin met een invalid getal

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
        }
        

        public void HandleUserInput()
        {
            if (keyInfo.Key == ConsoleKey.NumPad1 || keyInfo.Key == ConsoleKey.D1)
            {
                gekozenKuiltje = 1;
            }
            else if (keyInfo.Key == ConsoleKey.D2 || keyInfo.Key == ConsoleKey.D2)
            {
                gekozenKuiltje = 2;
            }
            else if (keyInfo.Key == ConsoleKey.NumPad3 || keyInfo.Key == ConsoleKey.D3)
            {
                gekozenKuiltje = 3;
            }
            else if (keyInfo.Key == ConsoleKey.NumPad4 || keyInfo.Key == ConsoleKey.D4)
            {
                gekozenKuiltje = 4;
            }
            else if (keyInfo.Key == ConsoleKey.NumPad5 || keyInfo.Key == ConsoleKey.D5)
            {
                gekozenKuiltje = 5;
            }
            else if (keyInfo.Key == ConsoleKey.NumPad6 || keyInfo.Key == ConsoleKey.D6)
            {
                gekozenKuiltje = 6;
            }
            else
            {
                gekozenKuiltje = -1;
            }
        }

        public int ChooseGame()
        {
            keyInfo = Console.ReadKey();

            if (keyInfo.Key == ConsoleKey.A)
            {
                return 1;
            }
            else if (keyInfo.Key == ConsoleKey.B)
            {
                return 2;
            }
            else if (keyInfo.Key == ConsoleKey.C)
            {
                return 3;
            }
            else return 0;
        }

    }
}