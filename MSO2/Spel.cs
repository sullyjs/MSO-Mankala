using System;
namespace MSO2
{
    abstract public class Spel
    {
        public int gekozenKuiltje;

        public Spel()
        {

        }

        internal virtual void DrawMancalaBoard()
        {
            Console.WriteLine("Het boord ziet er zo uit.\n");
            Console.WriteLine("Speler 2"); // Speler 2 kuiltjes
            Console.WriteLine("  +----+----+----+----+---+---+--+  ");
            Console.WriteLine("  | 13 | 12 | 11 | 10 | 9 | 8 |  |  ");
            Console.WriteLine("  |    |    |    |    |   |   |  |  ");
            Console.WriteLine("0 +----+----+----+----+---+---+--+  7");
            Console.WriteLine("  | 1  | 2  |  3 | 4  | 5 | 6 |  |  ");
            Console.WriteLine("  |    |    |    |    |   |   |  |  ");
            Console.WriteLine("  +----+----+----+----+---+---+--+");
            Console.WriteLine("Speler 1\n"); // Speler 1 kuiltjes
            Console.WriteLine("Gebruik de nummers 1-6 op de keyboard voor beide spelers. Zie 1 als 8, 2 als 9 etc voor speler 2.");
            Console.WriteLine("Kuiltje 0 en 7 werken als thuiskuiltjes. Het is nu speler 1 beurt.");
        }

        public abstract void Speel();

        public abstract void Strooien();

        protected abstract void Zet();

        protected abstract bool NogEenZet();

        internal abstract bool IsGameOver();

        internal abstract void DeterMineWinner();


    }
}

