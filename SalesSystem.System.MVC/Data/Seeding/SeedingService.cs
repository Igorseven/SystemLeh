using SalesSystem.System.MVC.Data.ORM;
using SalesSystem.System.MVC.Entities;
using SalesSystem.System.MVC.Enums;
using System;
using System.Linq;

namespace SalesSystem.System.MVC.Data.Seeding
{
    public class SeedingService
    {
        private readonly SystemContext _systemContext;

        public SeedingService(SystemContext systemContext)
        {
            _systemContext = systemContext;
        }

        public void GetSeed()
        {
            {
                try
                {
                    Seeding();             
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        public void Seeding()
        {
            if (_systemContext.Sellers.Any() || _systemContext.SalesRecords.Any())
            {
                return; //OK
            }
            else
            {
                Department equipment = Department.Equipment;
                Department preventive = Department.Preventive;
                Department services = Department.Services;

                Seller seller1 = new Seller
                {
                    Name = "Igor Seven",
                    Email = "Igortest@gmail.com",
                    BirthDate = new DateTime(1993, 04, 22),
                    BaseSalary = 15000,
                    Department = services
                };

                Seller seller2 = new Seller
                {
                    Name = "Elon Sils",
                    Email = "Elontest@gmail.com",
                    BirthDate = new DateTime(1990, 11, 12),
                    BaseSalary = 6900,
                    Department = equipment
                };

                Seller seller3 = new Seller
                {
                    Name = "Jhon Mwks",
                    Email = "Jhontest@gmail.com",
                    BirthDate = new DateTime(1987, 01, 10),
                    BaseSalary = 8000,
                    Department = preventive
                };

                SaleStatus peding = SaleStatus.Pending;
                SaleStatus billed = SaleStatus.Billed;
                SaleStatus canceled = SaleStatus.Canceled;

                SalesRecord sales1 = new SalesRecord
                {
                    Amount = 1000,
                    Status = peding,
                    Seller = seller1
                };

                SalesRecord sales2 = new SalesRecord
                {
                    Amount = 1500055,
                    Status = billed,
                    Seller = seller2
                };

                SalesRecord sales3 = new SalesRecord
                {
                    Amount = 852,
                    Status = canceled,
                    Seller = seller3
                };

                //var depart = _systemContext.Departments.AddRangeAsync(equipment, preventive, services);
                _systemContext.Sellers.AddRangeAsync(seller1, seller2, seller3);
                _systemContext.SalesRecords.AddRangeAsync(sales1, sales2, sales3);
                _systemContext.SaveChangesAsync();
            }
        }
    }
}
