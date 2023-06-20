using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3__AbstractFactory
{
    public  interface IShoppingCartPurchaseFactory
    {
        IDiscountService CreateDiscountService();
        IShippingCostService CreateShippingCostsService();
    }
    public interface IDiscountService
    {
        int DiscountPercentage { get; }
    }

    public class BelgiumDiscountService: IDiscountService
    {
        public int DiscountPercentage => 20;   
    }
    public class FranceDiscountService : IDiscountService
    {
        public int DiscountPercentage => 10;
    }


    public interface IShippingCostService
    {
        decimal ShippingCosts { get; }
    }

    public class BelgiumShippingCostService :  IShippingCostService
    {
        public decimal ShippingCosts => 20;
    }
    public class FranceShippingCostService : IShippingCostService
    {
        public decimal ShippingCosts => 25;
    }


    //Concrete Factories

    public class BelgiumShoppingCartPurchaseFactory: IShoppingCartPurchaseFactory
    {
        public IDiscountService CreateDiscountService()
        {
            return new BelgiumDiscountService();
        }

        public IShippingCostService CreateShippingCostsService()
        {
            return new BelgiumShippingCostService();
        }
    }
    public class FranceShoppingCartPurchaseFactory: IShoppingCartPurchaseFactory
    {
        public IDiscountService CreateDiscountService()
        {
            return new FranceDiscountService();
        }

        public IShippingCostService CreateShippingCostsService()
        {
            return new FranceShippingCostService();
        }
    }


    //Client Class
    public class ShoppingCart
    {
        private readonly IDiscountService _discountService;
        private readonly IShippingCostService _shippingCostService;
        private int _orderCosts;

        public ShoppingCart(IShoppingCartPurchaseFactory factory)
        {
            _discountService = factory.CreateDiscountService();
            _shippingCostService = factory.CreateShippingCostsService();
        }

        public void CalculateCosts()
        {
            Console.WriteLine($"Total cost = " +
               $" {_orderCosts - ( _orderCosts / 100 * _discountService.DiscountPercentage) + _shippingCostService.ShippingCosts}");
        }

    }


}
