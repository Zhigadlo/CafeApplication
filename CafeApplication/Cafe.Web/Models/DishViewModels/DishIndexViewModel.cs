using Cafe.Domain;

namespace Cafe.Web.Models.DishViewModels
{
    public class DishIndexViewModel : IndexViewModel<Dish>
    {
        public SortDishViewModel SortViewModel { get; set; }
        public FilterDishViewModel FilterViewModel { get; set; }
    }
}
