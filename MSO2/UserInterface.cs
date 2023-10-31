using System;
namespace MSO2
{
	public abstract class UserInterface
	{
		protected Spel spel;

		public UserInterface(Spel huidigeSpel)
		{
			spel = huidigeSpel;
		}

		public abstract void TekenBord();

		public abstract void TekenSpelerKant(int speler);

		public abstract void TekenThuiskuiltje();
        public abstract void TekenVerzamelkuiltje();
    }
}

