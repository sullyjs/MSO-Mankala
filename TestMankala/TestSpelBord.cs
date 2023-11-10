using MSO2;

namespace TestMankala;

public class TestSpelBord
{
    Kuiltje[] kSpeler1Leeg = { new Kuiltje(0), new Kuiltje(0), new Kuiltje(0) };
    Kuiltje[] kSpeler2Leeg = { new Kuiltje(0), new Kuiltje(0), new Kuiltje(0) };

    Kuiltje[] kSpeler1NietLeeg = { new Kuiltje(1), new Kuiltje(2), new Kuiltje(3) };
    Kuiltje[] kSpeler2NietLeeg = { new Kuiltje(1), new Kuiltje(2), new Kuiltje(3) };


    //Check CheckAlleKuiltjesLeeg() methode

    [Fact]
    public void AlleKuiltjesLeegFalse()
    {
        Spelbord nietLeeg = new Spelbord(kSpeler1NietLeeg, kSpeler2NietLeeg);


        bool resultaat = nietLeeg.CheckAlleKuiltjesLeeg();

        Assert.False(resultaat);
    }

    [Fact]
    public void AlleKuiltjesLeegTrue()
    {
        Spelbord leeg = new Spelbord(kSpeler1Leeg, kSpeler2Leeg);


        bool resultaat = leeg.CheckAlleKuiltjesLeeg();

        Assert.True(resultaat);
    }


    //Check Winnaar() methode

    [Fact]
    public void WinnaarSpeler1()
    {
        Spelbord winnaarSpeler1 = new Spelbord(kSpeler1Leeg, kSpeler2NietLeeg);

        int resultaat = winnaarSpeler1.Winnaar();

        Assert.Equal(1, resultaat);
    }

    [Fact]
    public void WinnaarSpeler2()
    {
        Spelbord winnaarSpeler2 = new Spelbord(kSpeler1NietLeeg, kSpeler2Leeg);

        int resultaat = winnaarSpeler2.Winnaar();

        Assert.Equal(2, resultaat);
    }

    [Fact]
    public void WinnaarGelijkspel()
    {
        Spelbord winnaarGelijkspel = new Spelbord(kSpeler1Leeg, kSpeler2Leeg);

        int resultaat = winnaarGelijkspel.Winnaar();

        Assert.Equal(0, resultaat);
    }

    [Fact]
    public void WinnaarNietLeeg()
    {
        Spelbord winnaarNietLeeg = new Spelbord(kSpeler1NietLeeg, kSpeler2NietLeeg);

        int resultaat = winnaarNietLeeg.Winnaar();

        Assert.Equal(0, resultaat);
    }
}

