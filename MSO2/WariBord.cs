﻿using System;
namespace MSO2
{
    public class WariBord : Spelbord
    {

        const int aantalKuiltjes = 6;
        const int steentjes = 4;

        public WariBord() : base(aantalKuiltjes, steentjes, false)
        {

            
        }

        public override int Winnaar()
        {
            // 1 is speler 1, 2 is speler 2, 0 is gelijkspel

            if (verzamelkuiltjeSpeler1.Steentjes > verzamelkuiltjeSpeler2.Steentjes)
            {
                return 1;
            }
            else if (verzamelkuiltjeSpeler1.Steentjes < verzamelkuiltjeSpeler2.Steentjes)
            {
                return 2;
            }
            else
            {
                return 0;
            }
        }
    }
}

