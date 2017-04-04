using System.Data.Entity.ModelConfiguration;
using Nsk.Domain.ReadModel;

namespace Nsk.Data.ReadModel.EF.CodeFirst.Mapping
{
    public class TerritoryMap : EntityTypeConfiguration<Territory>
    {
        public TerritoryMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);
            this.Property(t => t.Id)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnName("TerritoryID");

            // Properties
            this.Property(t => t.Description)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(50)
                .HasColumnName("TerritoryDescription");

            // Table & Column Mappings
            this.ToTable("Territories");

            //this.Property(t => t.Region.Id).HasColumnName("RegionID");

            //Relationships
            this.HasRequired(t => t.Region)
                .WithMany(t => t.Territories)
                .Map (d=>d.MapKey ("RegionID"));
        }
    }
}

