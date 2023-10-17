using System;
using System.Reflection;
using System.Windows.Forms;

namespace MSO2
{
	class UserInputHandler
	{
        
        private static UserInputHandler _instance;
        private static readonly object _instanceLock = new object();
        public UserInputHandler()
        {
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

        //maybe add bool to see who's turn it is?? -- add reference or use currentplayer
        private void IfKeyPressed(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                HandleUserInput();
            }
            if (e.KeyCode == Keys.Space)
            {
                HandleUserInput();
            }
        }

        private void HandleUserInput()
        {
            Console.WriteLine("Enter key pressed, handling user input...");
        }




    }
}


