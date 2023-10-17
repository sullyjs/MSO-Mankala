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

        Assert.Equal(kResultaat, k);
    }
}
