using System;

namespace ST10203525PoePartOne
{
	internal class Recipe
	{
		// Private fields to store recipe details
		private string[] ingredientNames; // Array to store ingredient names
		private double[] ingredientQuantities; // Array to store ingredient quantities
		private string[] ingredientUnits; // Array to store ingredient units
		private string[] recipeSteps; // Array to store recipe steps
		private double[] originalQuantities; // Array to store original ingredient quantities (not currently used)

		// Method to input recipe details
		public void EnterRecipeDetails()
		{
			try
			{
				// Variable to store the number of ingredients
				int numberOfIngredients;

				// Input validation loop for the number of ingredients
				while (true)
				{
					Console.ForegroundColor = ConsoleColor.White;
					Console.WriteLine("Please enter the number of ingredients:");
					Console.ResetColor();

					if (!int.TryParse(Console.ReadLine(), out numberOfIngredients))
					{
						Console.ForegroundColor = ConsoleColor.Magenta;
						Console.WriteLine("Invalid input. Please enter a number for the number of ingredients.");
						Console.ResetColor();
					}
					else if (numberOfIngredients <= 0)
					{
						Console.ForegroundColor = ConsoleColor.Magenta;
						Console.WriteLine("Invalid input. The number of ingredients must be a positive integer.");
						Console.ResetColor();
					}
					else
					{
						break; // Exit the loop if input is valid
					}
				}

				// Initialize arrays based on the number of ingredients
				ingredientNames = new string[numberOfIngredients];
				ingredientQuantities = new double[numberOfIngredients];
				ingredientUnits = new string[numberOfIngredients];

				// Loop to input details for each ingredient
				for (int i = 0; i < numberOfIngredients; i++)
				{
					Console.WriteLine($"\nPlease enter details for ingredient {i + 1}:");
					Console.Write("Name of Ingredient: ");
					ingredientNames[i] = Console.ReadLine();

					// Input validation loop for ingredient quantity
					while (true)
					{
						Console.Write("Quantity of ingredients: ");
						if (!double.TryParse(Console.ReadLine(), out double quantity))
						{
							Console.ForegroundColor = ConsoleColor.Magenta;
							Console.WriteLine("Invalid input. Please enter a numeric value for quantity.");
							Console.ResetColor();
						}
						else if (quantity <= 0)
						{
							Console.ForegroundColor = ConsoleColor.Magenta;
							Console.WriteLine("Invalid input. Quantity must be a positive number.");
							Console.ResetColor();
						}
						else
						{
							ingredientQuantities[i] = quantity;
							break; // Exit the loop if input is valid
						}
					}

					Console.Write("Please enter the unit for that quantity: ");
					ingredientUnits[i] = Console.ReadLine();
				}

				// Variable to store the number of steps
				int numberOfSteps;

				// Input validation loop for the number of steps
				while (true)
				{
					Console.WriteLine("\nPlease enter the number of steps:");

					if (!int.TryParse(Console.ReadLine(), out numberOfSteps))
					{
						Console.ForegroundColor = ConsoleColor.Magenta;
						Console.WriteLine("Invalid input. Please enter a number for the number of steps.");
						Console.ResetColor();
					}
					else if (numberOfSteps <= 0)
					{
						Console.ForegroundColor = ConsoleColor.Magenta;
						Console.WriteLine("Invalid input. The number of steps must be a positive integer.");
						Console.ResetColor();
					}
					else
					{
						break; // Exit the loop if input is valid
					}
				}

				// Initialize array to store recipe steps
				recipeSteps = new string[numberOfSteps];

				// Loop to input recipe steps
				for (int j = 0; j < numberOfSteps; j++)
				{
					Console.WriteLine($"\nPlease Enter step {j + 1}:");
					recipeSteps[j] = Console.ReadLine();
				}

				Console.ForegroundColor = ConsoleColor.Yellow;
				Console.WriteLine("Recipe details entered successfully!");
				Console.ResetColor();
			}
			catch (Exception ex)
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine($"An error occurred: {ex.Message}");
				Console.ResetColor();
			}
		}

