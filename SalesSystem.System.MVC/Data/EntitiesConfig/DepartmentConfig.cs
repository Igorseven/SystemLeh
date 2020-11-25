//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;
//using SalesSystem.System.MVC.Entities;

//namespace SalesSystem.System.MVC.Data.EntitiesConfig
//{
//    public class DepartmentConfig : IEntityTypeConfiguration<Department>
//    {
//        public void Configure(EntityTypeBuilder<Department> builder)
//        {
//            builder.ToTable("Departments");

//            builder.HasKey(prop => prop.Id).HasName("Id_Department");

//            builder.Property(prop => prop.DepartmentName).HasColumnType("varchar(80)")
//                .HasMaxLength(80).HasColumnName("Department_Name").IsRequired();

//            builder.Property(prop => prop.RegistrationDate).HasColumnType("datetime");
//        }
//    }
//}
