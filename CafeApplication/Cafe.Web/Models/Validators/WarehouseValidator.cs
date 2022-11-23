using Cafe.Domain;
using FluentValidation;

namespace Cafe.Web.Models.Validators
{
    public class WarehouseValidator : AbstractValidator<IngridientsWarehouse>
    {
        public WarehouseValidator() 
        {
            RuleFor(warehouse => warehouse.Cost).NotEmpty()
                                                .NotNull()
                                                .GreaterThan(0)
                                                .WithMessage("Cost must be greate than 0");
            RuleFor(warehouse => warehouse.Weight).NotEmpty()
                                                  .NotNull()
                                                  .GreaterThan(0)
                                                  .WithMessage("Weight must be greater than 0");
            RuleFor(warehouse => warehouse.ReleaseDate).NotEmpty()
                                                       .NotNull()
                                                       .LessThan(w => w.StorageLife)
                                                       .WithMessage("Release date must be not null and less than storage life");
            RuleFor(warehouse => warehouse.StorageLife).NotEmpty()
                                                       .NotNull()
                                                       .GreaterThan(w => w.ReleaseDate)
                                                       .WithMessage("Storage life must be not null and greater than storage life");
        }
    }
}
