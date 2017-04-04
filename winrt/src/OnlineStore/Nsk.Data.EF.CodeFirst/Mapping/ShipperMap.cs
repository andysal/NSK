using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using Nsk.Domain.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nsk.Data.EF.CodeFirst.Mapping
{
	public class ShipperMap : EntityTypeConfiguration<Shipper>
	{
		public ShipperMap()
		{
			// Primary Key
			this.HasKey(t => t.Id);
			this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .HasColumnName("ShipperID");

			// Properties
			this.Property(t => t.CompanyName)
				.IsRequired()
				.HasMaxLength(40)
                .HasColumnName("CompanyName");
				
			this.Property(t => t.Phone)
				.HasMaxLength(24)
                .HasColumnName("Phone");
				
			// Table & Column Mappings
			this.ToTable("Shippers");
		}
	}
}

