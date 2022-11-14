namespace Cafe.Web.Models.EmployeeViewModels
{
    public class SortEmployeeViewModel
    {
        public EmployeeSortState FirstNameState { get; private set; }
        public EmployeeSortState LastNameState { get; private set; }
        public EmployeeSortState MiddleNameState { get; private set; }
        public EmployeeSortState AgeState { get; private set; }
        public EmployeeSortState EducationState { get; private set; }
        public EmployeeSortState ProfessionState { get; private set; }
        public EmployeeSortState Current { get; private set; }

        public SortEmployeeViewModel(EmployeeSortState sortOrder)
        {
            FirstNameState = sortOrder == EmployeeSortState.FirstNameAsc ? EmployeeSortState.FirstNameDesc : EmployeeSortState.FirstNameAsc;
            LastNameState = sortOrder == EmployeeSortState.LastNameAsc ? EmployeeSortState.LastNameDesc : EmployeeSortState.LastNameAsc;
            MiddleNameState = sortOrder == EmployeeSortState.MiddleNameAsc ? EmployeeSortState.MiddleNameDesc : EmployeeSortState.MiddleNameAsc;
            AgeState = sortOrder == EmployeeSortState.AgeAsc ? EmployeeSortState.AgeDesc : EmployeeSortState.AgeAsc;
            EducationState = sortOrder == EmployeeSortState.EducationAsc ? EmployeeSortState.EducationDesc : EmployeeSortState.EducationAsc;
            ProfessionState = sortOrder == EmployeeSortState.ProfessionAsc ? EmployeeSortState.ProfessionDesc : EmployeeSortState.ProfessionAsc;

            Current = sortOrder;
        }
    }
}
