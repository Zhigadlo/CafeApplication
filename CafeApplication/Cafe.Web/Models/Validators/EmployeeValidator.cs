using Cafe.Domain;
using FluentValidation;

namespace Cafe.Web.Models.Validators
{
    public class EmployeeValidator : AbstractValidator<Employee>
    {
        public EmployeeValidator()
        {
            RuleFor(employee => employee.FirstName).NotEmpty()
                                                   .NotNull()
                                                   .Must(fn => fn.All(char.IsLetter))
                                                   .WithMessage("First name must be not empty and contain only letter");
            RuleFor(employee => employee.LastName).NotEmpty()
                                                  .NotNull()
                                                  .Must(fn => fn.All(char.IsLetter))
                                                  .WithMessage("Last name must be not empty and contain only letter");
            RuleFor(employee => employee.MiddleName).Must(fn => fn.All(char.IsLetter))
                                                    .WithMessage("Middle name must contain only letter");
            RuleFor(employee => employee.Age).NotEmpty()
                                             .NotNull()
                                             .Must(a => a >= 18 && a <= 65)
                                             .WithMessage("Age must be more or equal 18 and less or equal 65");
        }
    }
}
