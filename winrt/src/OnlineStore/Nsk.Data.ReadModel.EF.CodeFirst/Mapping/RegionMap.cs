using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Nsk.Domain.ReadModel;

namespace Nsk.Data.ReadModel.EF.CodeFirst.Mapping
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

