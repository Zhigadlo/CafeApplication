namespace Cafe.Web.Models.OrderViewModels
{
    public class OrderFilterViewModel
    {
        public string SelectedCustomerName { get; set; }
        public OrderFilterViewModel(string customerName = "")
        {
            SelectedCustomerName = customerName;
        }
    }
}
