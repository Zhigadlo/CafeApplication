using Cafe.Domain;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Cafe.Web.Models.OrderViewModels
{
    public class UpdateOrderViewModel
    {
        public int Id { get; }
        public string CustomerName { get; }
        public string PhoneNumber { get; }
        public DateTime Date { get; }
        public int PaymentMethod { get; }
        public int EmployeeId { get; }
        public int IsComplete { get; }
        public SelectList Employees { get; }
        public Dictionary<Dish, int> CountDishes { get; }

        public UpdateOrderViewModel(Order order, IEnumerable<Employee> employees, IEnumerable<Dish> dishes)
        {
            Id = order.Id;
            CustomerName = order.CustomerName;
            PhoneNumber = order.CustomerPhoneNumber;
            Date = order.OrderDate;
            PaymentMethod = order.PaymentMethod;
            EmployeeId = order.EmployeeId;
            IsComplete = order.IsCompleted;


            Employees = new SelectList(employees, "Id", "LastName", employees.First().Id);
            CountDishes = new Dictionary<Dish, int>();
            foreach (var dish in dishes)
            {
                int count = order.OrderDishes.Count(od => od.DishId == dish.Id);
                CountDishes.Add(dish, count);
            }
        }

    }
}
