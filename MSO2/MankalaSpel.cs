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
            if ( (HuidigeSpeler == 1 && (gekozenKuiltje < 1 || gekozenKuiltje > 6)) || (HuidigeSpeler == 2 && (gekozenKuiltje < 7 || gekozenKuiltje > 12)) )
            {
                Console.WriteLine("Invalid move. Choose a valid kuiltje.");
                return; // Exit the method to prevent an invalid move
            }

            int kuiltjeIndex = (gekozenKuiltje == 0) ? 11 : gekozenKuiltje - 1; // Convert gekozenKuiltje (0 and 1-12) to array index (11 and 0-10)
            int aantalStenen = bord.kuiltjesSpeler1[kuiltjeIndex].NeemStenen(); // Take out all stones from gekozenKuiltje
            int speler = (HuidigeSpeler == 1) ? 1 : 2;
            int huidigeKuiltjeIndex = kuiltjeIndex;

            while (aantalStenen > 0)
            {
                huidigeKuiltjeIndex = (huidigeKuiltjeIndex + 1) % 12; // Move counter-clockwise
                if ((speler == 1 && huidigeKuiltjeIndex != 6) || (speler == 2 && huidigeKuiltjeIndex != 0))
                {
                    bord.kuiltjesSpeler1[huidigeKuiltjeIndex].VoegSteenToe(1);
                    aantalStenen--;
                }
            }

            // Check if the last stone landed in an empty kuiltje on the player's side
            if (speler == 1 && huidigeKuiltjeIndex < 6 && bord.kuiltjesSpeler1[huidigeKuiltjeIndex].GetSteenAantal() == 1)
            {
                int tegenovergesteldeIndex = 11 - huidigeKuiltjeIndex;
                int tegenovergesteldeStenen = bord.kuiltjesSpeler2[tegenovergesteldeIndex].NeemStenen();
                bord.thuiskuiltjeSpeler1.VoegSteenToe(1 + tegenovergesteldeStenen);
            }
            else if (speler == 2 && huidigeKuiltjeIndex > 5 && bord.kuiltjesSpeler2[huidigeKuiltjeIndex - 6].GetSteenAantal() == 1)
            {
                int tegenovergesteldeIndex = 11 - huidigeKuiltjeIndex;
                int tegenovergesteldeStenen = bord.kuiltjesSpeler1[tegenovergesteldeIndex].NeemStenen();
                bord.thuiskuiltjeSpeler2.VoegSteenToe(1 + tegenovergesteldeStenen);
            }

            for (int i = 0; i < 6; i++) // Status van elke kuiltje nadat steentjes zijn gestrooit
            {
                Console.WriteLine($"Kuiltje {i + 1} (Speler 1): {bord.kuiltjesSpeler1[i].GetSteenAantal()}");
                Console.WriteLine($"Kuiltje {i + 7} (Speler 2): {bord.kuiltjesSpeler2[i].GetSteenAantal()}");
            }
            Console.WriteLine("Thuiskuiltje Speler 1: " + bord.thuiskuiltjeSpeler1.GetSteenAantal());
            Console.WriteLine("Thuiskuiltje Speler 2: " + bord.thuiskuiltjeSpeler2.GetSteenAantal());
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
            if (true) {
                Console.WriteLine("Ik doe nog een zet");
                return true;

            }
            else
            {
                Console.WriteLine("Nope");
                return false;
            } 
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

