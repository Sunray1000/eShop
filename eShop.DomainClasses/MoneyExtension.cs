using System.Collections.Generic;
using System.Linq;
using Useful.Money;

namespace eShop.DomainClasses
{
    public static class MoneyExtension
    {
        public static Money Sum(this IEnumerable<OrderItems> source ) 
        {
            Money returnValue = new Money(0.0);

            if (source != null)
            {
                foreach (OrderItems value in source)
                {
                    checked
                    {
                        returnValue += value.Quantity * value.ProductOrdered.Price;
                    }
                    
                }
            }

            return returnValue;
        }

        public static Money Sum(this IEnumerable<Product> source)
        {
            Money returnValue = new Money(0.0);

            if (source != null)
            {
                foreach (Product value in source)
                {
                    checked
                    {
                        returnValue += value.Price;
                    }

                }
            }

            return returnValue;
        }
    }
}
