static void Main(string[] args)
{

	
	Recipe recipe = new Recipe();
	
	while (true)
	{
		Console.WriteLine("\nChoose an option:");
		Console.WriteLine("1. Enter Recipe Details");
		Console.WriteLine("2. Display Recipe");
		Console.WriteLine("3. Scale Recipe / Reset to Original");
		Console.WriteLine("4. Clear Recipe");
		Console.WriteLine("5. Exit");

		int choice;
		if (!int.TryParse(Console.ReadLine(), out choice))
		{
			Console.WriteLine("Invalid input. Please enter a number.");
			continue;
		}

		switch (choice)
		{
			case 1:
				
				Console.ForegroundColor = ConsoleColor.Green;
				Console.WriteLine("\nEnter Recipe Details:");
				Console.ResetColor();

				
				recipe.EnterRecipeDetails();
				break;


			case 2:
				recipe.DisplayRecipe();
				break;
			case 3:
				recipe.ScaleRecipe();
				break;
			case 4:
				recipe.ClearRecipe();
				break;
			case 5:
				Console.WriteLine("Exiting the Recipe App.");
				return;
			default:
				Console.WriteLine("Invalid choice. Please try again.");
				break;
		}
	}
}

	
