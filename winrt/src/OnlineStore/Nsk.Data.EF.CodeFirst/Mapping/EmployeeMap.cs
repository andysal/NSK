using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;
using Nsk.Domain.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nsk.Data.EF.CodeFirst.Mapping
{
    public class EmployeeMap : EntityTypeConfiguration<Employee>
    {
        public EmployeeMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .HasColumnName("EmployeeID");

            // Properties
            this.Property(t => t.Surname)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnName("LastName");

            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(10)
                .HasColumnName("FirstName");

            this.Property(t => t.JobTitle)
                .HasMaxLength(30)
                .HasColumnName("Title");

            this.Property(t => t.TitleOfCourtesy)
                .HasMaxLength(25)
                .HasColumnName("TitleOfCourtesy");

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
                .HasMaxLength(15).HasColumnName("Country");

            this.Property(t => t.HomePhone)
                .HasMaxLength(24)
                .HasColumnName("HomePhone");

            this.Property(t => t.Extension)
                .HasMaxLength(4)
                .HasColumnName("Extension");

            this.Property(t => t.PhotoPath)
                .HasMaxLength(255)
                .HasColumnName("PhotoPath");

            this.Property(t => t.BirthDate)
                .HasColumnName("BirthDate");

            this.Property(t => t.HireDate)
                .HasColumnName("HireDate");

            this.Property(t => t.Notes)
                .HasColumnName("Notes");

            this.Property(t => t.HomePhone)
                .HasMaxLength(24)
                .HasColumnName("HomePhone");

            // Table & Column Mappings
            this.ToTable("Employees");

            // Relationships
            this.HasMany(t => t.Territories)
                .WithMany(t => t.Employees)
                .Map(m =>
                    {
                        m.ToTable("EmployeeTerritories");
                        m.MapLeftKey("EmployeeID");
                        m.MapRightKey("TerritoryID");
                    });

            this.HasOptional(t => t.Manager)
                .WithMany(t => t.Reports)
                .Map(m => m.MapKey("ReportsTo"));
        }
    }
}

