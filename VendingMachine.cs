// TODO:
// 1. Реализовать словарь для хранения товаров (ключ - код товара)
// 2. Реализовать метод покупки товара с обработкой платежа
// 3. Реализовать подсчет дневной выручки и количества продаж

using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleVending
{
    public class VendingMachine
    {
        // TODO 1: Создать словарь для хранения товаров
        private Dictionary<int, Product> products = new Dictionary<int, Product>();
        
        private decimal cashBalance = 5000;    // Деньги в аппарате
        private decimal dailyRevenue = 0;      // Выручка за день
        private int dailySalesCount = 0;       // Количество продаж за день
        
        // TODO 1: Реализовать метод добавления товара
        public void AddProduct(Product product)
        {
            // Добавить товар в словарь products
            // Использовать Code товара как ключ
            if (products.ContainsKey(product.Code))
            {
                products[product.Code] = product;
            }
            else
            {
                products.Add(product.Code, product); // Добавление товара
            }
        }
        
        // TODO 2: Реализовать метод покупки
        public (bool success, decimal change, string message) BuyProduct(int productCode, decimal moneyInserted)
        {
            // 1. Найти товар в словаре по коду
            // 2. Если товар не найден - вернуть (false, moneyInserted, "Товар не найден")
            // 3. Если товар закончился - вернуть (false, moneyInserted, "Товар закончился")
            // 4. Если товар просрочен - вернуть (false, moneyInserted, "Товар просрочен")
            // 5. Если денег недостаточно - вернуть (false, moneyInserted, $"Недостаточно денег. Нужно {цена товара}")
            // 6. Если все проверки пройдены:
            //    - Вызвать product.Sell()
            //    - Увеличить dailyRevenue на цену товара
            //    - Увеличить dailySalesCount на 1
            //    - Рассчитать сдачу
            //    - Вернуть (true, сдача, "Покупка успешна")
            
            return (false, moneyInserted, "");
        }
        
        // TODO 1: Реализовать метод получения доступных товаров
        public List<Product> GetAvailableProducts()
        {
            List<Product> available = new List<Product>();
            
            // Пройти по всем товарам в словаре
            // Для каждого товара проверить:
            // - Количество > 0
            // - Не просрочен
            // Если оба условия верны - добавить товар в список available
            return products.Values
                .Where(p => p.Quantity > 0 && !p.IsExpired())
                .OrderBy(p => p.Code)
                .ToList();
        }
        
        // TODO 3: Реализовать метод получения отчета
        public (decimal revenue, int soldItems) GetDailyReport()
        {
            // Вернуть кортеж с выручкой (dailyRevenue) и количеством продаж (dailySalesCount)
            return (0, 0);
        }
        
        // TODO 1: Реализовать метод пополнения товара
        public bool RestockProduct(int code, int quantity)
        {
            // Найти товар по коду
            // Если товар найден:
            //   - Увеличить его Quantity на quantity
            //   - Вернуть true
            // Если не найден:
            //   - Вернуть false
            if (products.ContainsKey(code))
            {
                products[code].Quantity += quantity;
                return true;
            }
            return false;
        }
        
        // Готовый метод инициализации (не менять)
        public void InitializeProducts()
        {
            AddProduct(new Product(1, "Вода 0.5л", 80, 10, "Напитки"));
            AddProduct(new Product(2, "Кола 0.33л", 100, 8, "Напитки"));
            AddProduct(new Product(3, "Чипсы", 120, 15, "Снеки"));
            AddProduct(new Product(4, "Шоколад", 90, 20, "Сладости"));
            AddProduct(new Product(5, "Печенье", 70, 12, "Сладости"));
            AddProduct(new Product(6, "Бутерброд", 150, 5, "Еда"));
        }
        
        // Готовый метод (не менять)
        public Product GetProductByCode(int code)
        {
            // ВАЖНО: студент должен реализовать словарь products
            // и этот метод будет работать только после этого
            return null;
        }
    }
}