using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_3
{
    public class OutingRepository
    {
        List<Outing> _outingList = new List<Outing>();

        public List<Outing> GetList()
        {
            return _outingList;
        }

        public void AddOuting(EventType type, int attendees, DateTime date, decimal individualCost, decimal totalEventCost)
        {
            Outing newOuting = new Outing(type, attendees, date, individualCost, totalEventCost);
            _outingList.Add(newOuting);
        }

        public decimal TotalCost()
        {
            decimal totalCost = 0m;

            foreach(Outing outing in _outingList)
            {
                totalCost = totalCost + outing.TotalEventCost;
            }

            return totalCost;
        }

        public decimal GetCostByType(EventType inType)
        {
            decimal totalCost = 0m;

            foreach (Outing outing in _outingList)
            {
                if (outing.OutingType == inType)
                {
                    totalCost = totalCost + outing.TotalEventCost;
                }
            }

            return totalCost;
        }
    }
}
