using Cafe.Domain;
using FluentValidation;

namespace Cafe.Web.Models.Validators
{
    public class IngridientValidator : AbstractValidator<Ingridient>
    {
        public IngridientValidator()
        {
            RuleFor(ingridient => ingridient.Name).NotEmpty()
                                                  .NotNull()
                                                  .Must(n => n.Replace(" ", "").All(char.IsLetter))
                                                  .WithMessage("Ingridient name must contain only letters");
        }
    }
}