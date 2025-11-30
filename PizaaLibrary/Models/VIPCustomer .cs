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
        private int _discount;

        public int Discount
        {
            get
            {
                return _discount;
            }
            set
            {
                if (value < 1 || value > 25)
                {
                    throw new InvalidDiscountException();
                }
                else
                {
                    _discount = value;
                }
            }
        }

        public VIPCustomer(string name, string mobile, string address, int discount) : base(name, mobile, address)
        {
            if (discount > 25 || discount < 1)
            {
                throw new InvalidDiscountException();
            }
            Discount = discount;
        }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Address: {Address}, Mobile: {Mobile}, Discount: {Discount} ClubMember: {ClubMember}";
        }
    }
}
