using PizzaLibrary.Data;
using PizzaLibrary.Interfaces;
using PizzaLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaLibrary.Services
{
    public class MenuItemRepository : IMenuItemRepository
    {
        private List<MenuItem> _menuItemList;

        public MenuItemRepository()
        {
            _menuItemList = MockData.MenuItemData;
        }

        public int Count { get => _menuItemList.Count; }

        public void AddMenuItem(MenuItem menuItem)
        {
            //if (!_menuItemList.Contains(menuItem))
            //{
            //    _menuItemList.Add(menuItem);
            //}
            if (GetMenuItemByNo(menuItem.No) == null)
            {
                _menuItemList.Add(menuItem);
            }
        }

        public List<MenuItem> GetAll()
        {
            return _menuItemList;
        }

        public MenuItem GetMenuItemByNo(int no)
        {
            foreach (MenuItem m in _menuItemList)
            {
                if (m.No == no)
                {
                    return m;
                }
            }
            return null;
        }

        public void PrintAllMenuItems()
        {
            foreach (MenuItem m in _menuItemList)
            {
                Console.WriteLine(m);
            }
        }

        public void RemoveMenuItem(int no)
        {
            foreach (MenuItem m in _menuItemList)
            {
                if (m.No == no)
                {
                    _menuItemList.Remove(m);
                    return;
                }
            }
        }

        public List<MenuItem> GetAllMenuItemsOfMenuType(MenuType menuType)
        {
            List<MenuItem> menuItems = [];
            foreach (MenuItem m in _menuItemList)
            {
                if (m.TheMenuType == menuType)
                {
                    menuItems.Add(m);
                }
            }
            return menuItems;
        }

        public MenuItem GetMostExpensiveMenuItemOfMenuType(MenuType menuType)
        {
            MenuItem menuItem = null;
            foreach (MenuItem m in _menuItemList)
            {
                if (m.TheMenuType == menuType && (menuItem == null || m.Price > menuItem.Price))
                {
                    menuItem = m;
                }
            }
            return menuItem;
        }

        public MenuItem GetMostExpensivePizza()
        {
            MenuItem menuItem = null;
            foreach (MenuItem m in _menuItemList)
            {
                if (m.TheMenuType == MenuType.PIZZECLASSSICHE || m.TheMenuType == MenuType.PIZZESPECIALI)
                {
                    if (menuItem == null || m.Price > menuItem.Price)
                    {
                        menuItem = m;
                    }
                }
            }
            return menuItem;
        }

        public void PrintMenuCard()
        {

        }

        public List<MenuItem> GetAllMenuItemsWithinRange(int min, int max)
        {
            List<MenuItem> menuItems = [];
            for(int i = min; i <= max; i++)
            {
                menuItems.Add(_menuItemList[i]);
            }
            return menuItems;
        }
    }
}
