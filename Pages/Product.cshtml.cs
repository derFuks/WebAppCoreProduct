using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppCoreProduct.Models;

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
    }
}