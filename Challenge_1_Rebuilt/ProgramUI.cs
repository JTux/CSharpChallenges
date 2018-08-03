using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_1_Rebuilt
{
    public class ProgramUI
    {
        private MenuRepository _menuRepo = new MenuRepository();

        private string outPut = null;
        private int itemCount = 0;

        public void Start()
        {
            StartMenu();
        }

        private void StartMenu()
        {

            bool continueToRunMenu = true;

            while (continueToRunMenu)
            {
                PrintMenu();
                int choice = GetAndParseInput(null);

                switch (choice)
                {
                    case 1:
                        AddItem();
                        break;
                    case 2:
                        ShowList();
                        break;
                    case 3:
                        RemoveItem();
                        break;
                    case 4:
                        continueToRunMenu = false;
                        break;
                    default:
                        PrintMenu();
                        break;
                }
            }
        }

        private void PrintMenu()
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
        }

        private int GetAndParseInput(string textInput)
        {
            int choice = 0;
            Console.WriteLine(textInput);

            bool valid = false;
            while (!valid)
            {
                string choiceAsString = Console.ReadLine();
                if (Int32.TryParse(choiceAsString, out choice))
                    valid = true;
                else
                    Console.WriteLine("Invalid input, please enter a number.");
            }

            return choice;
        }

        private void AddItem()
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

            _menuRepo.AddItem(newName, newDesc, newIngredients, newPrice);

            itemCount++;
            outPut = $"{newName} has been added to the menu as item number {itemCount}.\n";
        }

        private void ShowList()
        {
            List<Menu> menu = _menuRepo.GetList();

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

        private void RemoveItem()
        {
            List<Menu> menu = _menuRepo.GetList();

            Console.Clear();
            if (menu.Count() == 0)
            {
                Console.WriteLine("The Menu is currently empty.");
                Console.ReadLine();
            }
            else
            {
                int num;

                Console.Write("Enter the menu item number you want to remove: ");
                bool isNumber = Int32.TryParse(Console.ReadLine(), out num);
                if (isNumber)
                {
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
                                _menuRepo.RemoveItem(menu[num]);
                                outPut = $"{item.MealName} has been removed to the menu.\n";

                                foreach (Menu oldItem in menu)
                                {
                                    int spot = menu.IndexOf(oldItem);
                                    spot++;
                                    oldItem.MealNumber = spot;
                                }
                                itemCount--;
                            }
                            else if (delResponse != "n")
                            {
                                Console.WriteLine("Invalid input. Item not deleted.");
                                Console.ReadLine();
                            }
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid input, please enter the menu item ID number");
                            Console.ReadLine();
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input, please enter the menu item ID number");
                    Console.ReadLine();
                }
            }
        }
    }
}