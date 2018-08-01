using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_4
{
    class Program
    {
        static void Main(string[] args)
        {
            BadgeRepository badgeRepo = new BadgeRepository();
            Dictionary<int, List<string>> badgeDictionary = badgeRepo.GetDictionary();

            string response = null;
            while(response != "4")
            {
                Console.Clear();
                Console.WriteLine($"Hello Security Admin. What would you like to do?" +
                    $"\n1. Add a badge" +
                    $"\n2. Edit a badge" +
                    $"\n3. List all badges" +
                    $"\n4. Exit");
                response = Console.ReadLine();

                if (response == "1")
                {
                    Console.Clear();
                    List<string> doorList = new List<string>();
                    string doorResponse = "y";

                    Console.Write("What is the number on the badge: ");
                    int badgeNum = Int32.Parse(Console.ReadLine());
                    while (doorResponse != "n")
                    {
                        if (doorResponse == "y")
                        {
                            Console.Write("List a door that it needs access to: ");
                            string newDoor = Console.ReadLine();
                            doorList.Add(newDoor);
                            Console.Write("Are there any other doors? (y/n): ");
                            doorResponse = Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("Invalid Input");
                            Console.Write("Are there any other doors? (y/n): ");
                            doorResponse = Console.ReadLine();
                        }
                    }

                    badgeDictionary.Add(badgeNum, doorList);
                }
                else if (response == "2")
                {
                    Console.Clear();
                    Console.Write("Enter the badge number to edit: ");
                    int editBadge = Int32.Parse(Console.ReadLine());

                    if (badgeDictionary.Keys.Contains(editBadge))
                    {
                        List<string> tempList = badgeDictionary[editBadge];

                        Console.Write($"{editBadge} has access to doors: ");
                        foreach (string door in tempList)
                        {
                            Console.Write($"{door} ");
                        }
                        Console.WriteLine($"\nWhat would you like to do?" +
                            $"\n\t1. Remove a door" +
                            $"\n\t2. Add a door");
                        string editDoors = Console.ReadLine();
                        Console.Clear();
                        switch (editDoors)
                        {
                            case "1":
                                Console.WriteLine("Which door would you like to remove?");
                                int count = 0;
                                foreach (string door in tempList)
                                {
                                    count++;
                                    Console.WriteLine(count + ". " + door);
                                }

                                int removeDoor = Int32.Parse(Console.ReadLine());
                                if (removeDoor > 0)
                                    removeDoor--;

                                tempList.RemoveAt(removeDoor);
                                Console.Write($"Removed." +
                                    $"\n{editBadge} now has access to: ");
                                foreach (string door in tempList)
                                {
                                    Console.Write($"{door} ");
                                }
                                break;
                            case "2":
                                Console.Write("Enter the door you would like to add: ");
                                string addDoor = (Console.ReadLine());
                                tempList.Add(addDoor);
                                Console.WriteLine($"{addDoor} has been added to badge {editBadge}.");
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("There is no badge with that ID.");
                    }
                    Console.ReadLine();
                }
                else if (response == "3")
                {
                    Console.Clear();
                    Console.WriteLine("Key \t\tDoor Access");

                    for (int i = 0; i < badgeDictionary.Count; i++)
                    {
                        string doorListToString = "";
                        int count = 0;
                        string comma;
                        foreach (string door in badgeDictionary.Values.ElementAt(i))
                        {
                            count++;
                            if (count < badgeDictionary.Values.ElementAt(i).Count)
                                comma = ", ";
                            else
                                comma = "";
                            doorListToString = doorListToString + door + comma;
                        }
                        Console.WriteLine($"{badgeDictionary.Keys.ElementAt(i)}\t\t{doorListToString}");
                    }

                    Console.Read();
                }
                else if (response=="4")
                {
                    break;
                }
            }
        }
    }
}