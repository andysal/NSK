using Nsk.Domain.Model;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using System.Reflection;
using System.Dynamic;
using System;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations.Schema;


namespace Nsk.Data.EF.CodeFirst.Mapping
{
    public class OrderMap : EntityTypeConfiguration<Order>
    {

        public OrderMap()
        {
            // Table & Column Mappings
            this.ToTable("Orders");

            // Primary Key
            this.HasKey(t => t.Id);
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .HasColumnName("OrderID");

            this.Property(t => t.ShipName)
                .HasMaxLength(40)
                .HasColumnName("ShipName");

            this.Property(t => t.ShippingAddress.Address)
                .HasMaxLength(60)
                .HasColumnName("ShipAddress");

            this.Property(t => t.ShippingAddress.City)
                .HasMaxLength(15)
                .HasColumnName("ShipCity");

            this.Property(t => t.ShippingAddress.Region)
                .HasMaxLength(15)
                .HasColumnName("ShipRegion");

            this.Property(t => t.ShippingAddress.PostalCode)
                .HasColumnName("ShipPostalCode");

            this.Property(t => t.ShippingAddress.Country)
                .HasMaxLength(15)
                .HasColumnName("ShipCountry");

            this.Property(t => t.Freight)
                .HasColumnName("Freight");

            this.Property(t => t.RequiredDate)
                .HasColumnName("RequiredDate");

            this.Property(t => t.ShippedDate)
                .HasColumnName("ShippedDate");

            this.Property(t => t.Date).HasColumnName("OrderDate");         
            

            //Relationships
            this.HasOptional(t => t.Customer)
                .WithMany("m_Orders")
                .Map(m => m.MapKey("CustomerID"));

            this.HasOptional(t => t.Employee)
                .WithMany(t => t.Orders)
                .Map(m => m.MapKey("EmployeeID"));

            this.HasOptional(t => t.Shipper)
                .WithMany(t => t.Orders)
                .Map(m => m.MapKey("ShipVia"));          

            //this.HasMany<Order, OrderItem>("m_Items")
            //    .WithMany ()                
            //    .Map(m => m.MapRightKey("ProductId", "OrderId"));
        }
    }
}

