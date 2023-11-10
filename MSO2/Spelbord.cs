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

            //create all the other thuiskuiltjes
            /*for (int i = 0; i < aantalKuiltjesPerSpeler; i++)
            {
                Kuiltje k1 = new Kuiltje(steentjesPerKuiltje);
                Kuiltje k2 = new Kuiltje(steentjesPerKuiltje);

                kuiltjesSpeler1[i] = k1;
                kuiltjesSpeler2[i] = k2;
            }*/
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

        public virtual int Winnaar() //on default the one of classic mankala
        {
            // 1 is speler 1, 2 is speler 2, 0 is gelijkspel

            if (thuiskuiltjeSpeler1.Steentjes > thuiskuiltjeSpeler2.Steentjes)
            {
                return 1;
            }
            else if (thuiskuiltjeSpeler1.Steentjes < thuiskuiltjeSpeler2.Steentjes)
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