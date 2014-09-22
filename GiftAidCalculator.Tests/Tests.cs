using NUnit.Framework;
using GiftAidCalculator;
using GiftAidCalculatorCollaborators;

namespace GiftAidCalculator.TestConsole
{
  [TestFixture]
  public class GiftAidCalculatorTest
  {
    Admin admin = new Admin();

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

    [Test]
    public void UpdatingTaxRateAsAdmin()
    {
     decimal newTaxRate = 30.0m;
     
     GiftAidCalculator.UpdateTaxRate(newTaxRate, admin);

     Assert.AreEqual(newTaxRate, GiftAidCalculator.TaxRate); 
    }
  }
}