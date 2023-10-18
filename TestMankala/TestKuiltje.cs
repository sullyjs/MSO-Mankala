namespace TestMankala;

using MSO2;

public class TestKuiltje
{
    [Fact]
    public void StenenKuiltjeOphogen()
    {
        Kuiltje k = new Kuiltje(5);
        Kuiltje kResultaat = new Kuiltje(7);

        k.SteentjesVeranderen(2);
        
        Assert.Equal(kResultaat.Steentjes, k.Steentjes);
    }

    [Fact]
    public void StenenKuiltjeVerlagen()
    {
        Kuiltje k = new Kuiltje(7);
        Kuiltje kResultaat = new Kuiltje(5);

        k.SteentjesVeranderen(-2);

        Assert.Equal(kResultaat.Steentjes, k.Steentjes);
    }

    [Fact]
    public void LeegKuiltjeTrue()
    {
        Kuiltje k = new Kuiltje(0);

        bool resultaat = k.CheckLeeg();

        Assert.True(resultaat);
    }

    [Fact]
    public void LeegKuiltjeFalse()
    {
        Kuiltje k = new Kuiltje(1);

        bool resultaat = k.CheckLeeg();

        Assert.False(resultaat);
    }

    [Fact]
    public void NegatiefAantalStenen()
    {
        Action action = () => new Kuiltje(-3);

        Assert.Throws<Exception>(action);
    }
}
