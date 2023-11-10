using System;
namespace MSO2
{
	public class WariBordFactory : SpelbordFactory
	{
        const int aantalKuiltjes = 6;
        const int steentjesPerKuiltje = 4;

        int aantalStenenVerzamelkuiltje1;
        int aantalStenenVerzamelkuiltje2;

        public WariBordFactory(int stenenVerzamelkuiltje1 = 0, int stenenVerzamelkuiltje2 = 0) : base(aantalKuiltjes, steentjesPerKuiltje)
        {
            aantalStenenVerzamelkuiltje1 = stenenVerzamelkuiltje1;
            aantalStenenVerzamelkuiltje2 = stenenVerzamelkuiltje2;

            Spelbord = SpelbordMaken(aantalKuiltjes, steentjesPerKuiltje);
        }

        public override Spelbord SpelbordMaken(int aantalKuiltjes, int steentjesPerKuiltje)
        {
            Kuiltje[] kuiltjesSpeler1 = KuiltjesMaken(aantalKuiltjes, steentjesPerKuiltje);
            Kuiltje[] kuiltjesSpeler2 = KuiltjesMaken(aantalKuiltjes, steentjesPerKuiltje);
            return new WariBord(kuiltjesSpeler1, kuiltjesSpeler2, aantalStenenVerzamelkuiltje1, aantalStenenVerzamelkuiltje2);
        }
    }
}

