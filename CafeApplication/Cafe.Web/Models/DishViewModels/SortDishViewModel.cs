namespace Cafe.Web.Models.DishViewModels
{
    public class SortDishViewModel
    {
        public DishSortState NameState { get; private set; }
        public DishSortState CostState { get; private set; }
        public DishSortState CookingTimeState { get; private set; }
        public DishSortState Current { get; private set; }

        public SortDishViewModel(DishSortState sortOrder)
        {
            NameState = sortOrder == DishSortState.NameAsc ? DishSortState.NameDesc : DishSortState.NameAsc;
            CostState = sortOrder == DishSortState.CostAsc ? DishSortState.CostDesc : DishSortState.CostAsc;
            CookingTimeState = sortOrder == DishSortState.CookingTimeAsc ? DishSortState.CookingTimeDesc : DishSortState.CookingTimeAsc;
        }
    }
}
