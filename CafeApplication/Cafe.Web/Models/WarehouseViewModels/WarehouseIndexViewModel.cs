using Cafe.Domain;

namespace Cafe.Web.Models.WarehouseViewModels
{
    public class WarehouseIndexViewModel : IndexViewModel<IngridientsWarehouse>
    {
        public SortWarehouseViewModel SortViewModel { get; set; }
        public FilterWarehouseViewModel FilterViewModel { get; set; }
    }
}
