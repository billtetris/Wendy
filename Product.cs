// TODO для студента:
// 1. Добавить поле ExpiryDate (срок годности) и метод для проверки не просрочен ли товар
// 2. Реализовать метод Sell() для продажи одной единицы товара
// 3. Переопределить метод ToString() для красивого отображения товара

using System;

namespace SimpleVending
{
    public class Product
    {
        public int Code { get; set; }          // Код товара (A1, B2 и т.д.)
        public string Name { get; set; }       // Название
        public decimal Price { get; set; }     // Цена
        public int Quantity { get; set; }      // Количество в аппарате
        public string Category { get; set; }   // Категория
        
        // TODO 1: Добавить свойство ExpiryDate типа DateTime
        
        public Product(int code, string name, decimal price, int quantity, string category)
        {
            Code = code;
            Name = name;
            Price = price;
            Quantity = quantity;
            Category = category;
            
            // TODO 1: Установить срок годности (например, +30 дней от текущей даты)
            ExpiryDate = DateTime.Now.AddDays(30); // Срок годности +30 дней от текущей даты
        }
        
        // TODO 2: Реализовать метод Sell()
        public bool Sell()
        {
            // Проверить что товар не просрочен (использовать метод из TODO 1)
            // Проверить что количество больше 0
            // Если оба условия верны:
            //   - Уменьшить Quantity на 1
            //   - Вернуть true (продажа успешна)
            // Иначе:
            //   - Вернуть false (продажа не удалась)
            if (!IsExpired() && Quantity > 0)
            {
                Quantity--; // Продажа одной единицы
                return true;
            }
            return false;
        }
        
        // TODO 3: Реализовать ToString()
        public override string ToString()
        {
            // Вернуть строку в формате: "A1: Вода 0.5л - 80 руб. (5 шт.)"
            // Добавить информацию о сроке годности если он близок к истечению
            return "";
        }
        
        // TODO 1: Реализовать метод проверки срока годности
        public bool IsExpired()
        {
            // Сравнить ExpiryDate с текущей датой (DateTime.Now)
            // Вернуть true если товар просрочен
            return DateTime.Now > ExpiryDate; // Проверка просрочки
        }
        
        // TODO 1: Реализовать метод проверки, что срок годности истекает скоро
        public bool IsExpiringSoon(int daysThreshold = 7)
        {
            // Проверить что до истечения срока годности осталось меньше daysThreshold дней
            // Но товар еще не просрочен
            // Вернуть true если скоро истекает
            return !IsExpired() && (ExpiryDate - DateTime.Now).TotalDays <= daysThreshold; // Проверка что скоро истекает
        }
    }
}