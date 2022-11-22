using Cafe.Domain;
using Cafe.Web.Models;
using Cafe.Web.Models.EmployeeViewModels;
using Cafe.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace Cafe.Web.Controllers
{
    public class EmployeesController : BaseController<EmployeeService>
    {
        private ProfessionService _professionService;
        public EmployeesController(EmployeeService employeeService, ProfessionService professionService) : base(employeeService)
        {
            _professionService = professionService;
        }

        public async Task<IActionResult> Index(int? profession, int page = 1,
                                       EmployeeSortState sortOrder = EmployeeSortState.AgeAsc)
        {
            IEnumerable<Employee> employees = await _service.GetAll();

            if (profession != null)
            {
                HttpContext.Session.SetInt32("employeeprofession", (int)profession);
            }
            else
            {
                profession = HttpContext.Session.Keys.Contains("employeeprofession")
                           ? HttpContext.Session.GetInt32("employeeprofession") : -1;
            }
            if (profession != -1)
                employees = employees.Where(x => x.Profession.Id == profession);

            string firstName = GetStringFromSession(HttpContext, "employeefirstname", "firstName");
            HttpContext.Session.SetString("employeefirstname", firstName);
            string lastName = GetStringFromSession(HttpContext, "employeelastname", "lastName");
            HttpContext.Session.SetString("employeelastname", lastName);
            string middleName = GetStringFromSession(HttpContext, "employeemiddlename", "middleName");
            HttpContext.Session.SetString("employeemiddlename", middleName);

            employees = employees.Where(x => x.FirstName.Contains(firstName)
                                          && x.LastName.Contains(lastName)
                                          && x.MiddleName.Contains(middleName));

            switch (sortOrder)
            {
                case EmployeeSortState.FirstNameAsc:
                    employees = employees.OrderBy(e => e.FirstName);
                    break;
                case EmployeeSortState.FirstNameDesc:
                    employees = employees.OrderByDescending(e => e.FirstName);
                    break;
                case EmployeeSortState.LastNameAsc:
                    employees = employees.OrderBy(e => e.LastName);
                    break;
                case EmployeeSortState.LastNameDesc:
                    employees = employees.OrderByDescending(e => e.LastName);
                    break;
                case EmployeeSortState.MiddleNameAsc:
                    employees = employees.OrderBy(e => e.MiddleName);
                    break;
                case EmployeeSortState.MiddleNameDesc:
                    employees = employees.OrderByDescending(e => e.MiddleName);
                    break;
                case EmployeeSortState.AgeDesc:
                    employees = employees.OrderByDescending(e => e.Age);
                    break;
                case EmployeeSortState.EducationAsc:
                    employees = employees.OrderBy(e => e.Education);
                    break;
                case EmployeeSortState.EducationDesc:
                    employees = employees.OrderByDescending(e => e.Education);
                    break;
                case EmployeeSortState.ProfessionAsc:
                    employees = employees.OrderBy(e => e.Profession.Name);
                    break;
                case EmployeeSortState.ProfessionDesc:
                    employees = employees.OrderByDescending(e => e.Profession.Name);
                    break;
                default:
                    employees = employees.OrderBy(e => e.Age);
                    break;
            }


            int pageSize = 10;
            int count = employees.Count();
            IEnumerable<Employee> items = employees.Skip((page - 1) * pageSize).Take(pageSize);

            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            EmployeeIndexViewModel viewModel = new EmployeeIndexViewModel
            {
                PageViewModel = pageViewModel,
                FilterViewModel = new EmployeeFilterViewModel((await _professionService.GetAll()).ToList(), profession, firstName, lastName, middleName),
                SortViewModel = new SortEmployeeViewModel(sortOrder),
                Items = items
            };

            return View(viewModel);
        }

        public async Task<IActionResult> CreateView()
        {
            return View("Create", await _professionService.GetAll());
        }

        [HttpGet]
        [Route("Employees/Update/{id}")]
        public async Task<IActionResult> UpdateView(int id)
        {
            var employee = await _service.GetEmployeeById(id);
            var viewModel = new EmployeeUpdateViewModel(employee, await _professionService.GetAll());
            return View("Update", viewModel);
        }

        [HttpPost]
        [Route("Employees/Update/{id}")]
        public async Task<IActionResult> Update(int id, Employee employee, string profession)
        {
            await _service.Update(id, employee, profession);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _service.Delete(id);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Create(Employee employee, string profession)
        {
            await _service.Add(employee, profession);
            return RedirectToAction("Index");
        }
    }
}
