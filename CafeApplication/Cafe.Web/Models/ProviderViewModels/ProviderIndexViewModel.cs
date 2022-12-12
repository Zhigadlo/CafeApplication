using Cafe.Domain;

namespace Cafe.Web.Models.ProviderViewModels
{
    public class ProviderIndexViewModel : IndexViewModel<Provider>
    {
        public ProviderFilterViewModel FilterViewModel { get; set; }
        public SortProviderViewModel SortViewModel { get; set; }
    }
}
