using System;
namespace MSO2
{
    public class MankalaSpel : Spel
    {

        MankalaBord bord = new MankalaBord();
        private int HuidigeSpeler;
        private Kuiltje[] huidigeKant;
        bool NogEenZetWordtGedaan;

        public MankalaSpel()
        {
            HuidigeSpeler = 1;
            NogEenZetWordtGedaan = false;
            huidigeKant = bord.kuiltjesSpeler1;
            bord = new MankalaBord();
        }

        public override void Speel()
        {
            Zet();
            Console.WriteLine("Het is speler" + HuidigeSpeler + " beurt.");
        }

        public override void Strooien()
        {
            Kuiltje[] huidigeKuiltje = bord.kuiltjesSpeler1;

            if (NogEenZetWordtGedaan)
            {
                huidigeKuiltje = huidigeKant;
            }
            else
            {
                if (HuidigeSpeler == 1)
                {
                    Console.WriteLine("\nGekozen kuiltje:" + gekozenKuiltje);
                }
                else if (HuidigeSpeler == 2)
                {
                    Console.WriteLine("\nGekozen kuiltje:" + (gekozenKuiltje + 7));
                    huidigeKuiltje = bord.kuiltjesSpeler2;
                }
            }

            if (gekozenKuiltje < 1 || gekozenKuiltje > 6 || gekozenKuiltje == 7 || huidigeKuiltje[gekozenKuiltje - 1].CheckLeeg())
            {
                Console.WriteLine("Ongeldige keuze. Beurt gaat door."); //denk aan een betere oplossing!!
                return;
            }

            int stenenInHand = huidigeKuiltje[gekozenKuiltje - 1].NeemStenen();
            int kuiltjes = gekozenKuiltje;

            for (int i = 0; i < stenenInHand || (stenenInHand == 0 && huidigeKuiltje[kuiltjes - 1].GetSteenAantal() > 0); i++) //verdeel de steentjes
            {
                kuiltjes++; //cirkel door de kuiltjes, elke kant 1-6

                if (kuiltjes == 0 && HuidigeSpeler == 2)
                {
                    // bij thuiskuiltje player 2
                    bord.thuiskuiltjeSpeler2.VoegSteenToe();
                }
                else if (kuiltjes == 7) {

                    if (HuidigeSpeler == 1 && huidigeKant == bord.kuiltjesSpeler1)
                    {
                        // bij thuiskuiltje player 1
                        bord.thuiskuiltjeSpeler1.VoegSteenToe();
                        huidigeKuiltje = bord.kuiltjesSpeler2;
                    } 

                    //skip kuiltjes
                    if (HuidigeSpeler == 1 && huidigeKant == bord.kuiltjesSpeler2)
                    {
                        huidigeKuiltje = bord.kuiltjesSpeler1;
                        i--;
                    }
                    if (HuidigeSpeler == 2 && huidigeKant == bord.kuiltjesSpeler1)
                    {
                        huidigeKuiltje = bord.kuiltjesSpeler2;
                        i--;
                    }

                    if (HuidigeSpeler == 2 && huidigeKant == bord.kuiltjesSpeler2)
                    {
                        // bij thuiskuiltje player 2
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

            gekozenKuiltje = kuiltjes; //geef laatste kuiltje en kant c mee
            huidigeKant = huidigeKuiltje;
            NogEenZetWordtGedaan = false;           
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
            Console.WriteLine("\nThuiskuiltje Speler 1: " + bord.thuiskuiltjeSpeler1.GetSteenAantal());
            Console.WriteLine("Thuiskuiltje Speler 2: " + bord.thuiskuiltjeSpeler2.GetSteenAantal() + "\n");
        }

        protected override void Zet()
        {
            Console.WriteLine("\nSpeler " + HuidigeSpeler + " doet een zet.");
            Strooien();

            if (gekozenKuiltje != 0) //check of t in thuiskuiltje beland
            {
                if (NogEenZet())
                {
                    Zet(); // als speler nog een zet kan doen, doe nog een zet
                }

                if (HuidigeSpeler == 1)
                {
                    HuidigeSpeler = 2;
                }
                else if (HuidigeSpeler == 2)
                {
                    HuidigeSpeler = 1;
                }
            }
            else //dan wisselen we niet van speler
            {
                Console.WriteLine("Steentje in eigen thuiskuiltje! Je mag nog een zet doen.");
                return;
            }
        }

        protected override bool NogEenZet()
        {
            // laatste plaats van steentje
            int laatsteKuiltjeIndex = gekozenKuiltje;
            Kuiltje[] huidigkuiltje = bord.kuiltjesSpeler1;
            if (HuidigeSpeler == 2)
            {
                huidigkuiltje = bord.kuiltjesSpeler2;
            }

            //kuiltje is niet leeg, ga verder me de beurt
            if (!huidigkuiltje[laatsteKuiltjeIndex - 1].CheckLeeg()) {
                Console.WriteLine("Steentje in een niet lege kuiltje! We gaan door.");
                NogEenZetWordtGedaan = true;
                return true;
            }

            //steentje in leeg kuiltje van de tegenspeler
            if (bord.kuiltjesSpeler1[laatsteKuiltjeIndex - 1].CheckLeeg() && HuidigeSpeler == 2)
            {
                Console.WriteLine("Steentje in een leeg kuiltje van de tegenstander.");
                return false;
                
            }
            if (bord.kuiltjesSpeler2[laatsteKuiltjeIndex - 1].CheckLeeg() && HuidigeSpeler == 1)
            {
                Console.WriteLine("Steentje in een leeg kuiltje van de tegenstander.");
                return false;
            }

            // mag niet nog een zet doen
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

