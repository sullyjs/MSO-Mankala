using System;
using System.Diagnostics.Metrics;

namespace MSO2
{
    public class WariSpel : Spel
    {
        private Kuiltje[] huidigeKantKuiltjes;
        private int huidigeKant;

        int huidigeKuiltjeStrooien;

        int lengteSpelbord;

        public WariSpel()
        {
            bord = new WariBordFactory().Spelbord;
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

            while (stenenInHand != 0)
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

            if (CheckOfStenenInVerzamelKuiltje())
            {
                StenenInVerzamelKuiltje();
            }

            // bord is veranderd, dus teken updates
            NotifySubscribers();

            // als er niet nog een zet gedaan wordt, wissel speler
            if (!NogEenZet())
            {
                WisselSpeler();
            }
        }

        private bool CheckOfStenenInVerzamelKuiltje()
        {
            // als laatste steen in kuiltje van tegenstander terecht is gekomen
            if ((HuidigeSpeler == 1 && huidigeKant == 2) || (HuidigeSpeler == 2 && huidigeKant == 1))
            {
                // als laatste kuiltje 2 of 3 stenen bevat
                if (huidigeKantKuiltjes[huidigeKuiltjeStrooien].Steentjes == 2 || huidigeKantKuiltjes[huidigeKuiltjeStrooien].Steentjes == 3)
                {
                    return true;
                }
            }

            return false;
        }

        private void StenenInVerzamelKuiltje()
        {
            int steentjes = huidigeKantKuiltjes[huidigeKuiltjeStrooien].NeemStenen();

            if (HuidigeSpeler == 1)
            {
                bord.verzamelkuiltjeSpeler1.VoegSteenToe(steentjes);
            }
            else
            {
                bord.verzamelkuiltjeSpeler1.VoegSteenToe(steentjes);
            }
        }

        public override void WisselSpeler()
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
    }
}

