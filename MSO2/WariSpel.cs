using System;
using System.Diagnostics.Metrics;

namespace MSO2
{
    public class WariSpel : Spel
    {

        WariBord bord = new WariBord();

        public override void Strooien()
        {
            Kuiltje[] huidigeKuiltje = bord.kuiltjesSpeler1;

                if (HuidigeSpeler == 1)
                {
                    Console.WriteLine("\nGekozen kuiltje:" + gekozenKuiltje);
                }
                else if (HuidigeSpeler == 2)
                {
                    Console.WriteLine("\nGekozen kuiltje:" + (gekozenKuiltje + 7));
                    huidigeKuiltje = bord.kuiltjesSpeler2;
                }

            if (gekozenKuiltje < 1 || gekozenKuiltje > 6 || gekozenKuiltje == 7 || huidigeKuiltje[gekozenKuiltje - 1].CheckLeeg())
            {
                Console.WriteLine("Ongeldige keuze. Beurt gaat naar de volgende."); //denk aan een betere oplossing!! in interface
                return;
            }

            int stenenInHand = huidigeKuiltje[gekozenKuiltje - 1].NeemStenen();
            int kuiltjes = gekozenKuiltje;

            for (int i = 0; i < stenenInHand || (stenenInHand == 0 && huidigeKuiltje[kuiltjes - 1].GetSteenAantal() > 0); i++) //verdeel de steentjes
            {
                kuiltjes++; //cirkel door de kuiltjes, elke kant 0-5
                if (kuiltjes == 6)
                {
                    kuiltjes = 0;
                }
                    // anders voeg een steentje toe
                huidigeKuiltje[kuiltjes - 1].VoegSteenToe(1);
            }

            gekozenKuiltje = kuiltjes; //geef laatste kuiltje en kant c mee
            PrintStatus(); //status van elk kuiltje
        }

        private void PrintStatus()
        {
            for (int i = 0; i < 6; i++) // Status van elke kuiltje nadat steentjes zijn gestrooid
            {
                Console.WriteLine($"Kuiltje {i + 1} (Speler 1): {bord.kuiltjesSpeler1[i].GetSteenAantal()}");
            }
            Console.WriteLine("\n");
            for (int i = 0; i < 6; i++) // Status van elke kuiltje nadat steentjes zijn gestrooid
            {
                Console.WriteLine($"Kuiltje {i + 8} (Speler 2): {bord.kuiltjesSpeler2[i].GetSteenAantal()}");
            }
            Console.WriteLine("\nThuiskuiltje Speler 1: " + bord.verzamelkuiltjeSpeler1.GetSteenAantal());
            Console.WriteLine("Thuiskuiltje Speler 2: " + bord.verzamelkuiltjeSpeler2.GetSteenAantal() + "\n");
        }


        protected override void Zet()
        {
            Console.WriteLine("\nSpeler " + HuidigeSpeler + " doet een zet.");
            Strooien();

            int laatsteKuiltjeIndex = gekozenKuiltje;
            //Kuiltje[] huidigkuiltje = bord.kuiltjesSpeler1;
            Kuiltje[] tegenstanderkuiltje = bord.kuiltjesSpeler2;
            Kuiltje huidigVerzamelkuiltje = bord.verzamelkuiltjeSpeler1;
            if (HuidigeSpeler == 2)
            {
                //huidigkuiltje = bord.kuiltjesSpeler2;
                tegenstanderkuiltje = bord.kuiltjesSpeler1;
                huidigVerzamelkuiltje = bord.verzamelkuiltjeSpeler2;
            }

            if (tegenstanderkuiltje[laatsteKuiltjeIndex].Steentjes == 2 || tegenstanderkuiltje[laatsteKuiltjeIndex].Steentjes == 3)
            {
                Console.WriteLine("2 of 3 steentjes in kuiltje.");
                huidigVerzamelkuiltje.Steentjes += tegenstanderkuiltje[laatsteKuiltjeIndex].Steentjes; //voeg stenen toe aan mijn verzamelkuiltje
                tegenstanderkuiltje[laatsteKuiltjeIndex].Steentjes = 0; //leeg de stenen van dat kuiltje
            }

            PrintStatus(); //status van elk kuiltje
            WisselSpeler();

         }
    

        protected override bool NogEenZet() //now we always override, now we return false becuase we dont use this method anywhwere
        {
            return false;
        }

        internal override bool IsGameOver()
        {

            Kuiltje[] huidigeKuiltje = bord.kuiltjesSpeler1;
            if (HuidigeSpeler == 2)
            {
                huidigeKuiltje = bord.kuiltjesSpeler2;
            }

            for (int i = 0; i < 6; i++) //check if every kuiltje of a player is empty
            {
                if(huidigeKuiltje[i].CheckLeeg() == true)
                {
                    continue; //its empty, continue with the loop
                } else
                {
                    return false; //its not empty, so its not gameover
                }
            }
            //een speler geen zet kan doen doordat deze geen stenen meer heeft, eindigt het spel
            return true;
        }

        internal override void DeterMineWinner() //make simpler
        {
            int winnaar = bord.Winnaar();

            if (winnaar == 0)
            {
                Console.WriteLine("gelijkspel");
            }
            else if (winnaar == 1)
            {
                Console.WriteLine("Speler 1 heeft gewonnen");
            }
            else
            {
                Console.WriteLine("Speler 2 heeft gewonnen");
            }
        }
    }
}

