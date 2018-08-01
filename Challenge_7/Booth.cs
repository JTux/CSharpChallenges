using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_7
{
    public enum BoothType
    {
        Food, Treat
    }

    public class Booth
    {
        private List<Food> _foodList = new List<Food>();

        public Booth(BoothType newBoothType, List<Food> foodList, decimal misc)
        {
            TypeOfBooth = newBoothType;
            foreach (Food newFood in foodList)
            {
                _foodList.Add(newFood);
                TotalTickets = TotalTickets + newFood.TicketsUsed;
                TotalFoodCost = TotalFoodCost + (newFood.TicketsUsed * newFood.CostPer);
            }
            FoodTypes = _foodList;
            MiscCost = misc;
            TotalCost = TotalFoodCost + MiscCost;
        }

        public BoothType TypeOfBooth { get; set; }
        public List<Food> FoodTypes { get; set; }
        public int TotalTickets { get; set; }
        public decimal TotalFoodCost { get; set; }
        public decimal MiscCost { get; set; }
        public decimal TotalCost { get; set; }

        public override string ToString()
        {
            return $"Booth Type: {TypeOfBooth}";
        }
    }
}