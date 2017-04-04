using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using Nsk.Domain.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nsk.Data.EF.CodeFirst.Mapping
{
    public class ProductMap : EntityTypeConfiguration<Product>
    {
        public ProductMap()
        {
            // Table & Column Mappings
            this.ToTable("Products");

            // Primary Key
            this.HasKey(t => t.Id);
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .HasColumnName("ProductID");

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(40)
                .HasColumnName("ProductName");

            this.Property(t => t.QuantityPerUnit)
                .HasMaxLength(20)
                .HasColumnName("QuantityPerUnit");

            this.Property(t => t.UnitPrice)
                .HasColumnName("UnitPrice");

            this.Property(t => t.UnitsInStock)
                .HasColumnName("UnitsInStock");

            this.Property(t => t.UnitsOnOrder)
                .HasColumnName("UnitsOnOrder");

            this.Property(t => t.ReorderLevel)
                .HasColumnName("ReorderLevel");

            this.Property(t => t.IsDiscontinued)
                .HasColumnName("Discontinued");

            // Relationships
            this.HasOptional(t => t.Category)
                .WithMany(t => t.Products)
                .Map(m => m.MapKey("CategoryId"));

            this.HasOptional(t => t.Supplier)
                .WithMany(t => t.Products)
                .Map(m => m.MapKey("SupplierId"));

            //this.HasMany<Product, OrderItem>("OrderItems")
            //    .WithMany()
            //    .Map(m => m.MapRightKey("OrderId", "ProductId"));
        }
    }
}

