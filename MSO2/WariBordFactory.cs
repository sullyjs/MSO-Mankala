using System;
namespace MSO2
{
	class WariBordFactory : SpelbordFactory
	{
        const int aantalKuiltjes = 6;
        const int steentjesPerKuiltje = 4;

        int aantalStenenVerzamelkuiltje1 = 0;
        int aantalStenenVerzamelkuiltje2 = 0;

        public WariBordFactory(int stenenVerzamelkuiltje1 = 0, int stenenVerzamelkuiltje2 = 0) : base(aantalKuiltjes, steentjesPerKuiltje)
        {
            aantalStenenVerzamelkuiltje1 = stenenVerzamelkuiltje1;
            aantalStenenVerzamelkuiltje2 = stenenVerzamelkuiltje2;
        }

        public override Spelbord SpelbordMaken(int aantalKuiltjes, int steentjesPerKuiltje)
        {
            Kuiltje[] kuiltjesSpeler1 = KuiltjesMaken(aantalKuiltjes, steentjesPerKuiltje);
            Kuiltje[] kuiltjesSpeler2 = KuiltjesMaken(aantalKuiltjes, steentjesPerKuiltje);
            return new WariBord(kuiltjesSpeler1, kuiltjesSpeler2, aantalStenenVerzamelkuiltje1, aantalStenenVerzamelkuiltje2);
        }
    }
}

