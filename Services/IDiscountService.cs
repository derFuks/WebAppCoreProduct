namespace WebAppCoreProduct.Services
{
    public interface IDiscountService
    {
        decimal Calculate(decimal price, double percent);
    }
}