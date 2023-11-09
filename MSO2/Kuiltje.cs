using System;
namespace MSO2
{
	public class Kuiltje
	{
		private int _steentjes;
		public int Steentjes
		{
			get
			{
				return _steentjes;
			}
			set
			{
				// Hoeveelheid steentjes in een kuiltje kan niet negatief zijn
				if (value < 0)
				{
                    throw new Exception("Aantal steentjes in kuiltje mag niet minder dan 0 zijn.");
                }
				else
				{
					_steentjes = value;
				}
			}
		}

		public Kuiltje(int steentjes)
        {
            Steentjes = steentjes;
		}

        public int NeemStenen()
        {
            int steentjesInKuiltje = Steentjes;
            Steentjes = 0; //Leeg het kuiltje van stenen
            return steentjesInKuiltje;
        }

        public void VoegSteenToe(int voegSteentjeToe = 1)
        {
            Steentjes += voegSteentjeToe;
        }

        public int GetSteenAantal()
        {
            return Steentjes;
        }

        public bool CheckLeeg()
		{
			return Steentjes == 0;
		}

		public bool CheckEenSteen()
		{
			return Steentjes == 1;
		}
    }
}

