using System;
namespace MSO2
{
	public class MankalaBordFactory : SpelbordFactory
	{
        const int aantalKuiltjes = 6;
        const int steentjesPerKuiltje = 4;

        int aantalStenenThuiskuiltje1;
        int aantalStenenThuiskuiltje2;

        public MankalaBordFactory(int stenenThuiskuiltje1 = 0, int stenenThuiskuiltje2 = 0) : base(aantalKuiltjes, steentjesPerKuiltje)
        {
            aantalStenenThuiskuiltje1 = stenenThuiskuiltje1;
            aantalStenenThuiskuiltje2 = stenenThuiskuiltje2;

            Spelbord = SpelbordMaken(aantalKuiltjes, steentjesPerKuiltje);
        }

        public override Spelbord SpelbordMaken(int aantalKuiltjes, int steentjesPerKuiltje)
        {
            Kuiltje[] kuiltjesSpeler1 = KuiltjesMaken(aantalKuiltjes, steentjesPerKuiltje);
            Kuiltje[] kuiltjesSpeler2 = KuiltjesMaken(aantalKuiltjes, steentjesPerKuiltje);
            return new MankalaBord(kuiltjesSpeler1, kuiltjesSpeler2, aantalStenenThuiskuiltje1, aantalStenenThuiskuiltje2);
        }
    }
}

