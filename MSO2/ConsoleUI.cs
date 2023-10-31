using System;
namespace MSO2
{
	public class ConsoleUI : UserInterface
	{
        const int lengteKuiltje = 5;
        int lengteSpeelbord; 

        public ConsoleUI(Spel huidigeSpel) : base(huidigeSpel)
        {
            lengteSpeelbord = spel.bord.kuiltjesSpeler1.Length;
        }

        public override void TekenBord()
        {
            int speler1 = 1;
            int speler2 = 2;

            TekenSpelerKant(speler2);
            TekenThuiskuiltje();
            TekenSpelerKant(speler1);
        }

        public override void TekenSpelerKant(int speler)
        {
            Kuiltje[] kuiltjes;

            if (speler == 1)
            {
                kuiltjes = spel.bord.kuiltjesSpeler1;
            }
            else
            {
                kuiltjes = spel.bord.kuiltjesSpeler2;
            }

            string buitenkantKuiltjeRij = new string('+', lengteKuiltje * kuiltjes.Length);
            Console.WriteLine(buitenkantKuiltjeRij);

            foreach (Kuiltje k in kuiltjes)
            {
                Console.Write("+ {0} +", k.Steentjes);
            }

            Console.Write("\n");
            Console.WriteLine(buitenkantKuiltjeRij);
        }

        public override void TekenThuiskuiltje()
        {
            Kuiltje thuiskuiltjeSpeler1 = spel.bord.thuiskuiltjeSpeler1;
            Kuiltje thuiskuiltjeSpeler2 = spel.bord.thuiskuiltjeSpeler2;

            string binnenkantKuiltjes = new string(' ', lengteKuiltje * (lengteSpeelbord - 2));
            Console.WriteLine("+ {0} +{1}+ {2} +", thuiskuiltjeSpeler1.Steentjes, binnenkantKuiltjes, thuiskuiltjeSpeler2.Steentjes);
        }

        public override void TekenVerzamelkuiltje()
        {

        }
    }
}

