using Cafe.Domain;
using FluentValidation;

namespace Cafe.Web.Models.Validators
{
    public class DishValidator : AbstractValidator<Dish>
    {
        public DishValidator()
        {
            RuleFor(dish => dish.Name).NotEmpty()
                                      .NotNull()
                                      .Must(n => n.Replace(" ", "").All(char.IsLetter))
                                      .WithMessage("Dish name must contain only letters");
            RuleFor(dish => dish.Cost).NotEmpty()
                                      .NotNull()
                                      .Must(c => c >= 0)
                                      .WithMessage("Dish cost must be not empty");
            RuleFor(dish => dish.CookingTime).NotNull()
                                             .NotEmpty()
                                             .Must(c => c >= 0)
                                             .WithMessage("Dish cooking time must be not empty");
        }
    }
}
