using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_5
{
    public class Program
    {
        static void Main(string[] args)
        {
            CustomerRepository customerRepo = new CustomerRepository();
            List<Customer> customerList = customerRepo.GetList();

            customerRepo.AddCustomer("John", "Smith", 1);
            customerRepo.AddCustomer("Jane", "Smith", 2);
            customerRepo.AddCustomer("John", "Smith", 3);

            string input = null;
            while(input != "5")
            {
                Console.Clear();
                Console.WriteLine($"What would you like to do?" +
                    $"\n1. Add New User" +
                    $"\n2. View all Users" +
                    $"\n3. Update User" +
                    $"\n4. Remove User" +
                    $"\n5. Exit");
                input = Console.ReadLine();

                if (input == "1")
                {
                    Console.Clear();
                    Console.Write("Add new user first name: ");
                    string newFirst = Console.ReadLine();

                    Console.Write("Add new user last name: ");
                    string newLast = Console.ReadLine();

                    Console.WriteLine($"Which type is this new user?" +
                        $"\n1. Potential" +
                        $"\n2. Current" +
                        $"\n3. Past");
                    int valid = 0;
                    int newType = 1;
                    while (valid == 0)
                    {
                        newType = Int32.Parse(Console.ReadLine());
                        valid = 1;
                        switch (newType)
                        {
                            case 1:
                                break;
                            case 2:
                                break;
                            case 3:
                                break;
                            default:
                                Console.WriteLine("Invalid Input");
                                valid = 0;
                                break;
                        }
                    }
                    customerRepo.AddCustomer(newFirst, newLast, newType);
                }
                else if (input == "2")
                {
                    Console.Clear();
                    customerList.Sort((x, y) => string.Compare(x.LastName, y.LastName));
                    Console.WriteLine("UserID\tFirst\tLast\tCustomer Type\tEmail Sent");
                    customerRepo.Recount();
                    foreach (Customer customer in customerList)
                    {
                        string email = null;
                        switch (customer.Type)
                        {
                            case CustomerType.Potential:
                                email = "\tWe currently have the lowest rates on Helicopter Insurance!";
                                break;
                            case CustomerType.Current:
                                email = "\tThank you for your work with us. We appreciate your loyalty. Here's a coupon.";
                                break;
                            case CustomerType.Past:
                                email = "\tIt's been a long time since we've heard from you, we want you back!";
                                break;
                        }
                        Console.WriteLine($"{customer} {email}");
                    }

                    Console.Read();
                }
                else if (input == "3") 
                {
                    Console.Clear();

                    Console.Write("Enter the customer ID you would like to update: ");
                    int response = Int32.Parse(Console.ReadLine());
                    if(customerList.Exists(x => x.UserID == response))
                    {
                        foreach (Customer customer in customerList)
                        {
                            if (customer.UserID == response)
                            {
                                Console.WriteLine($"1. First Name: {customer.FirstName}" +
                                    $"\n2. Last Name: {customer.LastName}" +
                                    $"\n3. Customer Type: {customer.Type}" +
                                    $"\n4. Return to Menu" +
                                    $"\n\nEnter the number to update: ");
                                int updateResponse = Int32.Parse(Console.ReadLine());
                                switch (updateResponse)
                                {
                                    case 1:
                                        Console.Write("Enter new First Name: ");
                                        customer.FirstName = Console.ReadLine();
                                        break;
                                    case 2:
                                        Console.Write("Enter new Last Name: ");
                                        customer.LastName = Console.ReadLine();
                                        break;
                                    case 3:
                                        Console.WriteLine($"Enter new Customer Type: " +
                                            $"\n\t1. Potential" +
                                            $"\n\t2. Current" +
                                            $"\n\t3. Past");
                                        int updatedType = Int32.Parse(Console.ReadLine());

                                        if (updatedType == 1)
                                            customer.Type = CustomerType.Potential;
                                        else if (updatedType == 2)
                                            customer.Type = CustomerType.Current;
                                        else if (updatedType == 3)
                                            customer.Type = CustomerType.Past;
                                        else
                                            Console.WriteLine("Invalid type.");
                                        break;
                                    case 4:
                                        Console.WriteLine("Press ENTER to return to main menu");
                                        break;
                                    default:
                                        Console.WriteLine("Invalid Input");
                                        break;
                                }
                                break;
                            }
                        }
                    }
                    else
                        Console.WriteLine($"No user exists with that ID.");

                    Console.ReadLine();
                }
                else if (input == "4")
                {
                    Console.Clear();

                    Console.Write("Enter the user's ID you would like to remove: ");
                    int response = Int32.Parse(Console.ReadLine());
                    if (customerList.Exists(x => x.UserID == response))
                    {
                        customerRepo.RemoveCustomer(response);
                        Console.WriteLine("User Removed.");
                    }
                    else
                        Console.WriteLine($"No user exists with that ID.");

                    Console.ReadLine();
                }
                else if (input == "5")
                {
                    break;
                }
            }
            
            customerRepo.RemoveCustomer(2);
            foreach (Customer customer in customerList)
            {
                Console.WriteLine(customer.UserID);
            }
        }
    }
}