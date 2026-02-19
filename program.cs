//css_include "Product.cs"
//css_include "VendingMachine.cs"
//css_include "VendingMenu.cs"

using System;

namespace SimpleVending
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== ВЕНДИНГОВЫЙ АППАРАТ АЭРОПОРТА ===\n");
            
            VendingMachine machine = new VendingMachine();
            machine.InitializeProducts();
            
            VendingMenu menu = new VendingMenu(machine);
            menu.ShowMainMenu();
            
            Console.WriteLine("\nСпасибо за покупку! Хорошего полета!");
            Console.ReadKey();
        }
    }
}