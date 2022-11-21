using Cafe.Domain;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Cafe.Web.Models.EmployeeViewModels
{
    public class EmployeeFilterViewModel
    {
        public SelectList Professions { get; private set; }
        public int? SelectedProfession { get; private set; }
        public string SelectedFirstName { get; private set; }
        public string SelectedLastName { get; private set; }
        public string SelectedMiddleName { get; private set; }

        public EmployeeFilterViewModel(List<Profession> professions, int? selectedProfession, string selectedFirstName, string selectedLastName, string selectedMiddleName)
        {
            professions.Insert(0, new Profession { Name = "All", Id = -1 });
            Professions = new SelectList(professions, "Id", "Name", selectedProfession);
            SelectedProfession = selectedProfession;
            SelectedFirstName = selectedFirstName;
            SelectedLastName = selectedLastName;
            SelectedMiddleName = selectedMiddleName;
        }
    }
}
