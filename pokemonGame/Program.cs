using System;

class Program
{
       static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Pokémon Game!");
        Console.WriteLine("How are you?");
        Console.WriteLine("Choose your starter Pokémon:");
        Console.WriteLine("1. Bulbasaur");
        Console.WriteLine("2. Charmander");
        Console.WriteLine("3. Squirtle");
        string choice = Console.ReadLine();
        switch (choice)
        {
            case "1":
                Console.WriteLine("You chose Bulbasaur!");
                break;
            case "2":
                Console.WriteLine("You chose Charmander!");
                break;
            case "3":
                Console.WriteLine("You chose Squirtle!");
                break;
            default:
                Console.WriteLine("Invalid choice. Please restart the game.");
                break;
        }
        // Additional game logic would go here
    }
}