using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_1
{
    class Program
    {
        static void Main(string[] args)
        {
            MenuRepository menuRepo = new MenuRepository();
            List<Menu> menu = menuRepo.DisplayList();

            string outPut = null;
            int itemCount = 0;

            while (true)
            {
                Console.Clear();
                Console.Write($"{outPut}" +
                    $"What action would you like to do?\n" +
                    $"1. Add Item to Menu\n" +
                    $"2. View List\n" +
                    $"3. Remove Item\n" +
                    $"4. Exit\n" +
                    $"   ");
                outPut = null;

                string response = Console.ReadLine();

                if (response == "1")
                {
                    Console.Clear();
                    Console.Write("Enter the name of the item: ");
                    string newName = Console.ReadLine();

                    Console.Write($"Enter the description for the {newName}: ");
                    string newDesc = Console.ReadLine();

                    Console.Write($"Enter the list of ingredients for the {newName}: ");
                    string newIngredients = Console.ReadLine();

                    Console.Write($"Enter the price for the {newName}: ");
                    decimal newPrice = 0m;
                    bool valid = false;
                    while (!valid)
                    {
                        string input = Console.ReadLine();
                        if (decimal.TryParse(input, out newPrice))
                            valid = true;
                        else
                            Console.WriteLine("Invalid input, please enter a number.");
                    }

                    menuRepo.AddItem(newName, newDesc, newIngredients, newPrice);

                    itemCount++;
                    outPut = $"{newName} has been added to the menu as item number {itemCount}.\n";
                }

                else if (response == "2")
                {
                    Console.Clear();
                    foreach (var item in menu)
                    {
                        Console.WriteLine($"{item.MealNumber}. {item.MealName}\n" +
                            $"   Description: {item.MealDescription}\n" +
                            $"   Ingredients: {item.MealIngredients}\n" +
                            $"   Price: ${item.MealPrice}\n");
                    }
                    if (menu.Count() == 0)
                    {
                        Console.WriteLine("The Menu is currently empty.");
                    }
                    Console.ReadLine();
                }

                else if (response == "3")
                {
                    Console.Clear();
                    if (menu.Count() == 0)
                    {
                        Console.WriteLine("The Menu is currently empty.");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.Write("Enter the menu item number you want to remove: ");
                        int num = Convert.ToInt32(Console.ReadLine());
                        foreach (Menu item in menu)
                        {
                            if (num == item.MealNumber)
                            {
                                Console.Write($"Are you sure you would like to delete {item.MealName} from the menu?\n" +
                                    $"(Y/N): ");
                                string delResponse = Console.ReadLine().ToLower();
                                if (delResponse == "y")
                                {
                                    num--;
                                    menuRepo.RemoveItem(menu[num]);
                                    outPut = $"{item.MealName} has been removed to the menu.\n";

                                    foreach (Menu oldItem in menu)
                                    {
                                        int spot = menu.IndexOf(oldItem);
                                        spot++;
                                        oldItem.MealNumber = spot;
                                    }
                                    itemCount--;
                                }
                                break;
                            }
                        }
                    }
                }

                else if (response == "4")
                {
                    break;
                }

                else
                {
                    outPut = "Improper input. Please try again.\n";
                }
            }
        }
    }
}