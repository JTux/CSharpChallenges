using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_4
{
    public class Badge
    {
        public Badge(int badgeNum, List<string> list)
        {
            BadgeID = badgeNum;
            AccessList = list;
        }

        public int BadgeID { get; set; }
        public List<string> AccessList { get; set; }
    }
}
