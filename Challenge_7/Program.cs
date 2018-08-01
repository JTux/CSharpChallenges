using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_7
{
    class Program
    {
        static void Main(string[] args)
        {
            PartyRepository boothRepo = new PartyRepository();
            List<Party> partyList = boothRepo.GetParties();

            int partyNumber = 1;

            var hardFoodBoothList = new List<Food>()
            {
                new Food("Hamburger", 20, 3.50m),
                new Food("Veggie Burger", 7, 4.50m),
                new Food("Hot Dog", 13, 2.25m)
            };
            var hardTreatBoothList = new List<Food>()
            {
                new Food("Ice Cream", 27, 1.50m),
                new Food("Pop Corn", 13, 1.00m)
            };
            var hardBoothList = new List<Booth>()
            {
                new Booth(BoothType.Food,hardFoodBoothList, 25.00m),
                new Booth(BoothType.Treat,hardTreatBoothList, 22.00m)
            };
            Party hardParty = new Party(hardBoothList, partyNumber);
            partyList.Add(hardParty);

            partyNumber++;

            string input = null;
            while (input != "3")
            {
                Console.Clear();
                Console.WriteLine($"What action would you like to do?" +
                    $"\n1. List all parties" +
                    $"\n2. Add new party" +
                    $"\n3. Exit");
                input = Console.ReadLine();
                if (input == "1")
                {
                    Console.Clear();
                    if (partyList.Count > 0)
                    {
                        Console.WriteLine("Event ID \tTickets \tCost");
                        foreach (Party party in partyList)
                        {
                            Console.WriteLine(party);
                        }
                        Console.WriteLine($"\n1. View Party \n2. Back to Menu");
                        string seeMore = Console.ReadLine();

                        if (seeMore == "1")
                        {
                            Console.Write("Enter Event ID to view: ");
                            string seeMoreResponse = Console.ReadLine();

                            Console.Clear();
                            Console.WriteLine($"Event {seeMoreResponse} details:");

                            foreach (Party party in partyList)
                            {
                                if (party.PartyNumber.ToString() == seeMoreResponse)
                                {
                                    foreach (Booth booth in party.BoothList)
                                    {
                                        Console.WriteLine(booth);
                                        foreach (Food food in booth.FoodTypes)
                                        {
                                            Console.WriteLine(food);
                                        }
                                    }
                                    Console.ReadLine();
                                    break;
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("There are no parties listed.");
                        Console.Read();
                    }
                }
                else if (input == "2")
                {
                    List<Booth> newBoothList = new List<Booth>();

                    Console.Clear();
                    string boothCreation = null;
                    while (boothCreation != "n")
                    {
                        //New Booth
                        List<Food> newFoodList = new List<Food>();
                        BoothType newBoothType = BoothType.Food;
                        Console.Clear();
                        Console.WriteLine($"Enter the type of booth to add: " +
                            $"\n1. Food" +
                            $"\n2. Treat");

                        string newBoothKind = Console.ReadLine();
                        string boothTypeString = null;
                        switch (newBoothKind)
                        {
                            case "1":
                                newBoothType = BoothType.Food;
                                boothTypeString = "Food Booth";
                                break;
                            case "2":
                                newBoothType = BoothType.Treat;
                                boothTypeString = "Treat Booth";
                                break;
                        }

                        Console.Clear();
                        Console.WriteLine($"{boothTypeString}");
                        string another = "y";
                        while (another != "n")
                        {
                            Console.Write("\nEnter type of food: ");
                            string foodName = Console.ReadLine();
                            Console.Write("Enter amount of tickets used: ");
                            int tickets = Int32.Parse(Console.ReadLine());
                            Console.Write($"Enter cost per {foodName}: $");
                            decimal cost = decimal.Parse(Console.ReadLine());

                            Food newFoodItem = new Food(foodName, tickets, cost);
                            newFoodList.Add(newFoodItem);

                            Console.Write("Would you like to add another food to this booth? (Y/N): ");
                            another = Console.ReadLine().ToLower();
                            if (another != "y")
                            {
                                if (another == "n")
                                {
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Invalid Input");
                                    Console.Write("Would you like to add another food to this booth? (Y/N): ");
                                    another = Console.ReadLine().ToLower();
                                }
                            }
                        }

                        Console.Write("\nEnter total cost of miscellaneous expenses: $");
                        decimal miscCost = decimal.Parse(Console.ReadLine());
                        Booth newBooth = new Booth(newBoothType, newFoodList, miscCost);
                        newBoothList.Add(newBooth);


                        Console.Clear();
                        Console.Write($"{boothTypeString} added." +
                            $"\nWould you like to create another booth for this party? (Y/N): ");
                        boothCreation = Console.ReadLine().ToLower();
                        if (boothCreation != "y")
                        {
                            if (boothCreation == "n")
                            {
                                Party newParty = new Party(newBoothList, partyNumber);
                                partyNumber++;
                                partyList.Add(newParty);
                                break;
                            }
                            else
                            {
                                Console.WriteLine($"Invalid Input" +
                                    $"\nWould you like to create another booth for this party? (Y/N): ");
                                boothCreation = Console.ReadLine().ToLower();
                            }
                        }
                    }
                }
            }
        }
    }
}