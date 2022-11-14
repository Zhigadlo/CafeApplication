using Cafe.Domain;

namespace Cafe.Web.Models.EmployeeViewModels
{
    public class EmployeeIndexViewModel : IndexViewModel<Employee>
    {
        public EmployeeFilterViewModel FilterViewModel { get; set; }
        public SortEmployeeViewModel SortViewModel { get; set; }
    }
}
