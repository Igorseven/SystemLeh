using SalesSystem.System.MVC.Entities;
using SalesSystem.System.MVC.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SalesSystem.System.MVC.Models.ViewModels
{
    public class SellerViewModel
    {
        [Key]
        public int Id { get; set; }


        [DisplayName("Registration Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy - hh:mm:ss}")]
        public DateTime RegistrationDate { get; set; }


        [Required(ErrorMessage = "Required field")]
        [MaxLength(150, ErrorMessage = "have to have at most {1} Caract")]
        [MinLength(10, ErrorMessage = "have to have at least {1}")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Required field")]
        [DisplayName("E-mail")]
        [MaxLength(120, ErrorMessage = "have to have at most {1} Caract")]
        [MinLength(10, ErrorMessage = "have to have at least {1}")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        [Required(ErrorMessage = "Required field")]
        [DisplayName("Birth Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime BirthDate { get; set; }


        [Required(ErrorMessage = "Required field")]
        [DisplayName("Base Salary")]
        [DataType(DataType.Currency)]
        public decimal BaseSalary { get; set; }


        [Required(ErrorMessage = "Required field")]
        public Department Department { get; set; }


        public int DepartmentId { get; set; }
        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();


        public decimal TotalSales(DateTime initial, DateTime final)
        {
            return Sales.Where(sr => sr.RegistrationDate >= initial && sr.RegistrationDate <= final).Sum(sr => sr.Amount);
        }
    }
}
