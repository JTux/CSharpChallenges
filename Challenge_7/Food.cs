using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_7
{
    public class Food
    {
        public Food(string name, int tickets, decimal cost)
        {
            FoodName = name;
            TicketsUsed = tickets;
            CostPer = cost;
        }

        public string FoodName { get; set; }
        public int TicketsUsed { get; set; }
        public decimal CostPer { get; set; }

        public override string ToString()
        {
            return $"   Type of Food: {FoodName}\t\tTickets used: {TicketsUsed} \tCost per {FoodName}: {CostPer}";
        }
    }
}
