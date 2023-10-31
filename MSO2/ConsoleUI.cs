using System;
namespace MSO2
{
	public class ConsoleUI : UserInterface
	{
        const int lengteKuiltje = 7;
        readonly int lengteSpeelbord;
        readonly string buitenkantKuiltjeRij;
        readonly string binnensteKuiltjesRij;   // Voor ruimte tussen thuis-/verzamelkuiltjes te tekenen 

        public ConsoleUI(Spel huidigeSpel) : base(huidigeSpel)
        {
            lengteSpeelbord = spel.bord.kuiltjesSpeler1.Length;
            buitenkantKuiltjeRij = new string('+', lengteKuiltje * lengteSpeelbord);
            binnensteKuiltjesRij = new string(' ', lengteKuiltje * (lengteSpeelbord - 2));
        }

        public override void OverviewBordTekenen()
        {
            Kuiltje thuiskuiltjeSpeler1 = spel.bord.thuiskuiltjeSpeler1;
            Kuiltje verzamelkuiltjeSpeler1 = spel.bord.verzamelkuiltjeSpeler1;

            Console.WriteLine("Het bord ziet er als volgt uit:");
            Console.WriteLine("Kant speler 2");

            Console.WriteLine(buitenkantKuiltjeRij);

            for (int i = lengteSpeelbord * 2; i > lengteSpeelbord; i--)
            {
                BinnenkantKuiltjeTekenen(i);
            }
            Console.Write("\n");

            if (thuiskuiltjeSpeler1 != null || verzamelkuiltjeSpeler1 != null)
            {
                Console.WriteLine("+{0}+{1}+{0}+", CentrerenString("*", lengteKuiltje - 2), binnensteKuiltjesRij);
            }

            for (int i = 1; i <= lengteSpeelbord; i++)
            {
                BinnenkantKuiltjeTekenen(i);
            }
            Console.Write("\n");

            Console.WriteLine(buitenkantKuiltjeRij);

            Console.WriteLine("Kant speler 1");
            Console.WriteLine("Gebruik de nummers 1-{0} op het toetsenbord voor beide spelers om de zetten uit te voeren.", lengteSpeelbord);
            Console.WriteLine("Voor speler 2, zie 1 als {0}, 2 als {1}, etc.", lengteSpeelbord + 1, lengteSpeelbord + 2);

            if (thuiskuiltjeSpeler1 != null)
            {
                Console.WriteLine("Kuiltjes gemarkeerd met een *, zijn een thuiskuiltje.");
            }
            else if (verzamelkuiltjeSpeler1 != null)
            {
                Console.WriteLine("Kuiltjes gemarkeerd met een *, zijn een verzamelkuiltje.");
            }

            Console.WriteLine("Speler 1 is nu aan de beurt.");
        }

        static void BinnenkantKuiltjeTekenen(int i)
        {
            Console.Write("+{0}+", CentrerenString(i.ToString(), lengteKuiltje - 2));
        }

        public override void TekenBord()
        {
            const int speler1 = 1;
            const int speler2 = 2;

            TekenSpelerKant(speler2);

            if (spel.bord.thuiskuiltjeSpeler1 != null)
            {
                TekenTussenkuiltje(spel.bord.thuiskuiltjeSpeler1, spel.bord.thuiskuiltjeSpeler2);
            }
            else if (spel.bord.verzamelkuiltjeSpeler1 != null)
            {
                TekenTussenkuiltje(spel.bord.verzamelkuiltjeSpeler1, spel.bord.verzamelkuiltjeSpeler2);
            }
            
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
            
            Console.WriteLine(buitenkantKuiltjeRij);

            foreach (Kuiltje k in kuiltjes)
            {
                BinnenkantKuiltjeTekenen(k.Steentjes);
            }

            Console.Write("\n");
            Console.WriteLine(buitenkantKuiltjeRij);
        }

        public override void TekenTussenkuiltje(Kuiltje kSpeler1, Kuiltje kSpeler2)
        {
            Console.WriteLine("+ {0} +{1}+ {2} +", kSpeler1.Steentjes, binnensteKuiltjesRij, kSpeler2.Steentjes);
        }

        public static string CentrerenString(string s, int lengte)
        {
            // berkenen hoeveel ruimte er aan de linkerkant van de string moet komen
            int lengteLinks = (lengte - s.Length) / 2;
            s = s.PadLeft(lengteLinks + s.Length, ' ');
            return s.PadRight(lengte, ' ');
        }
    }
}

