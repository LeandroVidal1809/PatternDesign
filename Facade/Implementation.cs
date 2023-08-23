using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade
{
    public class OrderService
    {
        public bool HasEnoughOrders(int customerId)
        {
            //does the customer have enought orders?
            //fakse calculation for demo
            return (customerId > 5);
        }

     
    }
    public class CustomerDiscountBaseService
    {
        public double CustomerDiscountBase(int customerId)
        {
            return (customerId > 8) ? 10 : 20;
        }
    }

    public class DayOfTheWeekFactorService
    {
        public double CalculateDayOfTheWeekFactor()
        {
            //fake calculation for demo
            switch(DateTime.UtcNow.DayOfWeek)
            {
                case DayOfWeek.Sunday:
                case DayOfWeek.Saturday:
                    return 0.8;
                default: 
                    return 1.2;
            }
        }
    }

    /// <summary>
    /// Facade
    /// </summary>
    public class DiscountFacade
    {
        private readonly OrderService _orderService = new();
        private readonly CustomerDiscountBaseService _customerDiscountBaseService = new();
        private readonly DayOfTheWeekFactorService _dayOfTheWeekFactorService = new();
        
        public double CalculateDiscountPercentage(int customerId) 
        {
            if(!_orderService.HasEnoughOrders(customerId)) 
            {
                return 0;
            }

            return _customerDiscountBaseService.CustomerDiscountBase(customerId)
                * _dayOfTheWeekFactorService.CalculateDayOfTheWeekFactor();
        }

    }
}
