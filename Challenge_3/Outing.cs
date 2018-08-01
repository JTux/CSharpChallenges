using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_3
{
    public enum EventType
    {
        Golf, Bowling, AmusementPark, Concert
    }

    public class Outing
    {
        public Outing(EventType outingType, int attendees, DateTime date, decimal individualCost, decimal totalEventCost)
        {
            OutingType = outingType;
            Attendees = attendees;
            Date = date;
            IndividualCost = individualCost;
            TotalEventCost = totalEventCost;
        }

        public EventType OutingType { get; set; }
        public int Attendees { get; set; }
        public DateTime Date { get; set; }
        public decimal IndividualCost { get; set; }
        public decimal TotalEventCost { get; set; }

        public override string ToString()
        {
            return $"Event Type: {OutingType}" +
                $"\n  Attendance: {Attendees}" +
                $"\n  Date: {Date.ToShortDateString()}" +
                $"\n  Cost per Person: ${IndividualCost}" +
                $"\n  Total Event Cost: ${TotalEventCost}";
        }
    }
}
