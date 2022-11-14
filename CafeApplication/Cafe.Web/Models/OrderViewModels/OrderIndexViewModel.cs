using Cafe.Domain;

namespace Cafe.Web.Models.OrderViewModels
{
    public class OrderIndexViewModel : IndexViewModel<Order>
    {
        public OrderFilterViewModel FilterViewModel { get; set; }
        public SortOrderViewModel SortViewModel { get; set; }
    }
}
