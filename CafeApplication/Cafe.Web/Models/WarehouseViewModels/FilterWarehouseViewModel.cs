using Cafe.Domain;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Cafe.Web.Models.WarehouseViewModels
{
    public class FilterWarehouseViewModel
    {
        public string SelectedIngridient { get; set; }
        public SelectList Providers { get; set; }
        public FilterWarehouseViewModel(List<Provider> providers, int? provider, string ingridientName = "")
        {
            SelectedIngridient = ingridientName;
            providers.Insert(0, new Provider { Name = "All", Id = -1 });
            Providers = new SelectList(providers, "Id", "Name", provider);
        }
    }
}
