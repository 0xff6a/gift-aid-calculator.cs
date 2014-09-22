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
      decimal expectedAmount = 25.0m;
      decimal calculatedAmount = GiftAidCalculator.GiftAidFor(100);

      Assert.AreEqual(expectedAmount, calculatedAmount);
    }

    [Test]
    public void RoundedGiftAidCalculation()
    { 
      decimal exactDonation = 1.23456m;
      decimal roundedGiftAid =  0.31m;

      Assert.AreEqual(roundedGiftAid, GiftAidCalculator.GiftAidFor(exactDonation));
    }
  }
}