using System;
namespace MSO2
{
    public class VariantSpel : Spel
    {

        VariantBord bord = new VariantBord();
        private int HuidigeSpeler;

        public VariantSpel()
        {
            HuidigeSpeler = 1;
        }

        public override void Speel()
        {
            Console.WriteLine("Ik speel de variant.");
        }

        public override void Strooien()
        {
            Console.WriteLine("Ik strooi.");
        }

        protected override void Zet()
        {
            Console.WriteLine("Ik doe een zet.");
        }

        protected override bool NogEenZet()
        {
            return true;
        }

        internal override bool IsGameOver()
        {
           return true;
        }

        internal override void DeterMineWinner()
        {
            Console.WriteLine("Winnaar beslist.");
        }

    }
}

