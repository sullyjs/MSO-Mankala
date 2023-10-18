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
            if (HuidigeSpeler == 2)
            {
                gekozenKuiltje += 6; //gekozenKuiltje voor player 2
            }

            Console.WriteLine("Het gekozen kuiltje:" + gekozenKuiltje);
            int steentjesOmTeVerdelen = 0;

            if ((HuidigeSpeler == 1 && gekozenKuiltje >= 1 && gekozenKuiltje <= bord.kuiltjesSpeler1.Length) ||
        (HuidigeSpeler == 2 && gekozenKuiltje >= 7 && gekozenKuiltje <= 6 + bord.kuiltjesSpeler2.Length))
            {
                if (HuidigeSpeler == 1)
                {
                    steentjesOmTeVerdelen = bord.kuiltjesSpeler1[gekozenKuiltje - 1].NeemStenen();
                }
                else if (HuidigeSpeler == 2)
                {
                    steentjesOmTeVerdelen = bord.kuiltjesSpeler2[gekozenKuiltje - 7].NeemStenen();
                }
            }
            else
            {
                // not in bounds error, check waarom
                Console.WriteLine("Invalid choice of kuiltje:" + gekozenKuiltje);      
            }

            int currentIndex = gekozenKuiltje - 1; // start vanaf het gekozen kuiltje
            while (steentjesOmTeVerdelen > 0) //plaats stenen in volgende kuiltjes
            {
                currentIndex = (currentIndex + 1) % 14; //14 kuiltjes in totaal (6 per speler)
                if ((currentIndex == 6 && HuidigeSpeler == 2) || (currentIndex == 13 && HuidigeSpeler == 1)) // skip tegenspeler thuiskuiltje
                {
                    continue;
                }
                //plaats een steen in het juiste kuiltje
                if (currentIndex < 6)
                {
                    bord.kuiltjesSpeler1[currentIndex].VoegSteenToe();
                }
                else if (currentIndex < 13)
                {
                    bord.kuiltjesSpeler2[currentIndex - 7].VoegSteenToe();
                }
                else //als laatste steentje om te geven thuiskuiltje is, geef een extra beurt
                {
                    HuidigeSpeler = HuidigeSpeler == 1 ? 1 : 2; 
                }
                steentjesOmTeVerdelen--;
            }

            for (int i = 0; i < 6; i++) //status van elke kuiltje nadat steentjes zijn gestrooit
            {
                Console.WriteLine($"Kuiltje {i + 1} (Speler 1): {bord.kuiltjesSpeler1[i].GetSteenAantal()}");
                Console.WriteLine($"Kuiltje {i + 7} (Speler 2): {bord.kuiltjesSpeler2[i].GetSteenAantal()}");
            }
        }

        protected override void Zet()
        {
            Console.WriteLine("HuidigeSpeler " + HuidigeSpeler + " doet een zet");
            if (HuidigeSpeler == 1)
            {
                Strooien();
                HuidigeSpeler = 2;
            }
            else
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

