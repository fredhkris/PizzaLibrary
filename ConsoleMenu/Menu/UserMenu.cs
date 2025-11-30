using ConsoleMenu.Controllers.Customers;
using ConsoleMenu.Controllers.MenuItems;
using PizzaLibrary;
using PizzaLibrary.Models;
using PizzaLibrary.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMenu.Menu
{
    public class UserMenu
    {
        private static string mainMenuChoices = "\t1.Vis Pizzamenu\n\t2.Vis Kunder\n\t3.Add Customer\n\t4.Add Pizza\n\t5.Vis Club Members\n\tQ.Afslut\n\n\tIndtast valg:";

        private CustomerRepository _customerRepository = new CustomerRepository();
        private MenuItemRepository _menuItemRepository = new MenuItemRepository();

        private static string ReadChoice(string choices)
        {
            Console.Clear();
            Console.Write(choices);
            string choice = Console.ReadLine();
            Console.Clear();
            return choice.ToLower();
        }
        public void ShowMenu()
        {
            string theChoice = ReadChoice(mainMenuChoices);
            while (theChoice != "q")
            {
                switch (theChoice)
                {
                    case "1":
                        Console.WriteLine("Valg 1");
                        ShowMenuItemController showMenuItemController = new ShowMenuItemController(_menuItemRepository);
                        showMenuItemController.ShowAllMenuItems();
                        Console.ReadLine();
                        break;
                    case "2":
                        Console.WriteLine("Valg 2");
                        _customerRepository.PrintAllCustomers();
                        Console.ReadLine();
                        break;
                    case "3":
                        Console.WriteLine("Valg 3");
                        Console.WriteLine("Er kunden VIPCustomer? (y/n)");
                        string input = Console.ReadLine();
                        bool vipCustomer = input.ToLower() == "y";
                        int discount = 0;
                        if (vipCustomer)
                        {
                            Console.WriteLine("Indtast discount");
                            while (!int.TryParse(Console.ReadLine(), out discount))
                            {
                                Console.WriteLine("Indtast et tal");
                            }
                            discount = Math.Clamp(discount, 1, 25);
                        }
                        Console.WriteLine("Indlæs navn:");
                        string name = Console.ReadLine();
                        Console.WriteLine("Indlæs mobil nr:");
                        string mobile = Console.ReadLine();
                        Console.WriteLine("Indlæs adresse:");
                        string address = Console.ReadLine();
                        Console.WriteLine("Vil du være clubmember y/n");
                        string clubMemberString = Console.ReadLine().ToLower();
                        bool isClubMember = (clubMemberString[0] == 'y') ? true : false;
                        AddCustomerController addMenuItemController;
                        addMenuItemController = vipCustomer
                            ? new AddCustomerController(name, mobile, address, isClubMember, discount, _customerRepository)
                            : new AddCustomerController(name, mobile, address, isClubMember, _customerRepository);
                        addMenuItemController.AddCustomer();
                        break;
                    case "4":
                        Console.WriteLine("Valg 4");
                        Console.WriteLine("Indlæs pizza navn:");
                        string pizzaName = Console.ReadLine();
                        Console.WriteLine("Indlæs pizza beskrivelse:");
                        string desc = Console.ReadLine();
                        Console.WriteLine("Indlæs pizza pris:");
                        double price;
                        while (!double.TryParse(Console.ReadLine(), out price))
                        {
                            Console.WriteLine("Indtast et tal");
                        }
                        AddMenuItemController addMenuItemController2 = new AddMenuItemController(pizzaName, price, desc, MenuType.PIZZECLASSSICHE, _menuItemRepository);
                        addMenuItemController2.AddMenuItem();
                        break;
                    case "5":
                        AddCustomerController clubMemberTest = new AddCustomerController("Hans", "98765432", "Strandvejen 123", clubMember: true, _customerRepository);
                        clubMemberTest.AddCustomer();
                        Console.WriteLine("Valg 5");
                        List<Customer> clubMembers = _customerRepository.FindAllClubMembers();
                        if (clubMembers.Count == 0)
                        {
                            Console.WriteLine("Der er ingen club members.");
                            Console.ReadLine();
                            break;
                        }
                        foreach (Customer c in clubMembers)
                        {
                            Console.WriteLine(c);
                        }
                        Console.ReadLine();
                        break;
                    default:
                        Console.WriteLine("Angiv et tal fra 1..5 eller q for afslut");
                        break;
                }
                theChoice = ReadChoice(mainMenuChoices);
            }
        }

    }

}
