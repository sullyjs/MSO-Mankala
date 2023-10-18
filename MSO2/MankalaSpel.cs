using System;
namespace MSO2
{
    public class MankalaSpel : Spel
    {

        private MankalaBord bord;
        private int HuidigeSpeler;

        public MankalaSpel()
        {
            HuidigeSpeler = 1;
            bord = new MankalaBord();
        }

        public override void Speel()
        {

            Strooien();
            Zet();
        }



        //override other functies

        public override void Strooien()
        {
            Console.WriteLine("Strooien");
            //for(int i = 0; i < bor)

            //hou de kuiltjes bij, player can choose welk van zijn kuiltjes, en dan vanaf daar
            //for loop, steentjes van al dat kuiltje -> naar nul, en dan + 1 steentjes voor elk kuiltje + 1
            
            
        }

        protected override void Zet()
        {
            Console.WriteLine("HuidigeSpeler: Ik doe een zet");
            if (HuidigeSpeler == 1)
            {
                HuidigeSpeler = 2;
            }
            else
            {
                HuidigeSpeler = 1;
            }

        }

        protected override bool NogEenZet()
        {
            if (true) {
                Console.WriteLine("Ik doe nog een zet");
                return true;

            }

            else
            {
                Console.WriteLine("Nope");
                return false;
            } 
        }

        protected override bool IsGameOver()
        {
            return bord.CheckAlleKuiltjesLeeg();
        }

        protected override void DeterMineWinner()
        {
            int winnaar = bord.Winnaar();

            if (winnaar == 0)
            {
                Console.WriteLine("gelijkspel");
            }
            else if (winnaar == 1)
            {
                Console.WriteLine("Speler 1 heeft gewonnen");
            }
            else
            {
                Console.WriteLine("Speler 2 heeft gewonnen");
            }
        }

    }
}

