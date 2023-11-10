using System;
namespace MSO2
{
	class WariBordFactory : SpelbordFactory
	{
        const int aantalKuiltjes = 6;
        const int steentjesPerKuiltje = 4;

        public WariBordFactory() : base(aantalKuiltjes, steentjesPerKuiltje) { }

        public override Spelbord SpelbordMaken(int aantalKuiltjes, int steentjesPerKuiltje)
        {
            Kuiltje[] kuiltjesSpeler1 = KuiltjesMaken(aantalKuiltjes, steentjesPerKuiltje);
            Kuiltje[] kuiltjesSpeler2 = KuiltjesMaken(aantalKuiltjes, steentjesPerKuiltje);
            return new WariBord(kuiltjesSpeler1, kuiltjesSpeler2);
        }
    }
}

