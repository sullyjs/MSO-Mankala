using System;
namespace MSO2
{
    public class WariBord : Spelbord
    {
        public WariBord(Kuiltje[] KuiltjesSpeler1, Kuiltje[] KuiltjesSpeler2, int stenenverzamelkuiltje1 = 0, int stenenverzamelkuiltje2 = 0) : base(KuiltjesSpeler1, KuiltjesSpeler2)//: base(aantalKuiltjes, steentjes)
        {
            verzamelkuiltjeSpeler1 = new Kuiltje(stenenverzamelkuiltje1);
            verzamelkuiltjeSpeler2 = new Kuiltje(stenenverzamelkuiltje2);
        }

        public override int Winnaar()
        {
            // 1 is speler 1, 2 is speler 2, 0 is gelijkspel

            if (verzamelkuiltjeSpeler1.Steentjes > verzamelkuiltjeSpeler2.Steentjes)
            {
                return 1;
            }
            else if (verzamelkuiltjeSpeler1.Steentjes < verzamelkuiltjeSpeler2.Steentjes)
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

