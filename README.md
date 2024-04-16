## Features

- Enter Recipe Details: Allows users to input details for a recipe including ingredients and steps.
- Display Recipe: Displays the entered recipe details.
- Scale Recipe / Reset to Original: Scales the quantities of ingredients in the recipe or resets them to their original values.
- Clear Recipe: Clears all entered recipe details.
- Exit: Exits the Recipe App.

## Usage

1. Creating a Recipe Object: Instantiate a new Recipe object.
2. Entering Recipe Details: Call the `EnterRecipeDetails()` method to input recipe details.
3. Displaying Recipe: Call the `DisplayRecipe()` method to display the entered recipe details.
4. Scaling Recipe: Call the `ScaleRecipe()` method to scale the recipe quantities or reset to original values.
5. Clearing Recipe:Call the `ClearRecipe()` method to clear all entered recipe details.

## Example


using System;

namespace ST10203525PoePartOne
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new Recipe object
            Recipe recipe = new Recipe();

            // Enter recipe details
            recipe.EnterRecipeDetails();

            // Display recipe
            recipe.DisplayRecipe();
        }
    }
}
author ST10203525
