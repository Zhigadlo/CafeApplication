using Cafe.Domain;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Cafe.Web.Models.WarehouseViewModels
{
    public class CreateWarehouseViewModel
    {
        public SelectList Ingridients { get; set; }
        public SelectList Providers { get; set; }

        public CreateWarehouseViewModel(IEnumerable<Ingridient> ingridients, IEnumerable<Provider> providers)
        {
            Ingridients = new SelectList(ingridients, "Id", "Name", ingridients.First().Id);
            Providers = new SelectList(providers, "Id", "Name", providers.First().Id);
        }
    }
}
