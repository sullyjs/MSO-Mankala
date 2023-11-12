using System;
using MSO2;

namespace TestMankala
{
    public class SpelTests
    {

        [Fact]
        public void Constructor_Test()
        {
            // Arrange
            Spel spel = new MankalaSpel();

            // Assert
            Assert.Equal(1, spel.HuidigeSpeler);
        }

        [Fact]
        public void WisselSpeler_HuidigeSpeler()
        {
            Spel spel = new MankalaSpel();
            spel.WisselSpeler();
            Assert.Equal(2, spel.HuidigeSpeler);
            spel.WisselSpeler();
            Assert.Equal(1, spel.HuidigeSpeler);
        }

        [Fact]
        public void Subscribe_AddsSubscriberToList()
        {
            Spel spel = new MankalaSpel();
            var ui = new ConsoleUI(spel);
            spel.Subscribe(ui);
            Assert.Contains(ui, spel.subscribers);
        }

        [Fact]
        public void NotifySubscribers_CallsUpdateMethodOnSubscribers()
        {
            // Arrange
            Spel spel = new MankalaSpel();
            var ui1 = new MockUserInterface(spel);
            var ui2 = new MockUserInterface(spel);

            // Act
            spel.Subscribe(ui1);
            spel.Subscribe(ui2);
            spel.NotifySubscribers();

            // Assert
            Assert.True(ui1.UpdateCalled);
            Assert.True(ui2.UpdateCalled);
        }
    }

    // A mock UserInterface for testing
    public class MockUserInterface : UserInterface { 

        public MockUserInterface(Spel huidgeSpel) : base(huidgeSpel) { }
    
        public bool UpdateCalled { get; private set; } = false;
        // voor het tekenen van een overview van het bord aan het begin van het spel voor de spelers
        public override void OverviewBordTekenen()
        {
            Console.WriteLine("OWBord Mock Interface.");
        }

        //Observer pattern methode
        public override void Update()
        {
            Console.WriteLine("Update Mock Interface.");
        }

        public override void TekenBord()
        {
            Console.WriteLine("TekenBord Mock Interface.");
        }

        public override void VariantSpelKiezen(int spelKeuze)
        {
            Console.WriteLine("Variant Kiezen Mock Interface.");
        }

        public override void VariantKeuzeMenu()
        {
            Console.WriteLine("Variant Keuze Menu Mock Interface.");
        }

        public override void HuidigeSpeler() { 
        
            Console.WriteLine("HS Mock Interface.");
        }

        public override void Winnaar(int winnaar)
        {
            Console.WriteLine("Winnar Mock Interface.");
        }

        public override void GekozenKuiltje()
        {
            Console.WriteLine("GK Mock Interface.");
        }

        public override void KuiltjeKiezen()
        {
            Console.WriteLine("Kuiltje Kiezen Mock Interface.");
        }

        // error message voor als een ongeldig kuiltje wordt gekozen
        public override void VerkeerdKuiltjeInput()
        {
            Console.WriteLine("Verkeeld Kuiltje Mock Interface.");
        }
    }
}

