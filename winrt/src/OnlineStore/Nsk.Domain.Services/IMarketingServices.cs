using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nsk.Domain.Services
{
    public interface IMarketingServices
    {
        /// <summary>
        /// Calculates the suggested discount rate for a customer
        /// </summary>
        /// <param name="customerId">The customer id</param>
        /// <returns>The suggested discount rate</returns>
        decimal CalculateSuggestedDiscountRate(string customerId);
    }
}
