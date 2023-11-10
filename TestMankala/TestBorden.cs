using System;
using MSO2;

namespace TestMankala
{
    public class TestBorden
    {
        //Wari bord winnaar testen
        [Fact]
        public void WariWinnaarSpeler1()
        {
            Spelbord wSpeler1 = new WariBordFactory(5, 0).Spelbord;

            int resultaat = wSpeler1.Winnaar();

            Assert.Equal(1, resultaat);
        }

        [Fact]
        public void WariWinnaarSpeler2()
        {
            Spelbord wSpeler2 = new WariBordFactory(3, 5).Spelbord;

            int resultaat = wSpeler2.Winnaar();

            Assert.Equal(2, resultaat);
        }

        [Fact]
        public void WariWinnaarGelijkspel()
        {
            Spelbord wGelijkspel = new WariBordFactory(2, 2).Spelbord;

            int resultaat = wGelijkspel.Winnaar();

            Assert.Equal(0, resultaat);
        }


        //Mankala bord winnaar testen
        [Fact]
        public void MankalaWinnaarSpeler1()
        {
            Spelbord wSpeler1 = new MankalaBordFactory(5, 0).Spelbord;

            int resultaat = wSpeler1.Winnaar();

            Assert.Equal(1, resultaat);
        }

        [Fact]
        public void MankalaWinnaarSpeler2()
        {
            Spelbord wSpeler2 = new MankalaBordFactory(3, 5).Spelbord;

            int resultaat = wSpeler2.Winnaar();

            Assert.Equal(2, resultaat);
        }

        [Fact]
        public void MankalaWinnaarGelijkspel()
        {
            Spelbord wGelijkspel = new MankalaBordFactory(2, 2).Spelbord;

            int resultaat = wGelijkspel.Winnaar();

            Assert.Equal(0, resultaat);
        }
    }
}

