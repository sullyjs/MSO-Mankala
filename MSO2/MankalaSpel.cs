using System;
namespace MSO2
{
    public class MankalaSpel : Spel
    {

        MankalaBord bord = new MankalaBord();
        private int HuidigeSpeler;

        public MankalaSpel()
        {
            HuidigeSpeler = 1;
        }

        public override void Speel()
        {
            Zet();
        }

        public override void Strooien()
        {
            Kuiltje[] huidigeKuiltje = bord.kuiltjesSpeler1;
            Kuiltje thuisKuiltje = bord.thuiskuiltjeSpeler1;

            if (HuidigeSpeler == 1)
            {
                // Handle player 1's turn
                if (gekozenKuiltje < 1 || gekozenKuiltje > 6 || bord.kuiltjesSpeler1[gekozenKuiltje - 1].CheckLeeg())
                {
                    Console.WriteLine("Ongeldige keuze. Kies een ander kuiltje.");
                    return;
                }
            }
            else if (HuidigeSpeler == 2)
            {
                // Handle player 2's turn
                huidigeKuiltje = bord.kuiltjesSpeler2;
                thuisKuiltje = bord.thuiskuiltjeSpeler2;
                gekozenKuiltje += 6;
                if (gekozenKuiltje < 7 || gekozenKuiltje > 12 || bord.kuiltjesSpeler2[gekozenKuiltje - 7].CheckLeeg())
                {
                    Console.WriteLine("Ongeldige keuze. Kies een ander kuiltje.");
                    return;
                }
            }

            Console.WriteLine("Gekozen kuiltje:" + gekozenKuiltje);

            int aantalStenenInHand = huidigeKuiltje[gekozenKuiltje - 1].NeemStenen(); // Neem stenen uit het gekozen kuiltje
            int huidigeKuiltjeIndex = gekozenKuiltje - 1;

            while (aantalStenenInHand > 0)
            {
                huidigeKuiltjeIndex++; // Ga naar het volgende kuiltje

                // Als we het einde van speler 1's kuiltjes bereiken, ga naar speler 2's kuiltjes
                if (huidigeKuiltjeIndex == 6)
                {
                    huidigeKuiltjeIndex = 0; // Terug naar het begin van speler 1's kuiltjes
                }

                if (huidigeKuiltjeIndex == 6 && HuidigeSpeler == 2)
                {
                    huidigeKuiltjeIndex++; // Overslaan thuiskuiltje van speler 2
                }

                bord.kuiltjesSpeler1[huidigeKuiltjeIndex].VoegSteenToe(1); // Voeg een steen toe aan het kuiltje

                aantalStenenInHand--; // Verminder het aantal stenen in de hand
            }

            if (HuidigeSpeler == 1 && huidigeKuiltjeIndex == 6)
            {
                Console.WriteLine("Laatste steen in jouw thuiskuiltje! Je mag nog een keer.");
                return;
            }
            else if (HuidigeSpeler == 2 && huidigeKuiltjeIndex == 13)
            {
                Console.WriteLine("Laatste steen in jouw thuiskuiltje! Je mag nog een keer.");
                return;
            }

            for (int i = 0; i < 6; i++) // Status van elke kuiltje nadat steentjes zijn gestrooit
            {
                Console.WriteLine($"Kuiltje {i + 1} (Speler 1): {bord.kuiltjesSpeler1[i].GetSteenAantal()}");
                Console.WriteLine($"Kuiltje {i + 7} (Speler 2): {bord.kuiltjesSpeler2[i].GetSteenAantal()}");
            }
            Console.WriteLine("Thuiskuiltje Speler 1: " + bord.thuiskuiltjeSpeler1.GetSteenAantal()); //0 
            Console.WriteLine("Thuiskuiltje Speler 2: " + bord.thuiskuiltjeSpeler2.GetSteenAantal()); // 13
        }

        protected override void Zet()
        {
            Console.WriteLine("HuidigeSpeler " + HuidigeSpeler + " doet een zet");
            if (HuidigeSpeler == 1)
            {
                Strooien();
                HuidigeSpeler = 2;
            }
            else if (HuidigeSpeler == 2)
            {
                Strooien();
                HuidigeSpeler = 1;
            } 
        }

        protected override bool NogEenZet()
        {
            

            // Check if the last stone landed in a non-empty pit and not in the player's home pit
            if (true)
            {
                // Player can make another move
                return true;
            }
            else
            {
                // Player cannot make another move
                return false;
            }

            //als laatste kuiltje, de thuiskuiltje is, return true

            //laatste steen komt in een ander kuiltje dan het thuiskuiltje van de speler, en dat kuiltje was niet leeg. De speler pakt alle stenen in het kuiltje op, en gaat verder met de beurt


        }

        internal override bool IsGameOver()
        {
            return bord.CheckAlleKuiltjesLeeg();
        }

        internal override void DeterMineWinner()
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

