namespace Cafe.Web.Models.IngridientViewModels
{
    public class SortIngridientViewModel
    {
        public IngridientSortState NameSort { get; private set; }
        public IngridientSortState Current { get; private set; }
        public SortIngridientViewModel(IngridientSortState sortOrder)
        {
            NameSort = sortOrder == IngridientSortState.NameAsc ? IngridientSortState.NameDesc : IngridientSortState.NameAsc;
            Current = sortOrder;
        }
    }
}
