using System;
namespace MSO2
{
    public class VariantSpel : Spel
    {
        bool NogEenZetWordtGedaan;
        private Kuiltje[] huidigeKant;

        //uu spel

        //5 kuiltjes elke speler
        //kuiltje in eigen kant: nog een zet
        //kuiltje in leeg kuiltje van tegenstander, nog een zet
        //anders ga door



        public VariantSpel()
        {
            bord = new VariantBord();
            huidigeKant = bord.kuiltjesSpeler1;
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
                    Console.WriteLine("\nGekozen kuiltje:" + (gekozenKuiltje + 5));
                    huidigeKuiltje = bord.kuiltjesSpeler2;
                }
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
                if (kuiltjes == 5) //wissel van kant?
                {
                    if (HuidigeSpeler == 1 && huidigeKant == bord.kuiltjesSpeler2)
                    {
                        huidigeKuiltje = bord.kuiltjesSpeler1;
                    }
                    if (HuidigeSpeler == 2 && huidigeKant == bord.kuiltjesSpeler1)
                    {
                        huidigeKuiltje = bord.kuiltjesSpeler2;
                    }
                    kuiltjes = 0;
                }
                // anders voeg een steentje toe
                huidigeKuiltje[kuiltjes - 1].VoegSteenToe(1);
            }

            huidigeKant = huidigeKuiltje;
            NogEenZetWordtGedaan = false;
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
        }

        protected override void Zet()
        {
            if (NogEenZet())
            {
                Zet(); // als speler nog een zet kan doen, doe nog een zet
                return;
            }

            WisselSpeler(); //wissel speler
        }

        protected override bool NogEenZet()
        {
            // laatste plaats van steentje
            int laatsteKuiltjeIndex = gekozenKuiltje;
            Kuiltje[] huidigkuiltje = bord.kuiltjesSpeler1;
            Kuiltje[] tegenstanderkuiltje = bord.kuiltjesSpeler2;
            if (HuidigeSpeler == 2)
            {
                huidigkuiltje = bord.kuiltjesSpeler2;
                tegenstanderkuiltje = bord.kuiltjesSpeler1;
            }

            //check eigen speler
            if (huidigkuiltje[laatsteKuiltjeIndex - 1].CheckLeeg())
            {

            }

            //steentje in leeg kuiltje van de tegenspeler
            if (bord.kuiltjesSpeler1[laatsteKuiltjeIndex - 1].CheckLeeg() && HuidigeSpeler == 2)
            {
                NogEenZetWordtGedaan = true;
                Console.WriteLine("Steentje in een leeg kuiltje van de tegenstander.");
                return true;

            }
            if (bord.kuiltjesSpeler2[laatsteKuiltjeIndex - 1].CheckLeeg() && HuidigeSpeler == 1)
            {
                NogEenZetWordtGedaan = true;
                Console.WriteLine("Steentje in een leeg kuiltje van de tegenstander.");
                return true;
            }

            // mag niet nog een zet doen
            return false;
        }

        internal override bool IsGameOver() //als aan 1 kant alle steentjes leeg zijn
        {
            Kuiltje[] huidigeKuiltje = bord.kuiltjesSpeler1;
            if (HuidigeSpeler == 2)
            {
                huidigeKuiltje = bord.kuiltjesSpeler2;
            }

            for (int i = 0; i < 6; i++) //check if every kuiltje of a player is empty
            {
                if (huidigeKuiltje[i].CheckLeeg() == true)
                {
                    continue; //its empty, continue with the loop
                }
                else
                {
                    return false; //its not empty, so its not gameover
                }
            }
            //een speler geen zet kan doen doordat deze geen stenen meer heeft, eindigt het spel
            return true;
        }

        internal override void DeterMineWinner()
        {
            Console.WriteLine("Winnaar beslist.");
        }

    }
}

