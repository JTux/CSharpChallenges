using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_2_Rebuilt
{
    class ProgramUI
    {
        private ClaimRepository _claimRepo = new ClaimRepository();

        private static DateTime CreateDate(string prompt)
        {
            Console.WriteLine($"{prompt} (MM/DD/YYYY)");
            string newDateString = Console.ReadLine();
            DateTime newDate = DateTime.Parse(newDateString);

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
                        ShowAllClaims();
                        break;
                    case 2:
                        ProcessNextClaim();
                        break;
                    case 3:
                        AddClaim();
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
            Console.WriteLine($"Which action would you like to take?" +
                    $"\n1. View all claims." +
                    $"\n2. Process next claim." +
                    $"\n3. Enter new claim." +
                    $"\n4. Exit.");
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

        private void ShowAllClaims()
        {
            Queue<Claim> claimQueue = _claimRepo.GetClaims();
            Console.Clear();

            Console.WriteLine("{0,-10} {1,-12} {2,-8} {3,-18} {4,-15} {5,-10} {6}", "Claim ID", "Claim Type", "Amount", "Date Of Accident", "Date Of Claim", "Is Valid", "Description");

            foreach (Claim claim in claimQueue)
            {

                Console.WriteLine(" {0,-10} {1,-12} ${2,-8} {3,-18} {4,-15} {5,-10} {6}", claim.ClaimID, claim.ClaimType, claim.ClaimAmount, claim.DateOfIncident.ToShortDateString(), claim.DateOfClaim.ToShortDateString(), claim.IsValid, claim.Description);
            }
            Console.ReadLine();
        }

        private void ProcessNextClaim()
        {
            Queue<Claim> claimQueue = _claimRepo.GetClaims();

            Console.Clear();
            if (claimQueue.Count != 0)
            {
                Claim topItem = claimQueue.Peek();
                Console.WriteLine($"Here are the details for the next claim to be handled:\n" +
                    $"  ClaimID: {topItem.ClaimID}\n" +
                    $"  Type: {topItem.ClaimType}\n" +
                    $"  Description: {topItem.Description}\n" +
                    $"  Amount: {topItem.ClaimAmount}\n" +
                    $"  DateOfIncident: {topItem.DateOfIncident.ToShortDateString()}\n" +
                    $"  DateOfClaim: {topItem.DateOfClaim.ToShortDateString()}\n" +
                    $"  IsValid: {topItem.IsValid}");

                while (true)
                {
                    Console.Write("Do you want to deal with this claim now? (y/n): ");
                    string delClaim = Console.ReadLine();
                    if (delClaim == "y")
                    {
                        claimQueue.Dequeue();
                        foreach (Claim claim in claimQueue)
                        {
                            claim.ClaimID--;
                        }
                        _claimRepo.CountDown();
                        Console.WriteLine("Claim processed.");
                        break;
                    }
                    else if (delClaim != "n")
                    {
                        Console.WriteLine("Invalid input");
                    }
                    else
                    {
                        Console.WriteLine("Claim not processed.");
                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine("There are currently no claims to process.");
            }
            Console.ReadLine();
        }

        private void AddClaim()
        {
            ClaimType type = ClaimType.Car;
            string outPut = null;
            while (true)
            {
                Console.Clear();
                Console.Write($"{outPut}" +
                    $"Enter the type of claim being made." +
                    $"\n1. Car \n2. Home \n3. Theft \n   ");

                string inType = Console.ReadLine();
                if (inType == "1")
                {
                    type = ClaimType.Car;
                    break;
                }
                else if (inType == "2")
                {
                    type = ClaimType.Home;
                    break;
                }
                else if (inType == "3")
                {
                    type = ClaimType.Theft;
                    break;
                }
                else
                {
                    outPut = "Invalid Input, please try again.\n";
                }
            }

            Console.Clear();
            Console.Write("Enter the claim amount: $");
            string claimAmountAsString = Console.ReadLine();
            decimal amount = Decimal.Parse(claimAmountAsString);

            Console.Write("\nEnter a brief description for the claim: ");
            string desc = Console.ReadLine();

            DateTime claimDate = CreateDate("\nEnter the Month, Day, and Year of the claim.");
            DateTime incidentDate = CreateDate("\nEnter the Month, Day, and Year of the incident.");

            _claimRepo.AddClaim(type, desc, amount, incidentDate, claimDate);
        }
    }
}
