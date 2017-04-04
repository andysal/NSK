using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics.Contracts;

namespace Nsk.BackRoom.Domain.Commands
{
    public class AddProductToCatalog : Command
    {
        public Guid ProductId { get; private set; }
        public string ProductName { get; private set; }
        public decimal UnitPrice { get; private set; }
        public int QuantityPerUnit { get; private set; }

        public AddProductToCatalog(Guid productId, string productName, decimal unitPrice, int quantityPerUnit)
        {
            Contract.Requires<ArgumentException>(!string.IsNullOrWhiteSpace(productName));
            Contract.Requires<ArgumentException>(unitPrice > 0);
            Contract.Requires<ArgumentException>(quantityPerUnit > 0);

            this.ProductId = productId;
            this.ProductName = productName;
            this.UnitPrice = unitPrice;
            this.QuantityPerUnit = quantityPerUnit;
        }
    }
}
