namespace TestMankala;

using MSO2;

public class TestMankalaBord
{
    [Fact]
    public void AlleKuiltjesLeegFalse()
    {
        MankalaBord mb = new MankalaBord();

        bool resultaat = mb.CheckAlleKuiltjesLeeg();

        Assert.False(resultaat);
    }

    [Fact]
    public void AlleKuiltjesLeegTrue()
    {
        Spelbord mb = new Spelbord(6, 0);

        bool resultaat = mb.CheckAlleKuiltjesLeeg();

        Assert.True(resultaat);
    }
}

