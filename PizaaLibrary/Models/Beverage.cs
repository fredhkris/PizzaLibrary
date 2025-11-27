using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaLibrary.Models
{
    public class Beverage : MenuItem
    {
        public bool Alcohol { get; set; }

        public Beverage(string name, double price, string description, bool alcohol, MenuType menuType) : base(name, price, description, menuType)
        {
            Alcohol = alcohol;
        }

        public override string ToString()
        {
            return $"No: {No}, Description: {Description}, Name: {Name}, Price: {Price}, Alcohol: {Alcohol}, TheMenuType: {TheMenuType}";
        }
    }
}
