using MSO2;

namespace TestMankala;

public class TestSpelOpzetten
{
    // SpelUitvoeren spelLogica; - fix reachable
    UserInputHandler inputHandler = UserInputHandler.GetInstance();
    UserInterface ui;
    UserInterface uiSpelOpzetten;
    //Check CheckAlleKuiltjesLeeg() methode


    //fix protection level

    public TestSpelOpzetten(){

        //arrange
        SpelOpzetten Spel = new SpelOpzetten();
        int resultaat = Spel.VariantSpelKiezen();
    }

    //for this to work, use this in SpelOpzetten.cs

    //public int VariantSpelKiezen()
    //{
    // ... (existing code)

    //return variantSpel;
    //}

    //voor alles protectionlevel fixen
    [Fact]
    public void Variantspelkiezen1()
    {
        Assert.Equal(1, resultaat);
    }

    [Fact]
    public void Variantspelkiezen2()
    {
        Assert.Equal(2, resultaat);
    }


    //Check Winnaar() methode

    [Fact]
    public void Variantspelkiezen3() { 

        Assert.Equal(3, resultaat);
    }

    [Fact]
    public void Constructor_Correct()
    {
        Assert.NotNull(spel.spelLogica);
        Assert.NotNull(spel.ui);
    }


    //as is, use this -- make methods for each variant
    public void VariantSpelKiezen1_ChooseMankalaSpel()
    {
        // Act
        Spel.VariantSpelKiezen(1);

        // Assert
        Assert.IsType<MankalaSpel>(spel.spelLogica.spel);
        Assert.True(spel.spelLogica.gameActive);
    }

    //test main game
    [Fact]
    public void TestMainRunGame()
    {
        var consoleOutput = new StringWriter();
        Console.SetOut(consoleOutput);
        SpelOpzetten.Main();
        Assert.Contains("Game is running", consoleOutput.ToString());
    }


}

