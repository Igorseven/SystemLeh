using SalesSystem.System.MVC.Entities.Generics;
using SalesSystem.System.MVC.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SalesSystem.System.MVC.Entities
{
    public class Seller : GenericEntity
    {

        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public decimal BaseSalary { get; set; }
        public Department Department { get; set; }
        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();


        public decimal TotalSales(DateTime initial, DateTime final)
        {
            return Sales.Where(sr => sr.RegistrationDate >= initial && sr.RegistrationDate <= final)
                .Sum(sr => sr.Amount);
        }
    }
}
