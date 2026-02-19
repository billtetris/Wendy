// TODO:
// 1. Реализовать отображение списка товаров с кодами, ценами и остатками
// 2. Реализовать процесс покупки с вводом кода и денег
// 3. Реализовать меню администратора с отчетом и пополнением товаров

using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleVending
{
    public class VendingMenu
    {
        private VendingMachine machine;
        
        public VendingMenu(VendingMachine machine)
        {
            this.machine = machine;
        }
        
        // TODO 1: Реализовать отображение товаров
        public void ShowProducts()
        {
            Console.WriteLine("=== ВЫБЕРИТЕ ТОВАР ===");
            Console.WriteLine("Код | Название | Цена | Остаток");
            Console.WriteLine("--------------------------------");
            
            // Получить список доступных товаров через machine.GetAvailableProducts()
            // Для каждого товара вывести строку:
            // "{код}. {название} - {цена} руб. ({остаток} шт.)"
            // Использовать ToString() из класса Product

            var products = machine.GetAvailableProducts();
            
            if (products.Count == 0)
            {
                Console.WriteLine("Нет доступных товаров!");
                return;
            }
            
            foreach (var product in products)
            {
                Console.WriteLine(product.ToString());
            }
        }
        
        // TODO 2: Реализовать процесс покупки
        public void ProcessPurchase()
        {
            Console.WriteLine("=== ПОКУПКА ===");
            
            // 1. Показать товары через ShowProducts()
            // 2. Попросить ввести код товара
            // 3. Получить товар через machine.GetProductByCode()
            // 4. Если товар не найден - сообщить и выйти
            // 5. Попросить ввести сумму денег
            // 6. Вызвать machine.BuyProduct() с кодом и суммой
            // 7. Получить результат (успех/неудача, сдача, сообщение)
            // 8. Вывести сообщение и сдачу если есть
                        
            ShowProducts();
            
            if (machine.GetAvailableProducts().Count == 0)
            {
                Console.WriteLine("Нет доступных товаров для покупки!");
                return;
            }
            
            Console.Write("\nВведите код товара: ");
            if (!int.TryParse(Console.ReadLine(), out int code))
            {
                Console.WriteLine("Неверный формат кода!");
                return;
            }
            
            Product? product = machine.GetProductByCode(code);
            if (product == null)
            {
                Console.WriteLine("Товар не найден!");
                return;
            }
            
            Console.WriteLine($"Товар: {product.Name}");
            Console.WriteLine($"Цена: {product.Price} руб.");
            
            Console.Write("Внесите деньги: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal money))
            {
                Console.WriteLine("Неверный формат суммы!");
                return;
            }
            
            var result = machine.BuyProduct(code, money);
            
            Console.WriteLine($"\n{result.message}");
            
            if (result.success)
            {
                Console.WriteLine($"Сдача: {result.change} руб.");
                Console.WriteLine($"Заберите ваш {product.Name}!");
            }
        }
        
        // TODO 3: Реализовать меню администратора
        public void AdminMenu()
        {
            Console.Write("Введите пароль: ");
            string? password = Console.ReadLine();
            
            if (password == "1234")
            {
                bool adminRunning = true;
                
                while (adminRunning)
                {
                    Console.Clear();
                    Console.WriteLine("=== АДМИНИСТРАТОР ===");
                    Console.WriteLine("1. Отчет за день");
                    Console.WriteLine("2. Пополнить товары");
                    Console.WriteLine("3. Проверить все товары (включая просроченные)");
                    Console.WriteLine("4. Сбросить дневную статистику");
                    Console.WriteLine("5. Выйти");
                    Console.Write("Выберите: ");
                    
                    string? choice = Console.ReadLine();
                    
                    switch (choice)
                    {
                        case "1":
                            ShowDailyReport();
                            break;
                        case "2":
                            RestockProducts();
                            break;
                        case "3":
                            CheckAllProducts();
                            break;
                        case "4":
                            ResetDailyStats();
                            break;
                        case "5":
                            adminRunning = false;
                            break;
                        default:
                            Console.WriteLine("Неверный выбор");
                            break;
                    }
                    
                    if (adminRunning)
                    {
                        Console.WriteLine("\nНажмите Enter...");
                        Console.ReadLine();
                    }
                }
            }
            else
            {
                Console.WriteLine("Неверный пароль!");
                Console.WriteLine("\nНажмите Enter...");
                Console.ReadLine();
            }
        }
        
        // TODO 3: Показать дневной отчет
        private void ShowDailyReport()
        {
            Console.WriteLine("=== ОТЧЕТ ЗА ДЕНЬ ===");
            
            // Получить отчет через machine.GetDailyReport()
            // Вывести: "Выручка: {сумма} руб."
            // Вывести: "Продано товаров: {количество}"
            // Вывести средний чек (выручка / количество продаж)

            var report = machine.GetDailyReport();
            
            Console.WriteLine($"Выручка: {report.revenue} руб.");
            Console.WriteLine($"Продано товаров: {report.soldItems} шт.");
            
            if (report.soldItems > 0)
            {
                decimal averageCheck = report.revenue / report.soldItems;
                Console.WriteLine($"Средний чек: {averageCheck:F2} руб.");
            }
            else
            {
                Console.WriteLine("Средний чек: 0 руб. (нет продаж)");
            }
        }
        
        // TODO 3: Пополнить товары
        private void RestockProducts()
        {
            Console.WriteLine("=== ПОПОЛНЕНИЕ ТОВАРОВ ===");
            
            // 1. Показать все товары (включая отсутствующие)
            // 2. Попросить ввести код товара
            // 3. Попросить ввести количество для пополнения
            // 4. Вызвать machine.RestockProduct()
            // 5. Сообщить о результате
       
            Console.WriteLine("Доступные товары:");
            foreach (var p in machine.GetAllProducts())
            {
                Console.WriteLine($"{p.Code}. {p.Name} - Текущий остаток: {p.Quantity} шт.");
            }
            
            Console.Write("\nВведите код товара для пополнения: ");
            if (!int.TryParse(Console.ReadLine(), out int code))
            {
                Console.WriteLine("Неверный формат кода!");
                return;
            }
            
            Product? prod = machine.GetProductByCode(code);
            if (prod == null)
            {
                Console.WriteLine("Товар не найден!");
                return;
            }
            
            Console.Write("Введите количество для добавления: ");
            if (!int.TryParse(Console.ReadLine(), out int quantity) || quantity <= 0)
            {
                Console.WriteLine("Неверное количество!");
                return;
            }
            
            if (machine.RestockProduct(code, quantity))
            {
                Console.WriteLine($"Товар '{prod.Name}' пополнен на {quantity} шт.");
                Console.WriteLine($"Новый остаток: {prod.Quantity} шт.");
            }
            else
            {
                Console.WriteLine("Ошибка при пополнении товара!");
            }
        }
        
        // TODO 3: Проверить все товары
        private void CheckAllProducts()
        {
            Console.WriteLine("=== ВСЕ ТОВАРЫ ===");
            
            // Получить все товары (не только доступные)
            // Для каждого товара вывести:
            // - Код, название, цену, остаток
            // - Срок годности
            // - Статус (норма, скоро истечет, просрочен)

            Console.WriteLine("Код | Название | Цена | Остаток | Срок годности | Статус");
            Console.WriteLine("----------------------------------------------------------------------");
            
            foreach (var p in machine.GetAllProducts())
            {
                string status;
                ConsoleColor originalColor = Console.ForegroundColor;
                
                if (p.IsExpired())
                {
                    status = "ПРОСРОЧЕН!";
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else if (p.IsExpiringSoon())
                {
                    int daysLeft = (int)(p.ExpiryDate - DateTime.Now).TotalDays;
                    status = $"Скоро (осталось {daysLeft} дн.)";
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                else
                {
                    int daysLeft = (int)(p.ExpiryDate - DateTime.Now).TotalDays;
                    status = $"Годен (еще {daysLeft} дн.)";
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                
                Console.WriteLine($"{p.Code,3} | {p.Name,-15} | {p.Price,5} руб. | {p.Quantity,4} шт. | {p.ExpiryDate:dd.MM.yyyy} | {status}");
                Console.ForegroundColor = originalColor;
            }
        }
        
        // TODO 3: Сбросить дневную статистику
        private void ResetDailyStats()
        {
            Console.WriteLine("=== СБРОС СТАТИСТИКИ ===");
            Console.Write("Вы уверены? (да/нет): ");
            string? answer = Console.ReadLine();
            
            if (answer != null && (answer.ToLower() == "да" || answer.ToLower() == "yes"))
            {
                // TODO: Вызвать метод сброса статистики у VendingMachine
                machine.ResetDailyStats();
                Console.WriteLine("Статистика сброшена");
            }
            else
            {
                Console.WriteLine("Сброс отменен");
            }
        }
        
        // Готовый метод - главное меню (не менять)
        public void ShowMainMenu()
        {
            bool running = true;
            
            while (running)
            {
                Console.Clear();
                Console.WriteLine("=== ВЕНДИНГОВЫЙ АППАРАТ АЭРОПОРТА ===");
                Console.WriteLine("1. Посмотреть товары");
                Console.WriteLine("2. Купить товар");
                Console.WriteLine("3. Администратор");
                Console.WriteLine("4. Выход");
                Console.Write("Выберите: ");
                
                string? choice = Console.ReadLine();
                
                switch (choice)
                {
                    case "1":
                        ShowProducts();
                        break;
                    case "2":
                        ProcessPurchase();
                        break;
                    case "3":
                        AdminMenu();
                        break;
                    case "4":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Неверный выбор!");
                        break;
                }
                
                if (running && choice != "3") // Не показывать при выходе из админки
                {
                    Console.WriteLine("\nНажмите Enter...");
                    Console.ReadLine();
                }
            }
        }
    }
}