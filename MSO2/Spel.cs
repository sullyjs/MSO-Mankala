using System;
namespace MSO2
{
    abstract public class Spel
    {

        public Spel()
        {

        }

        public abstract void Speel();

        public abstract void Strooien();

        protected abstract void Zet();

        protected abstract bool NogEenZet();

        protected abstract bool IsGameOver();

        protected abstract void DeterMineWinner();


    }
}

