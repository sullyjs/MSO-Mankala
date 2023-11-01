using System;
namespace MSO2
{
    abstract public class Spel
    {
        public int gekozenKuiltje;
        public int HuidigeSpeler;
        public Spelbord bord;
        protected ConsoleUI ui;

        public Spel()
        {
            HuidigeSpeler = 1;
        }

        internal virtual void WisselSpeler()
        {
            if(HuidigeSpeler == 1)
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
            ui.HuidigeSpeler(HuidigeSpeler);
        }

        public abstract void Strooien();

        protected abstract void Zet();

        internal abstract bool IsGameOver();

        internal abstract void DeterMineWinner();

        protected abstract bool NogEenZet();


    }
}