		// Method to display recipe details
		public void DisplayRecipe()
		{
			try
			{
				Console.ForegroundColor = ConsoleColor.DarkYellow;
				Console.WriteLine("\nRecipe Details:");
				Console.WriteLine("---------------");

				if (ingredientNames == null || recipeSteps == null)
				{
					Console.ForegroundColor = ConsoleColor.Magenta;
					Console.WriteLine("Recipe details are not entered yet.");
					Console.ResetColor();
					return;
				}

				// Display ingredients
				Console.WriteLine("\nIngredients:");
				for (int k = 0; k < ingredientNames.Length; k++)
				{
					Console.WriteLine($"{ingredientNames[k]} - {ingredientQuantities[k]} {ingredientUnits[k]}");
				}

				// Display steps
				Console.WriteLine("\nSteps:");
				for (int l = 0; l < recipeSteps.Length; l++)
				{
					Console.WriteLine($"{l + 1}. {recipeSteps[l]}");
				}

				Console.ResetColor();
			}
			catch (Exception ex)
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine($"An error occurred: {ex.Message}");
				Console.ResetColor();
			}
		}

		// Method to scale the recipe quantities or reset to original values
		public void ScaleRecipe()
		{
			try
			{
				if (recipeSteps == null || ingredientNames == null)
				{
					Console.ForegroundColor = ConsoleColor.Magenta;
					Console.WriteLine("Recipe details are not entered yet.");
					Console.ResetColor();
					return;
				}
				Console.ForegroundColor = ConsoleColor.Green;
				Console.WriteLine("Please enter the scaling factor (0.5, 2, or 3) to upscale the recipe, or 'reset' to revert to original values:");
				Console.ResetColor();
				string input = Console.ReadLine();

				if (input.Equals("reset", StringComparison.OrdinalIgnoreCase))
				{
					if (originalQuantities == null)
					{
						Console.ForegroundColor = ConsoleColor.Magenta;
						Console.WriteLine("Recipe has not been upscaled yet. Original values are already displayed.");
						Console.ResetColor();
						return;
					}

					ingredientQuantities = originalQuantities.ToArray();

					Console.ForegroundColor = ConsoleColor.Green;
					Console.WriteLine("\nRecipe reset to original values:");
					Console.ResetColor();
					DisplayRecipe();
					return;
				}

				if (!double.TryParse(input, out double scaleFactor) || (scaleFactor != 0.5 && scaleFactor != 2 && scaleFactor != 3))
				{
					Console.ForegroundColor = ConsoleColor.Magenta;
					Console.WriteLine("Invalid input. Please enter 0.5, 2, 3, or 'reset'.");
					Console.ResetColor();
					return;
				}

				if (originalQuantities == null)
				{
					originalQuantities = ingredientQuantities.ToArray();
				}

				for (int m = 0; m < ingredientQuantities.Length; m++)
				{
					ingredientQuantities[m] *= scaleFactor;
				}

				Console.WriteLine($"\nScaled Recipe (Factor: {scaleFactor}):");
				DisplayRecipe();

				Console.ForegroundColor = ConsoleColor.Cyan;
				Console.WriteLine("Quantity scaled successfully!");
				Console.ResetColor();
			}
			catch (Exception ex)
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine($"An error occurred: {ex.Message}");
				Console.ResetColor();
			}
		}

		// Method to clear the recipe details
		public void ClearRecipe()
		{
			try
			{
				Console.ForegroundColor = ConsoleColor.DarkRed;
				Console.WriteLine("Are you sure you want to clear the recipe? (yes/no)");
				Console.ResetColor();

				string confirmed = Console.ReadLine();

				if (confirmed.Equals("yes", StringComparison.OrdinalIgnoreCase))
				{
					ingredientNames = null;
					ingredientQuantities = null;
					ingredientUnits = null;
					recipeSteps = null;

					Console.ForegroundColor = ConsoleColor.Blue;
					Console.WriteLine("Recipe cleared. You can now enter a new recipe.");
					Console.ResetColor();
				}
				else if (confirmed.Equals("no", StringComparison.OrdinalIgnoreCase))
				{
					Console.ForegroundColor = ConsoleColor.Blue;
					Console.WriteLine("Clearing recipe canceled. Recipe data remains unchanged.");
					Console.ResetColor();
				}
				else
				{
					Console.ForegroundColor = ConsoleColor.Red;//confirm that you want to clear the recipe
					Console.WriteLine("Invalid input. Please enter 'yes' or 'no'.");
					Console.ResetColor();
				}
			}
			catch (Exception ex)
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine($"An error occurred: {ex.Message}");
				Console.ResetColor();
			}
		}
	}
}
