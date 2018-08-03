using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_3_Rebuilt
{
    class ProgramUI
    {
        private OutingRepository _outingRepo = new OutingRepository();

        private static DateTime CreateDate(string prompt)
        {
            Console.WriteLine(prompt);
            Console.Write("   Month (MM): ");
            string monthAsString = Console.ReadLine();
            int month = Int32.Parse(monthAsString);
            Console.Write("   Day (DD): ");
            string dayAsString = Console.ReadLine();
            int day = Int32.Parse(dayAsString);
            Console.Write("   Year (YYYY): ");
            string yearAsString = Console.ReadLine();
            int year = Int32.Parse(yearAsString);

            DateTime newDate = new DateTime(year, month, day);
            return newDate;
        }

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
                        ShowAllOutings();
                        break;
                    case 2:
                        AddOuting();
                        break;
                    case 3:
                        CalculateCosts();
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
            Console.WriteLine($"What would you like to do?" +
                $"\n1. View all outings" +
                $"\n2. Create new outing" +
                $"\n3. Calculate costs" +
                $"\n4. Exit");
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

        private void ShowAllOutings()
        {
            var outingList = _outingRepo.GetList();

            Console.Clear();
            if (outingList.Count == 0)
            {
                Console.WriteLine("There are currently no events recorded.");
            }
            else
            {
                foreach (Outing outing in outingList)
                {
                    Console.WriteLine(outing);
                }
            }
            Console.ReadLine();
        }

        private void AddOuting()
        {
            Console.Clear();
            Console.WriteLine($"Select an outing type:\n" +
                $"1. Amusement Park\n" +
                $"2. Bowling\n" +
                $"3. Concert\n" +
                $"4. Golf");
            int input = Int32.Parse(Console.ReadLine());
            EventType newEvent = EventType.AmusementPark;
            string typeHeader = null;
            switch (input)
            {
                case 1:
                    newEvent = EventType.AmusementPark;
                    typeHeader = "Amusement Park Event";
                    break;
                case 2:
                    newEvent = EventType.Bowling;
                    typeHeader = "Bowling Event";
                    break;
                case 3:
                    newEvent = EventType.Concert;
                    typeHeader = "Concert Event";
                    break;
                case 4:
                    newEvent = EventType.Golf;
                    typeHeader = "Golf Event";
                    break;
                default:
                    Console.WriteLine("Invalid input");
                    break;
            }
            Console.Clear();
            Console.WriteLine(typeHeader);
            Console.Write("Enter the amount of attendees: ");
            int attendance = Int32.Parse(Console.ReadLine());

            var date = CreateDate("Enter the Month, Day, and Year of the event: ");

            Console.Write("Enter the cost per individual for the event: $");
            decimal individualCost = Decimal.Parse(Console.ReadLine());

            Console.Write("Enter the total cost for the event: $");
            decimal totalEventCost = Decimal.Parse(Console.ReadLine());

            _outingRepo.AddOuting(newEvent, attendance, date, individualCost, totalEventCost);

            Console.ReadLine();
        }

        private void CalculateCosts()
        {
            Console.Clear();
            Console.WriteLine($"What calculations would you like to do? \n1. Total costs for all outings \n2. Total oosts for outings of a specific type");
            string calcResponse = Console.ReadLine();
            if (calcResponse == "1")
            {
                Console.Clear();
                Console.WriteLine($"Total cost for all outings: ${_outingRepo.TotalCost()}");
            }
            else if (calcResponse == "2")
            {
                Console.Clear();
                Console.WriteLine($"Enter the outing type would you like to sort by:" +
                    $"\n1. Amusement Park" +
                    $"\n2. Bowling" +
                    $"\n3. Concert" +
                    $"\n4. Golf");
                var typeNum = Int32.Parse(Console.ReadLine());
                EventType type = EventType.AmusementPark;
                switch (typeNum)
                {
                    case 1:
                        type = EventType.AmusementPark;
                        break;
                    case 2:
                        type = EventType.Bowling;
                        break;
                    case 3:
                        type = EventType.Concert;
                        break;
                    case 4:
                        type = EventType.Golf;
                        break;
                    default:
                        Console.WriteLine("Error");
                        break;
                }
                Console.Clear();
                Console.WriteLine($"Total cost for {type}: ${_outingRepo.GetCostByType(type)}");
            }
            Console.ReadLine();
        }
    }
}
