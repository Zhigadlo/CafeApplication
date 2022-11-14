namespace Cafe.Web.Models.DishViewModels
{
    public class FilterDishViewModel
    {
        public string SelectedName { get; private set; }

        public FilterDishViewModel(string selectedName)
        {
            SelectedName = selectedName;
        }
    }
}
