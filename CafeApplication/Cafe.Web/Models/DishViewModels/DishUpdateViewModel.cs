using Cafe.Domain;

namespace Cafe.Web.Models.DishViewModels
{
    public record DishUpdateViewModel(Dish Dish, IEnumerable<IngridientsDish> IngridientsDishes, IEnumerable<Ingridient> Ingridients);
}
