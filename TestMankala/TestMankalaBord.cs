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

    /*[Fact]
    public void AlleKuiltjesLeegTrue()
    {
        MankalaBord mb = new MankalaBord();

        //mb.

        bool resultaat = mb.CheckAlleKuiltjesLeeg();

        Assert.False(resultaat);
    }*/
}

