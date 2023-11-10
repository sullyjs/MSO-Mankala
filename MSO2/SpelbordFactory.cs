using System;
namespace MSO2
{
	public abstract class SpelbordFactory
	{
        public Spelbord Spelbord { get; protected set; }

        public SpelbordFactory(int aantalKuiltjes, int steentjesPerKuiltje)
        {
            Spelbord = SpelbordMaken(aantalKuiltjes, steentjesPerKuiltje);
        }

		public virtual Spelbord SpelbordMaken(int aantalKuiltjes, int steentjesPerKuiltje)
		{
            Kuiltje[] kuiltjesSpeler1 = KuiltjesMaken(aantalKuiltjes, steentjesPerKuiltje);
            Kuiltje[] kuiltjesSpeler2 = KuiltjesMaken(aantalKuiltjes, steentjesPerKuiltje);
            return new Spelbord(kuiltjesSpeler1, kuiltjesSpeler2);
        }

        protected Kuiltje[] KuiltjesMaken(int aantalKuiltjes, int steentjesPerKuiltje)
        {
            Kuiltje[] kuiltjes = new Kuiltje[aantalKuiltjes];

            for (int i = 0; i < aantalKuiltjes; i++)
            {
                kuiltjes[i] = new Kuiltje(steentjesPerKuiltje);
            }

            return kuiltjes;
        }
	}
}

