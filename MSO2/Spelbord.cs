using System;
namespace MSO2
{
    public class Spelbord
    {
        public Kuiltje[] kuiltjesSpeler1;
        public Kuiltje[] kuiltjesSpeler2;
        public Kuiltje thuiskuiltjeSpeler1;
        public Kuiltje thuiskuiltjeSpeler2;
        public Kuiltje verzamelkuiltjeSpeler1;
        public Kuiltje verzamelkuiltjeSpeler2;

        public Spelbord(Kuiltje[] KuiltjesSpeler1, Kuiltje[] KuiltjesSpeler2)
        {
            kuiltjesSpeler1 = KuiltjesSpeler1;
            kuiltjesSpeler2 = KuiltjesSpeler2;
        }

        public bool CheckAlleKuiltjesLeeg()
        {
            int lengteSpeelbord = kuiltjesSpeler1.Length;

            for (int i = 0; i < lengteSpeelbord; i++)
            {
                if (!kuiltjesSpeler1[i].CheckLeeg() || !kuiltjesSpeler2[i].CheckLeeg())
                {
                    return false;
                }
            }

            return true;
        }


        // default winnaar is speler met leeg bord
        // geen winconditie met thuiskuiltjes of verzamelkuiltjes, want die worden niet aangemaakt in basis Spelbord
        public virtual int Winnaar()
        {
            // 1 = speler 1
            // 2 = speler 2
            // 0 = gelijkspel of nog geen winnaar

            bool kuiltjesSpeler1Leeg = kuiltjesSpeler1.All(k => k.CheckLeeg());
            bool kuiltjesSpeler2Leeg = kuiltjesSpeler2.All(k => k.CheckLeeg());

            if (kuiltjesSpeler1Leeg)
            {
                return 1;
            }
            else if (kuiltjesSpeler2Leeg)
            {
                return 2;
            }
            else
            {
                return 0;
            }
        }
    }
}