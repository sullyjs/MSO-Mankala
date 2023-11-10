using System;
namespace MSO2
{
	class MankalaBordFactory : SpelbordFactory
	{
        const int aantalKuiltjes = 6;
        const int steentjesPerKuiltje = 4;

        public MankalaBordFactory() : base (aantalKuiltjes, steentjesPerKuiltje) { }

        public override Spelbord SpelbordMaken(int aantalKuiltjes, int steentjesPerKuiltje)
        {
            Kuiltje[] kuiltjesSpeler1 = KuiltjesMaken(aantalKuiltjes, steentjesPerKuiltje);
            Kuiltje[] kuiltjesSpeler2 = KuiltjesMaken(aantalKuiltjes, steentjesPerKuiltje);
            return new MankalaBord(kuiltjesSpeler1, kuiltjesSpeler2);
        }
    }
}

