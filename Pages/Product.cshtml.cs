using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppCoreProduct.Models;
using WebAppCoreProduct.Services;


namespace WebAppCoreProduct.Pages
{
    public class ProductModel : PageModel
    {
        public Product Product { get; set; } = new Product();
        public string? MessageResult { get; private set; }

        public void OnGet()
        {
            MessageResult = "Для товара можно определить скидку";
        }

        public void OnPost(string name, decimal? price)
        {
            if (string.IsNullOrEmpty(name) || price == null || price < 0)
            {
                MessageResult = "Переданы некорректные данные. Повторите ввод.";
                return;
            }

            Product.Name = name;
            Product.Price = price;

            var result = price * 0.18m;
            MessageResult = $"Для товара {name} с ценой {price} скидка получится {result}";
        }

        public void OnPostDiscount(string name, decimal? price, double discount)
        {
            Product = new Product();

            if (string.IsNullOrEmpty(name) || price == null || price < 0 || discount < 0)
            {
                MessageResult = "Данные некорректны. Повторите ввод.";
                return;
            }

            var result = _discountService.Calculate(price.Value, discount);
            Product.Name = name;
            Product.Price = price;

            MessageResult = $"Для товара {name} с ценой {price} и скидкой {discount}% получится скидка {result}";
        }
        public void OnPostTotal(string name, decimal? price, int? quantity)
        {
            Product = new Product();

            if (string.IsNullOrEmpty(name) || price == null || price < 0 || quantity == null || quantity < 1)
            {
                MessageResult = "Введите корректные данные (имя, цена и количество).";
                return;
            }

            Product.Name = name;
            Product.Price = price;

            var total = price * quantity;
            MessageResult = $"Вы выбрали {quantity} шт. товара {name} по цене {price}. Итоговая сумма: {total}";
        }
        private readonly IDiscountService _discountService;
        public ProductModel(IDiscountService discountService)
        {
            _discountService = discountService;
        }

    }
}