using System;
using System.Diagnostics.Metrics;

namespace MSO2
{
    public class WariSpel : Spel
    {
        public WariSpel()
        {
            bord = new WariBord();
            ui = new ConsoleUI(this);
        }

        public override void Strooien()
        {
            Kuiltje[] huidigeKuiltje = bord.kuiltjesSpeler1;

                if (HuidigeSpeler == 1)
                {
                    ui.GekozenKuiltje();
                }
                else if (HuidigeSpeler == 2)
                {
                    ui.GekozenKuiltje();
                    huidigeKuiltje = bord.kuiltjesSpeler2;
                }

            if (!CheckValideZet(huidigeKuiltje))
            {
                return;
            }

            int stenenInHand = huidigeKuiltje[gekozenKuiltje - 1].NeemStenen();
            int kuiltjes = gekozenKuiltje;

            for (int i = 0; i < stenenInHand || (stenenInHand == 0 && huidigeKuiltje[kuiltjes - 1].GetSteenAantal() > 0); i++) //verdeel de steentjes
            {
                kuiltjes++; //cirkel door de kuiltjes, elke kant 0-5
                if (kuiltjes == 6)
                {
                    //FIX WISSELEN VAN KANT
                    kuiltjes = 0;
                }
                    // anders voeg een steentje toe
                huidigeKuiltje[kuiltjes - 1].VoegSteenToe(1);
            }

            gekozenKuiltje = kuiltjes; //geef laatste kuiltje en kant c mee
        }

        protected override void Zet()
        {
            //Console.WriteLine("\nSpeler " + HuidigeSpeler + " doet een zet.");
            Strooien();

            //als ongeldige zet
            if (gekozenKuiltje == -1)
            {
                return;
            }

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

            //spelbord is veranderd, dus doorgeven aan subscribers ui
            NotifySubscribers();
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
    }
}

