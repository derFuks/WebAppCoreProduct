using Microsoft.AspNetCore.Mvc.RazorPages;
    public class IndexModel : PageModel
    {
        public string? Name { get; set; }
        public decimal? Price { get; set; }
        public bool IsCorrect { get; set; } = true;

        public void OnGet(string? name, decimal? price)
        {
            if (string.IsNullOrEmpty(name) || price == null || price < 0)
            {
                IsCorrect = false;
                return;
            }

            Name = name;
            Price = price;
        }
    }

