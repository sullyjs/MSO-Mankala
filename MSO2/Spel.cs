using System;
namespace MSO2
{
    abstract public class Spel
    {
        public int gekozenKuiltje;
        public int HuidigeSpeler;
        public Spelbord bord;
        protected UserInterface ui;
        protected List<UserInterface> subscribers = new();

        private Kuiltje[] huidigeKantKuiltjes;
        private int huidigeKant;
        int huidigeKuiltjeStrooien;
        int lengteSpelbord;

        public Spel()
        {
            HuidigeSpeler = 1;
        }

        internal virtual void WisselSpeler()
        {
            if (HuidigeSpeler == 1)
                {
                    HuidigeSpeler = 2;
                }
                else if (HuidigeSpeler == 2)
                {
                    HuidigeSpeler = 1;
                }
        }

        public virtual void Speel()
        {
            Zet();
            ui.HuidigeSpeler();
        }

        public abstract void Strooien();

        public void StrooienZonderThuisKuiltjes()
        {
            ui.GekozenKuiltje();

            int stenenInHand = huidigeKantKuiltjes[gekozenKuiltje - 1].NeemStenen();
            huidigeKuiltjeStrooien = gekozenKuiltje;

            while (stenenInHand != 0)
            {
                // als aan het einde van de rij kuiltjes gekomen
                if (huidigeKuiltjeStrooien >= huidigeKantKuiltjes.Length)
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

        protected abstract void Zet();

        internal abstract bool IsGameOver();

        internal void DeterMineWinner()
        {
            int winnaar = bord.Winnaar();

            ui.Winnaar(winnaar);
        }

        protected abstract bool NogEenZet();

        //check of het gekozen kuiltje niet leeg is
        protected bool CheckValideZet(Kuiltje[] huidigeKuiltje)
        {
            if (gekozenKuiltje < 1 || gekozenKuiltje > 6 || huidigeKuiltje[gekozenKuiltje - 1].CheckLeeg())
            {
                ui.VerkeerdKuiltjeInput();
                gekozenKuiltje = -1;
                return false;
            }

            return true;
        }


        // Observer Pattern
        public void Subscribe(UserInterface sub)
        {
            subscribers.Add(sub);
        }

        public void NotifySubscribers()
        {
            foreach (UserInterface sub in subscribers)
            {
                sub.Update();
            }
        }
    }
}

