using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SalesSystem.System.MVC.Entities;

namespace SalesSystem.System.MVC.Data.EntitiesConfig
{
    public class SalesRecordConfig : IEntityTypeConfiguration<SalesRecord>
    {
        public void Configure(EntityTypeBuilder<SalesRecord> builder)
        {
            builder.ToTable("SalesRecords");

            builder.HasKey(prop => prop.Id).HasName("Id_Sales_Record");

            builder.Property(prop => prop.RegistrationDate).HasColumnType("datetime");

            builder.Property(prop => prop.Amount).HasColumnType("decimal(18)")
                .IsRequired();
        }
    }
}
