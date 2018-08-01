using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_2
{

    class Program
    {
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

        static void Main(string[] args)
        {
            ClaimRepository claimRepo = new ClaimRepository();
            Queue<Claim> claimQueue = claimRepo.GetClaims();

            string response = null;
            while (response != "4")
            {
                Console.Clear();
                Console.Write($"Which action would you like to take?" +
                    $"\n1. View all claims." +
                    $"\n2. Process next claim." +
                    $"\n3. Enter new claim." +
                    $"\n4. Exit." +
                    $"\n   ");
                response = Console.ReadLine();
                claimQueue = claimRepo.GetClaims();

                if (response == "1")
                {
                    Console.Clear();

                    Console.WriteLine($"ClaimID\t " +
                        $"Type\t" +
                        $"Description\t" +
                        $"Amount\t" +
                        $"DateOfAccident\t" +
                        $"DateOfClaim\t" +
                        $"IsValid");

                    foreach (Claim claim in claimQueue)
                    {
                        Console.WriteLine($" {claim.ClaimID}\t " +
                            $"{claim.ClaimType}\t" +
                            $"{claim.Description}\t\t" +
                            $"${claim.ClaimAmount}\t" +
                            $"{claim.DateOfIncident.ToShortDateString()}\t" +
                            $"{claim.DateOfClaim.ToShortDateString()}\t" +
                            $"{claim.IsValid}");
                    }

                    Console.Read();
                }
                else if (response == "2")
                {
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

                        Console.Write("Do you want to deal with this claim now? (y/n): ");
                        string delClaim = Console.ReadLine();

                        if (delClaim == "y")
                        {
                            claimQueue.Dequeue();
                            foreach (Claim claim in claimQueue)
                            {
                                claim.ClaimID--;
                            }
                            claimRepo.CountDown();
                        }
                    }
                }
                else if (response == "3")
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

                    claimRepo.AddClaim(type, desc, amount, incidentDate, claimDate);
                }
                else if (response == "4")
                {
                    break;
                }
            }
        }
    }
}