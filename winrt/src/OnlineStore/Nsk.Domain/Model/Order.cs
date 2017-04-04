using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using Nsk.Domain;

namespace Nsk.Domain.Model
{
	public class Order : IAggregateRoot
	{
		protected Order()
		{
			this.m_Items = new List<OrderItem>();
			this.Date = null;
		}

		/// <summary>
		/// Creates an order for a given customer
		/// </summary>
		/// <param name="customer">The customer</param>
		/// <returns>An order</returns>
		public static Order CreateOrder(Customer customer)
		{
            Contract.Requires<ArgumentNullException>(customer != null, "customer");

			var order = new Order();
			order.Customer = customer;

			return order;
		}

		/// <summary>
		/// Gets or sets the ship name
		/// </summary>
		[StringLengthValidator(40)]
		public virtual string ShipName { get; set; }

		/// <summary>
		/// Gets or sets the shipper information
		/// </summary>
		public virtual Shipper Shipper { get; set; }

		/// <summary>
		/// Gets or sets the Freight
		/// </summary>
		public virtual decimal Freight { get; set; }

		/// <summary>
		/// Gets or sets the shipped date
		/// </summary>
		public virtual DateTime? ShippedDate { get; set; }

		/// <summary>
		/// Gets or sets the date
		/// </summary>
		public virtual DateTime? Date { get; set; }

		/// <summary>
		/// Gets or sets the required date
		/// </summary>
		public virtual DateTime? RequiredDate { get; set; }

		protected virtual ICollection<OrderItem> m_Items { get; set; }
		
        /// <summary>
		/// Gets the order detail
		/// </summary>
		public virtual IEnumerable<OrderItem> Items
		{
			get
			{
				return this.m_Items;
			}
		}

		/// <summary>
		/// Gets or sets the Id
		/// </summary>
		public virtual int Id { get; set; }

		/// <summary>
		/// Gets or sets the customer
		/// </summary>
		public virtual Customer Customer { get; set; }

		/// <summary>
		/// Gets or sets the employee responsible for the order management
		/// </summary>
		public virtual Employee Employee { get; set; }

		/// <summary>
		/// Gets or sets the address info
		/// </summary>
		public virtual PostalAddress ShippingAddress { get; set; }

		/// <summary>
		/// Adds a product to an order
		/// </summary>
		/// <param name="product">The product to add to the order</param>
		/// <param name="discount">The discount rate to apply</param>
		/// <param name="quantity">The quantity to order</param>
        /// <exception cref="ArgumentException">Thrown if the order already contains the product or the quantity is zero</exception>
		public virtual void AddProduct(Product product, float discount, short quantity)
		{
		    //Contract.Requires<ArgumentException>(ContainsProduct(product) == false, "product");
            Contract.Requires<ArgumentException>(quantity>0, "quantity");

            if (!ContainsProduct(product))
            {
                throw new ArgumentOutOfRangeException("product", "Product is already added to the current order.");
            }
			var item = new OrderItem();
			item.Product = product;
			item.Discount = discount;
			item.Quantity = quantity;
			item.UnitPrice = product.UnitPrice;

			this.m_Items.Add(item);
		}

		/// <summary>
		/// Verifies whether a specified product has already been added to the order
		/// </summary>
		/// <param name="product">The product to search for</param>
		/// <returns>True if the product is found; otherwise, false</returns>
		private bool ContainsProduct(Product product)
		{
            Contract.Requires<ArgumentNullException>(product!=null, "product");

			var count = (from i in this.m_Items where i.Product.Id == product.Id select i).Count();
			return count != 0;
		}

		/// <summary>
		/// Calculate the base price
		/// </summary>
		/// <returns>The base price</returns>
		public virtual decimal CalculatePrice()
		{
			return this.Items.Sum(i => i.GetPrice());
		}

		/// <summary>
		/// Gets wether the current aggregate can be saved
		/// </summary>
		bool IAggregateRoot.CanBeSaved
		{
			get
			{
				return true;
			}
		}

		/// <summary>
		/// Gets wether the current aggregate can be deleted
		/// </summary>
		bool IAggregateRoot.CanBeDeleted
		{
			get
			{
				return true;
			}
		}
	}
}
