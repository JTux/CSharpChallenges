using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_5
{
    public enum CustomerType
    {
        Potential, Current, Past
    }
    public class Customer
    {
        private string extraTab;

        public Customer(int id, string first, string last, int typeNum)
        {
            UserID = id;
            FirstName = first;
            LastName = last;
            switch (typeNum)
            {
                case 1:
                    Type = CustomerType.Potential;
                    break;
                case 2:
                    Type = CustomerType.Current;
                    break;
                case 3:
                    Type = CustomerType.Past;
                    extraTab = "\t";
                    break;
            }
        }

        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public CustomerType Type { get; set; }

        public override string ToString()
        {
            return $"  {UserID}\t{FirstName}\t{LastName}\t{Type}{extraTab}";
        }
    }
}
