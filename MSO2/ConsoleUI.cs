using System;
namespace MSO2
{
	public class ConsoleUI : UserInterface
	{
        const int lengteKuiltje = 7;
        readonly int lengteSpeelbord;
        readonly string buitenkantKuiltjeRij;
        readonly string binnensteKuiltjesRij;   // Voor ruimte tussen thuis-/verzamelkuiltjes te tekenen 

        public ConsoleUI(Spelbord huidigeSpelbord) : base(huidigeSpelbord)
        {
            lengteSpeelbord = spelbord.kuiltjesSpeler1.Length;
            buitenkantKuiltjeRij = new string('+', lengteKuiltje * lengteSpeelbord);
            binnensteKuiltjesRij = new string(' ', lengteKuiltje * (lengteSpeelbord - 2));
        }

        public override void OverviewBordTekenen()
        {
            // om te checken welke variant van het spel wordt gespeeld
            Kuiltje thuiskuiltjeSpeler1 = spelbord.thuiskuiltjeSpeler1;
            Kuiltje verzamelkuiltjeSpeler1 = spelbord.verzamelkuiltjeSpeler1;

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

            HuidigeSpeler(1);
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

            if (spelbord.thuiskuiltjeSpeler1 != null)
            {
                TekenTussenkuiltje(spelbord.thuiskuiltjeSpeler1, spelbord.thuiskuiltjeSpeler2);
            }
            else if (spelbord.verzamelkuiltjeSpeler1 != null)
            {
                TekenTussenkuiltje(spelbord.verzamelkuiltjeSpeler1, spelbord.verzamelkuiltjeSpeler2);
            }
            
            TekenSpelerKant(speler1);
        }

        public override void TekenSpelerKant(int speler)
        {
            Kuiltje[] kuiltjes;

            if (speler == 1)
            {
                kuiltjes = spelbord.kuiltjesSpeler1;
            }
            else
            {
                kuiltjes = spelbord.kuiltjesSpeler2;
            }
            
            Console.WriteLine(buitenkantKuiltjeRij);

            foreach (Kuiltje k in kuiltjes)
            {
                BinnenkantKuiltjeTekenen(k.Steentjes);
            }

            Console.Write("\n");
            Console.WriteLine(buitenkantKuiltjeRij);
        }

        // voor het tekenen van de thuis-/verzamelkuiltjes
        public override void TekenTussenkuiltje(Kuiltje kSpeler1, Kuiltje kSpeler2)
        {
            BinnenkantKuiltjeTekenen(kSpeler1.Steentjes);
            Console.Write(binnensteKuiltjesRij);
            BinnenkantKuiltjeTekenen(kSpeler2.Steentjes);
            Console.Write("\n");
        }

        public static string CentrerenString(string s, int lengte)
        {
            // berekenen hoeveel ruimte er aan de linkerkant van de string moet komen
            int lengteLinks = (lengte - s.Length) / 2;
            s = s.PadLeft(lengteLinks + s.Length, ' ');
            return s.PadRight(lengte, ' ');
        }

        public override void VariantSpelKiezen(int spelKeuze)
        {
            if (spelKeuze == 1)
            {
                Console.WriteLine("\nJe hebt gekozen voor Mankala!");
            }
            else if (spelKeuze == 2)
            {
                Console.WriteLine("\nJe hebt gekozen voor Wari!");
            }
            else if (spelKeuze == 3)
            {
                Console.WriteLine("\nJe hebt gekozen voor UU!");
            }
            else
            {
                Console.WriteLine("\nOngeldige keuze");
                throw new Exception("Ongeldige keuze ingevoerd.");
            }
        }

        public override void VariantKeuzeMenu()
        {
            Console.WriteLine("Welcome to a new game of Mankala: choose A to play classic Mankala, B for Wari and C for UU.");
        }

        public override void HuidigeSpeler(int speler)
        {
            Console.WriteLine("Speler {0} is nu aan de beurt.", speler);
        }

        public void GekozenKuiltje(int kuiltje)
        {
            Console.WriteLine("\nGekozen kuiltje: {0}", kuiltje);
        }

        public override void Winnaar(int winnaar)
        {
            if (winnaar == 1)
            {
                Console.WriteLine("Speler 1 heeft gewonnen!");
            }
            else if (winnaar == 2)
            {
                Console.WriteLine("Speler 2 heeft gewonnen!");
            }
            else
            {
                Console.WriteLine("Het is gelijkspel!");
            }
        }
    }
}

