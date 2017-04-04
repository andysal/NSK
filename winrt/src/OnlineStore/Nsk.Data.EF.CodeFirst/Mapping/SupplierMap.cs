using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using Nsk.Domain.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nsk.Data.EF.CodeFirst.Mapping
{
	public class SupplierMap : EntityTypeConfiguration<Supplier>
	{
		public SupplierMap()
		{
			// Primary Key
			this.HasKey(t => t.Id);
			this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .HasColumnName("SupplierID");

			// Properties
			this.Property(t => t.Name)
				.IsRequired()
				.HasMaxLength(40)
                .HasColumnName("CompanyName");
				
			this.Property(t => t.ContactInfo.ContactName)
				.HasMaxLength(30)
                .HasColumnName("ContactName");

            this.Property(t => t.ContactInfo.ContactTitle)
				.HasMaxLength(30)
                .HasColumnName("ContactTitle");

            this.Property(t => t.MainPostalAddress.Address)
                .HasMaxLength(60)
                .HasColumnName("Address");

            this.Property(t => t.MainPostalAddress.City)
                .HasMaxLength(15)
                .HasColumnName("City");

            this.Property(t => t.MainPostalAddress.Region)
                .HasMaxLength(15)
                .HasColumnName("Region");

            this.Property(t => t.MainPostalAddress.PostalCode)
                .HasColumnName("PostalCode");

            this.Property(t => t.MainPostalAddress.Country)
                .HasMaxLength(15)
                .HasColumnName("Country");
				
			this.Property(t => t.PhoneNumber)
				.HasMaxLength(24)
                .HasColumnName("Phone");
				
			this.Property(t => t.FaxNumber)
				.HasMaxLength(24)
                .HasColumnName("Fax");

			this.Property(t => t.HomePage)
                .HasColumnName("HomePage");
				
			// Table & Column Mappings
			this.ToTable("Suppliers");
		}
	}
}

