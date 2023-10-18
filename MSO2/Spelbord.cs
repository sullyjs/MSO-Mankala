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
    }
}