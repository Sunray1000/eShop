using System.Collections.Generic;
using Useful.Money;

namespace eShop.DomainClasses
{
    public static class MoneyExtension
    {
        public static Money Sum(this IEnumerable<Product> source ) 
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
