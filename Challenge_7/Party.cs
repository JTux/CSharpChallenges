using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_7
{
    public class Party
    {
        public Party(List<Booth> boothList, int partyNum)
        {
            foreach(Booth booth in boothList)
            {
                TotalCost = TotalCost + booth.TotalCost;
                TotalTickets = TotalTickets + booth.TotalTickets;
            }
            BoothList = boothList;
            PartyNumber = partyNum;
        }

        public List<Booth> BoothList { get; set; }
        public decimal TotalCost { get; set; }
        public int TotalTickets { get; set; }
        public int PartyNumber { get; set; }

        public override string ToString()
        {
            return $"  {PartyNumber}\t\t  {TotalTickets}\t\t  ${TotalCost}";
        }
    }
}
