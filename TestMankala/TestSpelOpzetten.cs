using MSO2;

namespace TestMankala;

public class TestSpelOpzetten
{
    UserInputHandler inputHandler = UserInputHandler.GetInstance();
    UserInterface ui;
    UserInterface uiSpelOpzetten;
    //Check CheckAlleKuiltjesLeeg() methode

    SpelOpzetten spel;
    //fix protection level

    public TestSpelOpzetten(){

        //arrange
        spel = new SpelOpzetten();
    }

    //public int VariantSpelKiezen()
    //{
    // ... (existing code)

    //return variantSpel;
    //}

    [Fact]
    public void Constructor_Correct()
    {
        Assert.NotNull(spel.spelLogica);
        Assert.NotNull(spel.ui);
    }


    //as is, use this -- make methods for each variant
    public void VariantSpelKiezen1_ChooseMankalaSpel()
    {
        // Act - click 1 to test, other numbers to test other outputs
        spel.VariantSpelKiezen();

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

