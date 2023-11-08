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

        protected abstract void Zet();

        internal abstract bool IsGameOver();

        internal abstract void DeterMineWinner();

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

