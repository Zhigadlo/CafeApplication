using Cafe.Domain;
using Cafe.Web.Models;
using Cafe.Web.Models.OrderViewModels;
using Cafe.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace Cafe.Web.Controllers
{
    public class OrdersController : BaseController<OrderService>
    {
        private DishService _dishService;
        private EmployeeService _employeeService;
        public OrdersController(OrderService orderService, DishService dishService, EmployeeService employeeService) : base(orderService)
        {
            _dishService = dishService;
            _employeeService = employeeService;
        }

        public async Task<IActionResult> Index(int page = 1, OrderSortState sortOrder = OrderSortState.OrderDateAsc)
        {
            IEnumerable<Order> orders = await _service.GetAll();

            string name = GetStringFromSession(HttpContext, "customername", "name");
            HttpContext.Session.SetString("customername", name);
            orders = orders.Where(x => x.CustomerName.ToLower().Contains(name.ToLower()));

            switch (sortOrder)
            {
                case OrderSortState.CustomerNameDesc:
                    orders = orders.OrderByDescending(o => o.CustomerName);
                    break;
                case OrderSortState.OrderDateAsc:
                    orders = orders.OrderBy(o => o.OrderDate);
                    break;
                case OrderSortState.OrderDateDesc:
                    orders = orders.OrderByDescending(o => o.OrderDate);
                    break;
                case OrderSortState.PhoneNumberAsc:
                    orders = orders.OrderBy(o => o.CustomerPhoneNumber);
                    break;
                case OrderSortState.PhoneNumberDesc:
                    orders = orders.OrderByDescending(o => o.CustomerPhoneNumber);
                    break;
                case OrderSortState.CostAsc:
                    orders = orders.OrderBy(o => o.GetCost());
                    break;
                case OrderSortState.CostDesc:
                    orders = orders.OrderByDescending(o => o.GetCost());
                    break;
                default:
                    orders = orders.OrderBy(d => d.CustomerName);
                    break;
            }

            int pageSize = 10;
            int count = orders.Count();
            IEnumerable<Order> items = orders.Skip((page - 1) * pageSize).Take(pageSize);

            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            OrderIndexViewModel viewModel = new OrderIndexViewModel
            {
                PageViewModel = pageViewModel,
                Items = items,
                SortViewModel = new SortOrderViewModel(sortOrder),
                FilterViewModel = new OrderFilterViewModel(name)
            };
            return View(viewModel);
        }

        public async Task<IActionResult> Description(int id)
        {
            return View(await _service.GetOrderById(id));
        }
        public async Task<IActionResult> CreateView()
        {
            return View("Create", new CreateOrderViewModel(await _dishService.GetAll(), await _employeeService.GetAll()));
        }

        public async Task<IActionResult> Create(string customerName, DateTime date, string phoneNumber, int paymentMethod, int employee, int[] dishIds, int[] count)
        {
            await _service.Create(customerName, date, phoneNumber, paymentMethod, employee, dishIds, count);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _service.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("Orders/Update/{id}")]
        public async Task<IActionResult> UpdateView(int id)
        {
            return View("Update", new UpdateOrderViewModel(await _service.GetOrderById(id), await _employeeService.GetAll(), await _dishService.GetAll()));
        }

        [HttpPost]
        [Route("Orders/Update/{id}")]
        public async Task<IActionResult> Update(int id, string customerName, DateTime date, string phoneNumber, int paymentMethod,
                                                int isComplete, int employee, int[] dishIds, int[] count)
        {
            await _service.Update(id, customerName, date, phoneNumber, paymentMethod, isComplete, employee, dishIds, count);
            return RedirectToAction("Index");
        }
    }
}
