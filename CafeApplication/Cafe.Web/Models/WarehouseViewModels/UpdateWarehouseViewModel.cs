using Cafe.Domain;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Cafe.Web.Models.WarehouseViewModels
{
    public class UpdateWarehouseViewModel
    {
        public SelectList Ingridients { get; set; }
        public SelectList Providers { get; set; }
        public IngridientsWarehouse Warehouse { get; set; }
        public UpdateWarehouseViewModel(IEnumerable<Ingridient> ingridients, IEnumerable<Provider> providers, IngridientsWarehouse warehouse)
        {
            Warehouse = warehouse;
            Ingridients = new SelectList(ingridients, "Id", "Name", warehouse.IngridientId);
            Providers = new SelectList(providers, "Id", "Name", warehouse.ProviderId);
        }
    }
}
