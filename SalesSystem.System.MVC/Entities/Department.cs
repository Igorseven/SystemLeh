//using SalesSystem.System.MVC.Entities.Generics;
//using System;
//using System.Collections.Generic;
//using System.Linq;

//namespace SalesSystem.System.MVC.Entities
//{
//    public class Department : GenericEntity
//    {
//        public string DepartmentName { get; set; }
//        public ICollection<Seller> Sellers { get; set; } = new List<Seller>();

//        public void AddSeller(Seller seller)
//        {
//            Sellers.Add(seller);
//        }

//        public decimal TotalSales(DateTime initial, DateTime final)
//        {
//            return Sellers.Sum(seller => seller.TotalSales(initial, final));
//        }
//    }
//}
