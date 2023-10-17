﻿using System;
namespace MSO2
{
	public class Spelbord
	{
		Kuiltje[] kuiltjesSpeler1;
		Kuiltje[] kuiltjesSpeler2;
		int aantalKuiltjes;
		int steentjes;


        public Spelbord(int aantalKuiltjesPerSpeler, int steentjesPerKuiltje)
		{
			aantalKuiltjes = aantalKuiltjesPerSpeler;
			steentjes = steentjesPerKuiltje;
            kuiltjesSpeler1 = new Kuiltje[aantalKuiltjesPerSpeler];
			kuiltjesSpeler2 = new Kuiltje[aantalKuiltjesPerSpeler];

			for (int i = 0; i < aantalKuiltjesPerSpeler; i++)
			{
				Kuiltje k1 = new Kuiltje(steentjesPerKuiltje);
                Kuiltje k2 = new Kuiltje(steentjesPerKuiltje);

                kuiltjesSpeler1[i] = k1;
				kuiltjesSpeler2[i] = k2;
			}
		}
	}
}

