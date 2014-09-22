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

	public class Program
	{
		static void PrintMenu()
		{
			Console.WriteLine("\n----Gift Aid Calculator 1.0----\n");
			Console.WriteLine("Please enter an option:\n(1) Calculate Gift Aid\n(2) Update Tax Rate\n(9) Exit");
		}

		static void CalculateGiftAid()
		{
			// Calculate Gift Aid Based on Inputs
			Console.WriteLine("Please Enter donation amount:");
			Console.WriteLine("Gift Aid Amount: {0}", 
					GiftAidCalculator.GiftAidFor(decimal.Parse(Console.ReadLine())));
			Console.WriteLine("Press any key to continue.");
			Console.ReadLine();
		}

		static void Main(string[] args)
		{	
			Menu:
				PrintMenu();
				int selection = int.Parse(Console.ReadLine());

			switch (selection)
			{
			    case 1:
			       	CalculateGiftAid();
			        goto Menu;
			    case 2:
			        Console.WriteLine("Case 2");
			        goto Menu;
			    case 9:
			        Console.WriteLine("Goodbye");
			        break;
			    default:
			        Console.WriteLine("Invalid Option: please try again");
			        goto Menu;
			}
		}
	}
}
