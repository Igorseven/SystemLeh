using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SalesSystem.System.MVC.Entities;

namespace SalesSystem.System.MVC.Data.EntitiesConfig
{
    public class SellerConfig : IEntityTypeConfiguration<Seller>
    {
        public void Configure(EntityTypeBuilder<Seller> builder)
        {
            builder.ToTable("Sellers");

            builder.HasKey(prop => prop.Id).HasName("Id_Seller");

            builder.Property(prop => prop.RegistrationDate).HasColumnType("datetime");

            builder.Property(prop => prop.Name).HasColumnType("varchar(150)")
                .HasMaxLength(150).IsRequired();

            builder.Property(prop => prop.Email).HasColumnType("varchar(120)")
                .HasMaxLength(120).IsRequired();

            builder.Property(prop => prop.BirthDate).HasColumnType("datetime")
                .IsRequired();

            builder.Property(prop => prop.BaseSalary).HasColumnType("decimal(18)")
                .IsRequired();
        }
    }
}
