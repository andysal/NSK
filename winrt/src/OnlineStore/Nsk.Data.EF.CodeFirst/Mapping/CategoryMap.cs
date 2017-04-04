using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using Nsk.Domain.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nsk.Data.EF.CodeFirst.Mapping
{
	public class CategoryMap : EntityTypeConfiguration<Category>
	{
		public CategoryMap()
		{
			// Primary Key
			this.HasKey(t => t.Id);
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .HasColumnName("CategoryID");

			// Properties
			this.Property(t => t.Name)
				.IsRequired()
				.HasMaxLength(15)
                .HasColumnName("CategoryName");

		    this.Property(t => t.Description)
                .HasColumnName("Description");

		    this.HasMany<Category, Product>("Products");

			// Table & Column Mappings
			this.ToTable("Categories");
		}
	}
}

