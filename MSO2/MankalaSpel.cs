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
            bord = new MankalaBord();
        }

        public override void Speel()
        {
            Zet();
        }

        public override void Strooien()
        {
            Kuiltje[] huidigeKuiltje = bord.kuiltjesSpeler1;

            if (HuidigeSpeler == 1)
            {
                Console.WriteLine("\nGekozen kuiltje:" + gekozenKuiltje);
                if (gekozenKuiltje < 1 || gekozenKuiltje > 6 || gekozenKuiltje == 7 || bord.kuiltjesSpeler1[gekozenKuiltje - 1].CheckLeeg() )
                {
                    Console.WriteLine("Ongeldige keuze. Kies een ander kuiltje.");
                    return;
                }
            }
            else if (HuidigeSpeler == 2)
            {
                Console.WriteLine("\nGekozen kuiltje:" + (gekozenKuiltje + 7));
                huidigeKuiltje = bord.kuiltjesSpeler2;
            }

            int stenenInHand = huidigeKuiltje[gekozenKuiltje - 1].NeemStenen();
            int kuiltjes = gekozenKuiltje;

            for (int i = 0; i < stenenInHand; i++)
            {
                kuiltjes++;

                if (kuiltjes == 0 && HuidigeSpeler == 2)
                {
                    // bij thuiskuiltje player 2
                    bord.thuiskuiltjeSpeler2.VoegSteenToe();
                }
                else if (kuiltjes == 7) {

                    if (HuidigeSpeler == 1)
                    {
                        // bij thuiskuiltje player 1
                        bord.thuiskuiltjeSpeler1.VoegSteenToe();
                        huidigeKuiltje = bord.kuiltjesSpeler2;
                    }
                    if (HuidigeSpeler == 2)
                    {
                        // bij thuiskuiltje player 1
                        bord.thuiskuiltjeSpeler2.VoegSteenToe();
                        huidigeKuiltje = bord.kuiltjesSpeler1;
                    }
                    kuiltjes = 0;
                }
                else
                {
                    // anders voeg een steentje toe
                    huidigeKuiltje[kuiltjes - 1].VoegSteenToe(1);
                }
            }

            for (int i = 0; i < 6; i++) // Status van elke kuiltje nadat steentjes zijn gestrooid
            {
                Console.WriteLine($"Kuiltje {i + 1} (Speler 1): {bord.kuiltjesSpeler1[i].GetSteenAantal()}");
            }
            for (int i = 0; i < 6; i++) // Status van elke kuiltje nadat steentjes zijn gestrooid
            {
                Console.WriteLine($"Kuiltje {i + 8} (Speler 2): {bord.kuiltjesSpeler2[i].GetSteenAantal()}");
            }
            Console.WriteLine("Thuiskuiltje Speler 1: " + bord.thuiskuiltjeSpeler1.GetSteenAantal());
            Console.WriteLine("Thuiskuiltje Speler 2: " + bord.thuiskuiltjeSpeler2.GetSteenAantal());
        }

        protected override void Zet()
        {
            Console.WriteLine("\nHuidigeSpeler " + HuidigeSpeler + " doet een zet.");
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

            // laatste kuiltje
            int laatsteKuiltjeIndex = (gekozenKuiltje - 1 + gekozenKuiltje) % 14;

            // check of de laatste steen in het thuiskuiltje van de speler is
            if ((HuidigeSpeler == 1 && laatsteKuiltjeIndex == 6) || (HuidigeSpeler == 2 && laatsteKuiltjeIndex == 13))
            {
                return true;
            }

            //kijk of de laatste steen is terechtgekomen in een niet-lege kuil en niet in het thuiskuiltje van de speler
            if (HuidigeSpeler == 1 && laatsteKuiltjeIndex < 6 && laatsteKuiltjeIndex >= 0 &&
                !bord.kuiltjesSpeler1[laatsteKuiltjeIndex].CheckLeeg())
            {
                return true;
            }
            else if (HuidigeSpeler == 2 && laatsteKuiltjeIndex >= 7 && laatsteKuiltjeIndex < 13 &&
                !bord.kuiltjesSpeler2[laatsteKuiltjeIndex - 7].CheckLeeg())
            {
                return true;
            }

            // niet nog een zet
            return false;

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

