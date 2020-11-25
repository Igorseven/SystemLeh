using SalesSystem.System.MVC.Entities;
using SalesSystem.System.MVC.Enums;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SalesSystem.System.MVC.Models.ViewModels
{
    public class SalesRecordViewModel
    {
        [Key]
        public int Id { get; set; }


        [DisplayName("Registration Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy - hh:mm:ss}")]
        public DateTime RegistrationDate { get; set; }

        
        [Required(ErrorMessage = "Required field")]
        [DataType(DataType.Currency)]
        public decimal Amount { get; set; }


        [Required(ErrorMessage = "Required field")]
        [DisplayName("State")]
        public SaleStatus Status { get; set; }


        public Seller Seller { get; set; }
    }
}
