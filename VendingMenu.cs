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
        }
        
        // TODO 3: Реализовать меню администратора
        public void AdminMenu()
        {
            Console.Write("Введите пароль: ");
            string password = Console.ReadLine();
            
            if (password == "1234") // Простой пароль для демонстрации
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
                    
                    string choice = Console.ReadLine();
                    
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
        }
        
        // TODO 3: Сбросить дневную статистику
        private void ResetDailyStats()
        {
            Console.WriteLine("=== СБРОС СТАТИСТИКИ ===");
            Console.Write("Вы уверены? (да/нет): ");
            string answer = Console.ReadLine();
            
            if (answer.ToLower() == "да")
            {
                // Сбросить dailyRevenue и dailySalesCount
                // Подсказка: нужно добавить метод ResetDailyStats() в VendingMachine
                Console.WriteLine("Статистика сброшена");
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
                
                string choice = Console.ReadLine();
                
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