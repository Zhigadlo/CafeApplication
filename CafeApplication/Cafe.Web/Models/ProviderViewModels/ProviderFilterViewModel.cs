namespace Cafe.Web.Models.ProviderViewModels
{
    public class ProviderFilterViewModel
    {
        public string SelectedName { get; private set; }

        public ProviderFilterViewModel(string name)
        {
            SelectedName = name;
        }
    }
}
