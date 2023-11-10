using System;
namespace MSO2
{
    public class MankalaBord : Spelbord
    {
        public MankalaBord(Kuiltje[] KuiltjesSpeler1, Kuiltje[] KuiltjesSpeler2) : base(KuiltjesSpeler1, KuiltjesSpeler2)
        {
            thuiskuiltjeSpeler1 = new Kuiltje(0);
            thuiskuiltjeSpeler2 = new Kuiltje(0);
        }
    }
}

