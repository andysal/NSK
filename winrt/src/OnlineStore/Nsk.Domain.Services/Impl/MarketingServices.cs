using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nsk.Domain.Model;
using Nsk.Domain.Repositories;
using Nsk.Domain.Services;
using System.Diagnostics.Contracts;

namespace Nsk.Domain.Services.Impl
{
    public class MarketingServices : IMarketingServices
    {
        private ICustomerRepository customerRepository;

        public MarketingServices(ICustomerRepository customerRepository)
        {
            Contract.Requires<ArgumentNullException>(customerRepository != null, "customerRepository");
            Contract.Ensures(this.customerRepository==customerRepository, "customerRepository");

            this.customerRepository = customerRepository;
        }

        /// <summary>
        /// Calculates the suggested discount rate for a customer
        /// </summary>
        /// <param name="customerId">The customer id</param>
        /// <returns>The suggested discount rate</returns>
        public virtual decimal CalculateSuggestedDiscountRate(string customerId)
        {
            Contract.Requires<ArgumentNullException>(customerId != null, "customerId");
            Contract.Requires<ArgumentException>(!string.IsNullOrWhiteSpace(customerId), "customerId");

            Customer customer = customerRepository.FindById(customerId);
            decimal income = customer.CalculateTotalIncome();
            decimal discount = 0;
            if (income > 5000)
            {
                //Suggests a 6% discount if income>5000USD
                discount = 0.06M;
            }
            else
            {
                //Suggests a 1% discount for every 1000USD of income
                discount = income / 100000;
            }
            return discount;
        }
    }
}
