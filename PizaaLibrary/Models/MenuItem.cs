using PizzaLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PizzaLibrary.Models
{
    public class MenuItem : IMenuItem
    {
        private static int _no;

        public MenuItem(string name, double price, string description, MenuType menuType)
        {
            No = _no++;
            Name = name;
            Price = price;
            Description = description;
            TheMenuType = menuType;
        }

        public string Description { get; set; }
        public string Name { get; set; }
        public int No { get; set; }
        public double Price { get; set; }
        public MenuType TheMenuType { get; set; }

        public override string ToString()
        {
            return $"No: {No}, Description: {Description}, Name: {Name}, Price: {Price}, TheMenuType: {TheMenuType}";
        }
    }
}
