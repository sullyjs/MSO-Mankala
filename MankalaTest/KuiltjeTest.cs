namespace MankalaTest;

using System.Security.Principal;
using MSO2;

public class KuiltjeTest
{
    [Fact]
    public void WaardeKuiltjeOmhoog()
    {
        Kuiltje k = new Kuiltje(5);
        Kuiltje kResultaat = new Kuiltje(7);

        k.SteentjesVeranderen(2);

        Assert.Equal(kResultaat, k);
    }

    [Fact]
    public void KuiltjeError()
    {
        //Arrange
        Kuiltje k = new Kuiltje(5);

        //Act
        Action action = () => k.SteentjesVeranderen(-10);

        //Assert
        Assert.Throws<Exception>(action);
    }
}
