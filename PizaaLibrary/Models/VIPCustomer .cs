using PizzaLibrary.Exceptions;
using PizzaLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PizzaLibrary.Models
{
    public class VIPCustomer : Customer
    {
        public int Discount { get; set; }

        public VIPCustomer(string name, string mobile, string address, int discountPercentage) : base(name, mobile, address)
        {
            if (discountPercentage > 25 || discountPercentage < 1)
            {
                throw new TooHighDiscountException();
            }
            Discount = discountPercentage;
        }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Address: {Address}, Mobile: {Mobile}, Discount: {Discount} ClubMember: {ClubMember}";
        }
    }
}
