using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppCoreProduct.Models;
namespace WebAppCoreProduct.Pages
    {
        public class IndexModel : PageModel
            {
                public bool IsCorrect { get; set; } = true;
                public Product Product { get; set; } = new Product();
                public string? MessageResult {get; private set; }
                public void OnGet(string? name, decimal? price)
                {
                    if (string.IsNullOrEmpty(name) || price == null || price < 0)
                    {
                        IsCorrect = false;
                        return;
                    }

                    Product.Name = name;
                    Product.Price = price;

                    var result = price * 0.18m;
                    MessageResult = $"Для товара {name} с ценой {price} скидка получится {result}";
                }
            }

    }