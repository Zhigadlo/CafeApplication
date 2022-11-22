using Cafe.Domain;
using Cafe.Web.Models;
using Cafe.Web.Models.DishViewModels;
using Cafe.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace Cafe.Web.Controllers
{
    public class DishesController : BaseController<DishService>
    {
        private IngridientService _ingridientService;
        public DishesController(DishService dishService, IngridientService ingridientService) : base(dishService)
        {
            _ingridientService = ingridientService;
        }

        public async Task<IActionResult> Index(int page = 1, DishSortState sortOrder = DishSortState.NameAsc)
        {
            IEnumerable<Dish> dishes = await _service.GetAll();

            string name = GetStringFromSession(HttpContext, "dishname", "name");
            HttpContext.Session.SetString("dishname", name);
            dishes = dishes.Where(x => x.Name.Contains(name));

            switch (sortOrder)
            {
                case DishSortState.CostAsc:
                    dishes = dishes.OrderBy(d => d.Cost);
                    break;
                case DishSortState.CostDesc:
                    dishes = dishes.OrderByDescending(d => d.Cost);
                    break;
                case DishSortState.CookingTimeAsc:
                    dishes = dishes.OrderBy(d => d.CookingTime);
                    break;
                case DishSortState.CookingTimeDesc:
                    dishes = dishes.OrderByDescending(d => d.CookingTime);
                    break;
                case DishSortState.NameDesc:
                    dishes = dishes.OrderByDescending(d => d.Name);
                    break;
                default:
                    dishes = dishes.OrderBy(d => d.Name);
                    break;
            }

            int pageSize = 10;
            int count = dishes.Count();
            IEnumerable<Dish> items = dishes.Skip((page - 1) * pageSize).Take(pageSize);

            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            DishIndexViewModel viewModel = new DishIndexViewModel
            {
                PageViewModel = pageViewModel,
                Items = items,
                SortViewModel = new SortDishViewModel(sortOrder),
                FilterViewModel = new FilterDishViewModel(name)
            };
            return View(viewModel);
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _service.Delete(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> CreateView()
        {
            return View("Create", await _ingridientService.GetAll());
        }

        [HttpGet]
        [Route("Dishes/Update/{id}")]
        public async Task<IActionResult> UpdateView(int id)
        {
            Dish dish = await _service.GetDishById(id);
            IEnumerable<Ingridient> ingridients = await _ingridientService.GetAll();
            DishUpdateViewModel viewModel = new DishUpdateViewModel(dish, dish.IngridientsDishes, ingridients);
            return View("Update", viewModel);
        }

        public async Task<IActionResult> Create(string name, int cost, int cookingTime, int[] ingridientIds, int[] weights)
        {
            await _service.AddDish(name, cost, cookingTime, ingridientIds, weights);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Description(int id)
        {
            return View(await _service.GetDishById(id));
        }

        [HttpPost]
        [Route("Dishes/Update/{id}")]
        public async Task<IActionResult> Update(int id, string name, int cost, int cookingTime, int[] ingridientIds, int[] weights)
        {
            await _service.Update(id, name, cost, cookingTime, ingridientIds, weights);
            return RedirectToAction("Index");
        }
    }
}
