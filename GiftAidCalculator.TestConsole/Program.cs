using System;
using GiftAidCalculatorCollaborators;

namespace GiftAidCalculator.TestConsole
{
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

		static void UpdateTaxRateAsAdmin()
		{
			Admin jg = new Admin();
			decimal newTaxRate;

			Console.WriteLine("Please Enter the new tax rate:");
			newTaxRate = decimal.Parse(Console.ReadLine());
			GiftAidCalculator.UpdateTaxRate(newTaxRate, jg);
			Console.WriteLine("Tax rate updated to: {0}", newTaxRate);
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
			        UpdateTaxRateAsAdmin();
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
