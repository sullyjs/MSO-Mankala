using System;
namespace MSO2
{
    abstract public class Spel
    {
        public int gekozenKuiltje;

        public Spel()
        {

        }

        public abstract void Speel();

        public abstract void Strooien();

        protected abstract void Zet();

        protected abstract bool NogEenZet();

        internal abstract bool IsGameOver();

        internal abstract void DeterMineWinner();


    }
}

