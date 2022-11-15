using Cafe.Domain;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Cafe.Web.Models.WarehouseViewModels
{
    public class FilterWarehouseViewModel
    {
        public string SelectedIngridient { get; set; }
        public SelectList Providers { get; set; }
        public FilterWarehouseViewModel(IEnumerable<Provider> providers, int? provider, string ingridientName = "")
        {
            SelectedIngridient = ingridientName;
            Providers = new SelectList(providers, "Id", "Name", provider);
        }
    }
}
