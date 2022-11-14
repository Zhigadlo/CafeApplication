using Cafe.Domain;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Cafe.Web.Models.OrderViewModels
{
    public class CreateOrderViewModel
    {
        public IEnumerable<Dish> Dishes { get; set; }
        public SelectList Employees { get; set; }

        public CreateOrderViewModel(IEnumerable<Dish> dishes, IEnumerable<Employee> employees)
        {
            Dishes = dishes;
            Employees = new SelectList(employees, "Id", "LastName", employees.First().Id);
        }
    }
}
