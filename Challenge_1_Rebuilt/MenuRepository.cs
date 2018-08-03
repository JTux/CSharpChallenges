using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_1_Rebuilt
{
    public class MenuRepository
    {
        private List<Menu> _menuList = new List<Menu>();

        public int itemCount = 0;

        public void AddItem(string name, string desc, string ingredients, decimal price)
        {
            itemCount++;
            Menu newItem = new Menu(itemCount, name, desc, ingredients, price);
            _menuList.Add(newItem);
        }

        public void AddItem(Menu item)
        {
            itemCount++;
            _menuList.Add(item);
        }

        public void RemoveItem(Menu item)
        {
            _menuList.Remove(item);
            itemCount--;
        }

        public List<Menu> GetList()
        {
            return _menuList;
        }
    }
}
