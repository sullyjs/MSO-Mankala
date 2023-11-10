using System;
namespace MSO2
{
    public class UUSpel : Spel
    {
        private Kuiltje[] huidigeKantKuiltjes;
        private int huidigeKant;

        int huidigeKuiltjeStrooien;

        int lengteSpelbord;

        //regels uu spel

        //5 kuiltjes per speler met 5 stenen per kuiltje
        //strooien tegen de klok in
        //laatste steen in kuiltje aan eigen kant: nog een zet
        //laatste steen in leeg kuiltje van tegenstander: nog een zet
        //einde: 1 speler heeft alle kuiltjes leeg
        //winnaar: speler met alle lege kuiltjes



        public UUSpel()
        {
            bord = new UUBordFactory().Spelbord;
            ui = new ConsoleUI(this);

            huidigeKantKuiltjes = bord.kuiltjesSpeler1;
            huidigeKant = 1;
            lengteSpelbord = bord.kuiltjesSpeler1.Length;
        }

        public override void Strooien()
        {
            ui.GekozenKuiltje();

            int stenenInHand = huidigeKantKuiltjes[gekozenKuiltje - 1].NeemStenen();
            huidigeKuiltjeStrooien = gekozenKuiltje;

            while(stenenInHand != 0)
            {
                // als aan het einde van de rij kuiltjes gekomen
                if (huidigeKuiltjeStrooien >= lengteSpelbord)
                {
                    if (huidigeKant == 1)
                    {
                        huidigeKantKuiltjes = bord.kuiltjesSpeler2;
                        huidigeKant = 2;
                    }
                    else
                    {
                        huidigeKantKuiltjes = bord.kuiltjesSpeler1;
                        huidigeKant = 1;
                    }

                    huidigeKuiltjeStrooien = 0;
                }

                huidigeKantKuiltjes[huidigeKuiltjeStrooien].VoegSteenToe(1);
                stenenInHand--;
                huidigeKuiltjeStrooien++;
            }

            // correcte index van laatste kuiltje, want door while loop 1 te hoog
            huidigeKuiltjeStrooien--;
        }

        protected override void Zet()
        {
            // check of de zet wel uitgevoerd mag worden
            if (!CheckValideZet(huidigeKantKuiltjes))
            {
                return;
            }

            ui.GekozenKuiltje();

            Strooien();

            // bord is veranderd, dus teken updates
            NotifySubscribers();

            // als er niet nog een zet gedaan wordt, wissel speler
            if (!NogEenZet())
            {
                WisselSpeler();
            }
        }

        internal override void WisselSpeler()
        {
            if (HuidigeSpeler == 1)
            {
                HuidigeSpeler = 2;
                huidigeKant = 2;
                huidigeKantKuiltjes = bord.kuiltjesSpeler2;
            }
            else
            {
                HuidigeSpeler = 1;
                huidigeKant = 1;
                huidigeKantKuiltjes = bord.kuiltjesSpeler1;
            }
        }

        protected override bool NogEenZet()
        {
            //laatste steen in eigen kuiltje
            if (HuidigeSpeler == 1 && huidigeKant == 1)
            {
                return true;
            }
            else if (HuidigeSpeler == 2 && huidigeKant == 2)
            {
                return true;
            }

            // laatste steen in leeg kuiltje van tegenstander:
            // check of er in het laatste kuiltje waarin is uitgestrooid 1 steen zit
            if (HuidigeSpeler == 1 && huidigeKant == 2 && huidigeKantKuiltjes[huidigeKuiltjeStrooien].CheckEenSteen())
            {
                //kant weer goed zetten voor speler
                huidigeKant = 1;
                huidigeKantKuiltjes = bord.kuiltjesSpeler1;
                return true;
            }
            else if (HuidigeSpeler == 2 && huidigeKant == 1 && huidigeKantKuiltjes[huidigeKuiltjeStrooien].CheckEenSteen())
            {
                //kant weer goed zetten voor speler
                huidigeKant = 2;
                huidigeKantKuiltjes = bord.kuiltjesSpeler2;
                return true;
            }

            return false;
        }

        internal override bool IsGameOver()
        {
            bool kuiltjesSpeler1Leeg = bord.kuiltjesSpeler1.All(k => k.CheckLeeg());
            bool kuiltjesSpeler2Leeg = bord.kuiltjesSpeler2.All(k => k.CheckLeeg());

            if (kuiltjesSpeler1Leeg || kuiltjesSpeler2Leeg)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}

