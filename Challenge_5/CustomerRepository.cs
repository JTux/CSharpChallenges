using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_5
{
    public class CustomerRepository
    {
        private List<Customer> _customerList = new List<Customer>();

        int customerCount = 0;

        public List<Customer> GetList()
        {
            return _customerList;
        }

        public void AddCustomer(string first, string last, int typeNum)
        {
            customerCount++;
            Customer newCustomer = new Customer(customerCount, first, last, typeNum);

            _customerList.Add(newCustomer);
        }

        public void RemoveCustomer(int customerID)
        {
            int idNum = customerID;
            idNum--;
            _customerList.Remove(_customerList[idNum]);

            foreach (Customer customer in _customerList)
            {
                int userPosition = _customerList.IndexOf(customer);
                int expectedID = userPosition + 1;

                if(customer.UserID != expectedID)
                    customer.UserID--;
            }
            customerCount--;
        }
    }
}
