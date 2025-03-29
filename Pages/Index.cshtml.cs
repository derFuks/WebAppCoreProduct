using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppCoreProduct.Models;
namespace WebAppCoreProduct.Pages
    {
        public class IndexModel : PageModel
            {
                public bool IsCorrect { get; set; } = true;
                public Product Product { get; set; } = new Product();
                public void OnGet(string? name, decimal? price)
                {
                    if (string.IsNullOrEmpty(name) || price == null || price < 0)
                    {
                        IsCorrect = false;
                        return;
                    }

                    Product.Name = name;
                    Product.Price = price;
                }
            }

    }