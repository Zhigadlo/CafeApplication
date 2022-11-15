namespace Cafe.Web.Models.OrderViewModels
{
    public class SortOrderViewModel
    {
        public OrderSortState CustomerNameState { get; set; }
        public OrderSortState DateState { get; set; }
        public OrderSortState PhoneNumberState { get; set; }
        public OrderSortState CostState { get; set; }
        public OrderSortState Current { get; set; }
        public SortOrderViewModel(OrderSortState orderState)
        {
            CustomerNameState = orderState == OrderSortState.CustomerNameAsc ? OrderSortState.CustomerNameDesc : OrderSortState.CustomerNameAsc;
            DateState = orderState == OrderSortState.OrderDateAsc ? OrderSortState.OrderDateDesc : OrderSortState.OrderDateAsc;
            PhoneNumberState = orderState == OrderSortState.PhoneNumberAsc ? OrderSortState.PhoneNumberDesc : OrderSortState.PhoneNumberAsc;
            CostState = orderState == OrderSortState.CostAsc ? OrderSortState.CostDesc : OrderSortState.CostAsc;
            Current = orderState;
        }
    }
}
