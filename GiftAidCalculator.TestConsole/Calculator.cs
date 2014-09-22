using System;
using GiftAidCalculatorCollaborators;

namespace GiftAidCalculator.TestConsole
{
  public class GiftAidCalculator
  {
    private static decimal taxRate = 20.0m;
    private const int decimalPlaces = 2;
    private const string defaultEventType = "default";

    public static decimal TaxRate 
    {
      get { return taxRate; }
    }

    public static void UpdateTaxRate(decimal newTaxRate, User user)
    {
      if(user.IsAdmin()) { taxRate = newTaxRate; }
    }

    public static decimal GiftAidFor(decimal donationAmount, Event varEvent = null)
    {
      if(varEvent == null) { varEvent = defaultEvent(); }

      return Math.Round(RawGiftAidFor(donationAmount, varEvent), decimalPlaces);    
    }

    private static decimal RawGiftAidFor(decimal donationAmount, Event varEvent)
    {
      if(varEvent.IsPromoted()) 
        return donationAmount * SupplementedGiftAidFactor(varEvent);
      else
        return donationAmount * SimpleGiftAidFactor();  
    }

    private static decimal SupplementedGiftAidFactor(Event varEvent)
    {
      return SimpleGiftAidFactor() * (1.0m + varEvent.GiftAidSupplement() / 100);
    }

    private static decimal SimpleGiftAidFactor()
    {
      return taxRate / (100 - taxRate);
    }

    private static Event defaultEvent()
    {
      return new Event(defaultEventType);
    }
  }
}