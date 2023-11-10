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
    }
}

