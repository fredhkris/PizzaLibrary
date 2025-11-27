using PizzaLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaLibrary.Models
{
    public class Customer : ICustomer
    {
        private static int _id;

        public Customer(string name, string mobile, string address)
        {
            Id = _id++;
            Name = name;
            Mobile = mobile;
            Address = address;
        }

        public string Address { get; set; }
        public bool ClubMember { get; set; }
        public int Id { get; set; }
        public string Mobile { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Address: {Address}, Mobile: {Mobile}, ClubMember: {ClubMember}";
        }
    }
}
