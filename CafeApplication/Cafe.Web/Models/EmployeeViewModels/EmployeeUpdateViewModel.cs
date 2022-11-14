using Cafe.Domain;

namespace Cafe.Web.Models.EmployeeViewModels
{
    public record EmployeeUpdateViewModel(Employee Employee, IEnumerable<Profession> Professions);
}
