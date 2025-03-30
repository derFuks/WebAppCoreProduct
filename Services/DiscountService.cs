namespace WebAppCoreProduct.Services
{
    public class DiscountService : IDiscountService
    {
        public decimal Calculate(decimal price, double percent)
        {
            return price * (decimal)(percent / 100);
        }
    }
}