using Microsoft.AspNetCore.Authentication;
using MVC_D2.Models;
using MVC_D2.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace MVC_D2.ServerValidation
{
    public class UniqeNamesAttribute:ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            EmployeeVM employeeVM = (EmployeeVM)validationContext.ObjectInstance;
            EmpContext context = new EmpContext();
            var result = context.Employees.Where(s => s.Fname == value.ToString() && s.Lname == employeeVM.Lname && s.Dno == employeeVM.Dno).ToList();
            if (result.Count > 0)
            {
                return new ValidationResult("This Name Isn't Unique");
            }
            return ValidationResult.Success;
        }

    }
}
