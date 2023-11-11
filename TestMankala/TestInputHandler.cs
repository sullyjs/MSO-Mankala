﻿using System;
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
            int gekozenKuiltje = inputHandler.GekozenKuiltje;
            Assert.Equal(-1, gekozenKuiltje);
        }

        [Fact]
        public void IfKeyPressed_GekozenKuiltje()
        {
            ConsoleKeyInfo keyInfo = new ConsoleKeyInfo('1', ConsoleKey.D1, false, false, false);
            inputHandler.IfKeyPressed(keyInfo);
            Assert.Equal(1, inputHandler.GekozenKuiltje);
        }

        [Fact]
        public void ChooseGame_TESTA()
        {
            ConsoleKeyInfo keyInfo = new ConsoleKeyInfo('A', ConsoleKey.A, false, false, false);
            int result = inputHandler.ChooseGame(keyInfo);
            Assert.Equal(1, result);
        }

    }
}

