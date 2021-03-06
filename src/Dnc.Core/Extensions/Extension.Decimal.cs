﻿namespace Dnc
{
    /// <summary>
    /// Extension methods for Decimal.
    /// </summary>
    public static class DecimalExtensions
    {
        /// <summary>
        /// Convert decimal to the price displayed.
        /// </summary>
        /// <param name="price"></param>
        /// <returns></returns>
        public static string ToDisplayedPrice(this decimal price)
        {
            return price.ToString("#0.00");
        }
    }
}
