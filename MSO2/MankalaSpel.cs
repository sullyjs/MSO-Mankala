using System;
namespace MSO2
{
    public class MankalaSpel : Spel
    {       
        private Kuiltje[] huidigeKant;
        bool NogEenZetWordtGedaan;

        public MankalaSpel()
        {
            bord = new MankalaBord();
            NogEenZetWordtGedaan = false;
            huidigeKant = bord.kuiltjesSpeler1;
            ui = new ConsoleUI(bord);
        }

        public override void Strooien()
        {
            Kuiltje[] huidigeKuiltje = bord.kuiltjesSpeler1;

            //determine welk kuiltje we gebruiken voor t strooien
            if (NogEenZetWordtGedaan)
            {
                huidigeKuiltje = huidigeKant;
            }
            else
            {
                if (HuidigeSpeler == 1)
                {
                    ui.GekozenKuiltje(gekozenKuiltje);
                }
                else if (HuidigeSpeler == 2)
                {
                    ui.GekozenKuiltje(gekozenKuiltje);
                    huidigeKuiltje = bord.kuiltjesSpeler2;
                }
            }

            //is het gekozen kuiltje leeg of niet een kuiltje die mag worden gekozen?
            if (gekozenKuiltje < 1 || gekozenKuiltje > 6 || gekozenKuiltje == 7 || huidigeKuiltje[gekozenKuiltje - 1].CheckLeeg())
            {
                Console.WriteLine("Ongeldige keuze. Beurt gaat naar de volgende."); //denk aan een betere oplossing!!
                return;
            }

            //pak de stenen op
            int stenenInHand = huidigeKuiltje[gekozenKuiltje - 1].NeemStenen();
            int kuiltjes = gekozenKuiltje;

            for (int i = 0; i < stenenInHand || (stenenInHand == 0 && huidigeKuiltje[kuiltjes - 1].GetSteenAantal() > 0); i++) //verdeel de steentjes
            {
                kuiltjes++; //cirkel door de kuiltjes, elke kant 1-6

                if (kuiltjes == 0 && HuidigeSpeler == 2 && bord.IsErEenThuisKuil == true)
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
                    if (HuidigeSpeler == 2 && huidigeKant == bord.kuiltjesSpeler2)
                    {
                        // bij thuiskuiltje player 2
                        bord.thuiskuiltjeSpeler2.VoegSteenToe();
                        huidigeKuiltje = bord.kuiltjesSpeler1;
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
            ui.TekenBord();
            //PrintStatus(); //status van elk kuiltje
        }


        protected override void Zet()
        {
            //Console.WriteLine("\nSpeler " + HuidigeSpeler + " doet een zet.");
            ui.HuidigeSpeler(HuidigeSpeler);
            Strooien();

            if (gekozenKuiltje != 0) //check of t in thuiskuiltje beland
            {
                if (NogEenZet())
                {
                    Zet(); // als speler nog een zet kan doen, doe nog een zet
                    return;
                }

                WisselSpeler();
            }
            else //dan wisselen we niet van speler
            {
                Console.WriteLine("Steentje in eigen thuiskuiltje! Speler" + HuidigeSpeler + " mag nog een zet doen.");
                return;
            }
        }

        protected override bool NogEenZet()
        {
            // laatste plaats van steentje
            int laatsteKuiltjeIndex = gekozenKuiltje;
            Kuiltje huidigThuiskuiltje = bord.thuiskuiltjeSpeler1;
            Kuiltje[] huidigkuiltje = bord.kuiltjesSpeler1;
            Kuiltje[] tegenstanderkuiltje = bord.kuiltjesSpeler2;
            if (HuidigeSpeler == 2)
            {
                huidigkuiltje = bord.kuiltjesSpeler2;
                tegenstanderkuiltje = bord.kuiltjesSpeler1;
                huidigThuiskuiltje = bord.thuiskuiltjeSpeler2;
            }

            //kuiltje is niet leeg, ga verder me de beurt
            if (!huidigkuiltje[laatsteKuiltjeIndex - 1].CheckLeeg()) {
                Console.WriteLine("Steentje in een niet lege kuiltje! We gaan door.");
                NogEenZetWordtGedaan = true;
                return true;
            }         

            // steentje landt in een leeg kuiltje van de speler -- DEZE FIXEN, de logica werkt op zich, maar niet helemaal.
            if (huidigkuiltje[laatsteKuiltjeIndex - 1].CheckLeeg())
            {
                // Check if the opposite pit across is not empty
                int tegenoverliggendKuiltjeIndex = laatsteKuiltjeIndex + 1; //symmetriek
                if (!tegenstanderkuiltje[tegenoverliggendKuiltjeIndex - 1].CheckLeeg())
                {
                    Console.WriteLine("Steentje in een leeg kuiltje, maar de tegenstander tegenover is niet leeg.");
                    huidigThuiskuiltje.Steentjes += tegenstanderkuiltje[tegenoverliggendKuiltjeIndex - 1].GetSteenAantal(); //voeg stenen toe aan mijn thuiskuiltje
                    tegenstanderkuiltje[tegenoverliggendKuiltjeIndex - 1].Steentjes = 0; //leeg de stenen van dat kuiltje
                    return false; //niet nog een zet
                }
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

            ui.Winnaar(winnaar);
        }

    }
}

