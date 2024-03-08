using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using MVC_D2.ServerValidation;

namespace MVC_D2.ViewModels
{
    public class EmployeeVM
    {
        [UniqeNames]
        public string? Fname { get; set; }
        public string? Lname { get; set; }
        [Remote("Address", "ClientSide", ErrorMessage = "You must lives in cairo, alex or giza ")]
        public string? Address { get; set; }
        [Range(15000, 30000, ErrorMessage = "Salary must be Between 15k and 30k")]
        [Required(ErrorMessage = "*")]
        public decimal? Salary { get; set; }
        public int? Dno { get; set; }
        [Compare("ConfirmPassword", ErrorMessage = "Password must match confirm")]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "Password must match")]
        public string ConfirmPassword { get; set; }
        [ValidateNever]
        public SelectList departments { get; set; }
    }
}