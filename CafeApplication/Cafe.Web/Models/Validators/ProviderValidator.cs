using Cafe.Domain;
using FluentValidation;

namespace Cafe.Web.Models.Validators
{
    public class ProviderValidator : AbstractValidator<Provider>
    {
        public ProviderValidator()
        {
            RuleFor(p => p.Name).NotEmpty()
                                .NotNull()
                                .Must(n => n.Replace(" ", "").All(char.IsLetter))
                                .WithMessage("Provider name must contain only letters");
        }
    }
}
