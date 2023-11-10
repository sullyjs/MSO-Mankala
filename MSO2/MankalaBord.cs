using System;
namespace MSO2
{
    public class MankalaBord : Spelbord
    {
        public MankalaBord(Kuiltje[] KuiltjesSpeler1, Kuiltje[] KuiltjesSpeler2, int stenenThuiskuiltje1 = 0, int stenenThuiskuiltje2 = 0) : base(KuiltjesSpeler1, KuiltjesSpeler2)
        {
            thuiskuiltjeSpeler1 = new Kuiltje(stenenThuiskuiltje1);
            thuiskuiltjeSpeler2 = new Kuiltje(stenenThuiskuiltje2);
        }

        public override int Winnaar()
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

