using System;
namespace MSO2
{
    public class Spelbord
    {
        public Kuiltje[] kuiltjesSpeler1;
        public Kuiltje[] kuiltjesSpeler2;

        public Spelbord(int aantalKuiltjesPerSpeler, int steentjesPerKuiltje)
        {
            kuiltjesSpeler1 = new Kuiltje[aantalKuiltjesPerSpeler];
            kuiltjesSpeler2 = new Kuiltje[aantalKuiltjesPerSpeler];

            for (int i = 0; i < aantalKuiltjesPerSpeler; i++)
            {
                Kuiltje k1 = new Kuiltje(steentjesPerKuiltje);
                Kuiltje k2 = new Kuiltje(steentjesPerKuiltje);

                kuiltjesSpeler1[i] = k1;
                kuiltjesSpeler2[i] = k2;
            }
        }

        public bool CheckAlleKuiltjesLeeg()
        {
            for (int i = 0; i < 6; i++)
            {
                if (!kuiltjesSpeler1[i].CheckLeeg() || !kuiltjesSpeler2[i].CheckLeeg())
                {
                    return false;
                }
            }

            return true;
        }

        internal virtual void DrawMancalaBoard()
        {
            Console.WriteLine("Het boord ziet er zo uit.");
            Console.WriteLine("7"); // Speler 2 kuiltjes
            Console.WriteLine("+--+--+--+--+--+--+--+");
            Console.WriteLine("| 13 | 12 | 11 | 10 | 9 | 8 |  |");
            Console.WriteLine("|    |    |    |    |   |   |  |");
            Console.WriteLine("+----+----+----+----+---+---+--+");
            Console.WriteLine("| 1  | 2  |  3 | 4  | 5 | 6 |  |");
            Console.WriteLine("|    |    |   |     |   |   |  |");
            Console.WriteLine("+--+--+--+--+--+--+--+");
            Console.WriteLine("0"); // Speler 1 kuiltjes
        }
    }
}