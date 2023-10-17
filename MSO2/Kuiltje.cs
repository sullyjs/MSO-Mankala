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

		public bool CheckLeeg()
		{
			return Steentjes == 0;
		}

		public void SteentjesVeranderen(int veranderen)
		{
			Steentjes += veranderen;
		}
    }
}

