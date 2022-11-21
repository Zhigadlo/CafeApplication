namespace Cafe.Web.Models.ProviderViewModels
{
    public class SortProviderViewModel
    {
        public ProviderSortState NameState { get; set; }
        public ProviderSortState Current { get; set; }

        public SortProviderViewModel(ProviderSortState orderState)
        {
            NameState = orderState == ProviderSortState.NameAsc ? ProviderSortState.NameDesc : ProviderSortState.NameAsc;
            Current = orderState;
        }
    }
}
