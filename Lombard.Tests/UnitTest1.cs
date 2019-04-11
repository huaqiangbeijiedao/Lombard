using NUnit.Framework;
using Lombard.Logic;
namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
        [Test]
        public void ProfitReport_TwoValues_Output()
        {
            double price1 = 100;
            double price2 = 300;
            var c = new ProfitReport();
            Assert.AreEqual(200, c.GenerateProfitReport(price1, price2));
        }
        [Test]
        public void AddItem_ListAndItem_List()
        {
            var lista = new Items();

        }
    }
}