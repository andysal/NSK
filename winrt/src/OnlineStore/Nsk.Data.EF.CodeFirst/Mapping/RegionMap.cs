using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using Nsk.Domain.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nsk.Data.EF.CodeFirst.Mapping
{
	public class RegionMap : EntityTypeConfiguration<Region>
	{
		public RegionMap()
		{
			// Primary Key
			this.HasKey(t => t.Id);
			this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                .HasColumnName("RegionID");

			// Properties
			this.Property(t => t.Description)
				.IsRequired()
				.IsFixedLength()
				.HasMaxLength(50)
                .HasColumnName("RegionDescription");
				
			// Table & Column Mappings
			this.ToTable("Region");
		}
	}
}

