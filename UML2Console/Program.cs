// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using PizzaLibrary;
using PizzaLibrary.Models;
using PizzaLibrary.Services;

CustomerRepository customerRepo = new CustomerRepository();
MenuItemRepository menuRepo = new MenuItemRepository();
Customer c1 = new Customer("Jens", "20304050", "Vej 123");
VIPCustomer c2 = new VIPCustomer("Hans", "60504030", "Gade 321", 20);
MenuItem m1 = new MenuItem("Græsk salat", 65, "Agurk, tomater, rødløg, oliven, fetaost", MenuType.SALATER);
customerRepo.AddCustomer(c1);
customerRepo.AddCustomer(c2);
menuRepo.AddMenuItem(m1);
customerRepo.PrintAllCustomers();
Console.WriteLine();
menuRepo.PrintAllMenuItems();
//List<MenuItem> pizzaSpecialis = menuRepo.GetAllMenuItemsOfMenuType(MenuType.PIZZESPECIALI);
//foreach(MenuItem m in pizzaSpecialis)
//{
//    Console.WriteLine(m);
//}
//for(int i = 0; i < pizzaSpecialis.Count; i++)
//{
//    Console.WriteLine(pizzaSpecialis[i]);
//}

//VIPCustomer c3 = new VIPCustomer("Pede", "90807060", "Gade 456", -1);

CompanyInfo companyInfo = CompanyInfo.GetInstance();
string name = companyInfo.Name = "Mamas Pizza";
string cvr = companyInfo.CVR = "123456789";
double clubDiscount = companyInfo.ClubDiscount = 10;
double vat = companyInfo.Vat = 25;
Console.WriteLine($"CompanyInfo: Name: {name}, CVR: {cvr}, ClubDiscount: = {clubDiscount}, Vat = {vat}");

// test
//CompanyInfo companyInfo2 = CompanyInfo.GetInstance();
//Console.WriteLine($"CompanyInfo: Name: {companyInfo.Name}, CVR: {companyInfo.CVR}, ClubDiscount: = {companyInfo.ClubDiscount}, Vat = {companyInfo.Vat}");

List<MenuItem> menuItemsInRange = menuRepo.GetAllMenuItemsWithinRange(0, 2);
foreach(MenuItem m in menuItemsInRange)
{
    Console.WriteLine(m);
}

menuRepo.PrintMenuCard();