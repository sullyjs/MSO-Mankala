using System;
namespace MSO2
{
	class UUBordFactory : SpelbordFactory
	{
        const int aantalKuiltjes = 5;
        const int steentjesPerKuiltje = 5;

        public UUBordFactory() : base(aantalKuiltjes, steentjesPerKuiltje) { }

        public override Spelbord SpelbordMaken(int aantalKuiltjes = 5, int steentjesPerKuiltje = 5)
        {
            Kuiltje[] kuiltjesSpeler1 = KuiltjesMaken(aantalKuiltjes, steentjesPerKuiltje);
            Kuiltje[] kuiltjesSpeler2 = KuiltjesMaken(aantalKuiltjes, steentjesPerKuiltje);
            return new UUBord(kuiltjesSpeler1, kuiltjesSpeler2);
        }
    }
}

