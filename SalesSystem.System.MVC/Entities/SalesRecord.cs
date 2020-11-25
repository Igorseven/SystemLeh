using SalesSystem.System.MVC.Entities.Generics;
using SalesSystem.System.MVC.Enums;

namespace SalesSystem.System.MVC.Entities
{
    public class SalesRecord : GenericEntity
    {
        public decimal Amount { get; set; }
        public SaleStatus Status { get; set; }
        public Seller Seller { get; set; }
    }
}
