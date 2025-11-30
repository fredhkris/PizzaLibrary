using PizzaLibrary.Data;
using PizzaLibrary.Exceptions;
using PizzaLibrary.Interfaces;
using PizzaLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaLibrary.Services
{
    public class CustomerRepository : ICustomerRepository
    {
        private Dictionary<string, Customer> _customers;

        public CustomerRepository()
        {
            _customers = MockData.CustomerData;
        }

        public int Count { get; }

        public void AddCustomer(Customer customer)
        {
            if (_customers.ContainsKey(customer.Mobile))
            {
                throw new CustomerMobileNumberExist();
            }
            else
            {
                _customers.Add(customer.Mobile, customer);
            }
        }

        public List<Customer> GetAll()
        {
            List<Customer> customers = [];
            foreach (Customer c in _customers.Values)
            {
                customers.Add(c);
            }
            return customers;
        }

        public Customer GetCustomerByMobile(string mobile)
        {
            if (_customers.ContainsKey(mobile))
            {
                return _customers[mobile];
            }
            return null;
        }

        public void PrintAllCustomers()
        {
            foreach (Customer c in _customers.Values)
            {
                Console.WriteLine(c.ToString());
            }
        }

        public void RemoveCustomer(string mobile)
        {
            _customers.Remove(mobile);
        }

        public List<Customer> FindAllClubMembers()
        {
            List<Customer> clubMembers = [];
            foreach (Customer c in _customers.Values)
            {
                if (c.ClubMember)
                {
                    clubMembers.Add(c);
                }
            }
            return clubMembers;
        }

        public List<Customer> FindAllCustomersFromRoskilde()
        {
            List<Customer> customers = [];
            foreach (Customer c in _customers.Values)
            {
                if(c.Address.Contains("Roskilde"))
                {
                    customers.Add(c);
                }
            }
            return customers;
        }

        public void UpdateCustomer(Customer customer)
        {

        }
    }
}
