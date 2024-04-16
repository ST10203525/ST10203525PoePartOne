static void Main(string[] args)
{

	// Create a new Recipe object
	Recipe recipe = new Recipe();

	// Main loop for the Recipe App
	while (true)
	{
		// Display menu options
		Console.WriteLine("\nChoose an option:");
		Console.WriteLine("1. Enter Recipe Details");
		Console.WriteLine("2. Display Recipe");
		Console.WriteLine("3. Scale Recipe / Reset to Original");
		Console.WriteLine("4. Clear Recipe");
		Console.WriteLine("5. Exit");

		// Read user input for menu choice
		int choice;
		if (!int.TryParse(Console.ReadLine(), out choice))
		{
			Console.WriteLine("Invalid input. Please enter a number.");
			continue;
		}

		// Switch statement to execute user's choice
		switch (choice)
		{
			case 1:
				// Prompt user to enter recipe details
				Console.ForegroundColor = ConsoleColor.Green;
				Console.WriteLine("\nEnter Recipe Details:");
				Console.ResetColor();

				// Call method to enter recipe details
				recipe.EnterRecipeDetails();
				break;

			case 2:
				// Call method to display recipe
				recipe.DisplayRecipe();
				break;
			case 3:
				// Call method to scale recipe or reset to original
				recipe.ScaleRecipe();
				break;
			case 4:
				// Call method to clear recipe
				recipe.ClearRecipe();
				break;
			case 5:
				// Exit the Recipe App
				Console.WriteLine("Exiting the Recipe App.");
				return;
			default:
				// Invalid choice
				Console.WriteLine("Invalid choice. Please try again.");
				break;
		}
	}
}