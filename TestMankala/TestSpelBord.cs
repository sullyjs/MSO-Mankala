namespace TestMankala;

using MSO2;

public class TestSpelBord
{
    [Fact]
    public void AlleKuiltjesLeegFalse()
    {
        Spelbord sb = new Spelbord(6, 4);

        bool resultaat = sb.CheckAlleKuiltjesLeeg();

        Assert.False(resultaat);
    }

    [Fact]
    public void AlleKuiltjesLeegTrue()
    {
        Spelbord sb = new Spelbord(6, 0);

        bool resultaat = sb.CheckAlleKuiltjesLeeg();

        Assert.True(resultaat);
    }
}

