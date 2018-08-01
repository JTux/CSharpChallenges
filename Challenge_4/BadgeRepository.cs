using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_4
{
    public class BadgeRepository
    {
        private Dictionary<int, List<string>> _badgeDictionary = new Dictionary<int, List<string>>();

        public void CreateBadge(int badgeNum, List<string> list)
        {
            Badge newBadge = new Badge(badgeNum, list);

            _badgeDictionary.Add(newBadge.BadgeID, newBadge.AccessList);
        }

        public Dictionary<int,List<string>> GetDictionary()
        {
            return _badgeDictionary;
        }
    }
}
