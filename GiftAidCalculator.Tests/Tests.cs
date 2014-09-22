using NUnit.Framework;
using GiftAidCalculator;

namespace GiftAidCalculator.TestConsole
{
  [TestFixture]
  public class GiftAidCalculatorTest
  {
    [Test]
    public void SimpleGiftAidCalculation()
    {
      decimal expectedAmount = 25;
      decimal calculatedAmount = GiftAidCalculator.GiftAidFor(100);

      Assert.AreEqual(expectedAmount, calculatedAmount);
    }
  }
}