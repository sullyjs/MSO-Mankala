using System;
using MSO2;

namespace TestMankala
{

    //fix errors
	public class TestInputHandler
	{
        UserInputHandler inputHandler;

        public TestInputHandler()
		{
            // Arrange
            inputHandler = UserInputHandler.GetInstance();
        }

        [Fact]
        public void GekozenKuiltjeDefaultValueIsMinusOne()
        {
            UserInputHandler inputHandler2 = UserInputHandler.GetInstance();
            inputHandler2.gekozenKuiltje = inputHandler.defaultGetal;
            int gekozenKuiltje = inputHandler2.gekozenKuiltje;
            Assert.Equal(-1, gekozenKuiltje);
        }

        [Fact]
        public void IfKeyPressed_GekozenKuiltje()
        {
            inputHandler.keyInfo = new ConsoleKeyInfo('1', ConsoleKey.D1, false, false, false);
            inputHandler.HandleUserInput();

            // Assert
            Assert.Equal(1, inputHandler.GekozenKuiltje);
            inputHandler.gekozenKuiltje = inputHandler.defaultGetal;
        }

        [Fact]
        public void ChooseGame_TEST1()
        {
            UserInputHandler inputHandler3 = UserInputHandler.GetInstance();
            var input = new StringReader("A");
            Console.SetIn(input);
            int result = inputHandler3.ChooseGame();
            Assert.Equal(1, result);
        }

    }
}

