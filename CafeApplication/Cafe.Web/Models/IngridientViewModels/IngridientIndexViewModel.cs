using Cafe.Domain;

namespace Cafe.Web.Models.IngridientViewModels
{
    public class IngridientIndexViewModel : IndexViewModel<Ingridient>
    {
        public FilterIngridientViewModel FilterViewModel { get; set; }
        public SortIngridientViewModel SortViewModel { get; set; }
    }
}
