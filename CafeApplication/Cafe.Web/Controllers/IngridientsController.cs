using Cafe.Domain;
using Cafe.Web.Models;
using Cafe.Web.Models.IngridientViewModels;
using Cafe.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace Cafe.Web.Controllers
{
    public class IngridientsController : BaseController<IngridientService>
    {
        public IngridientsController(IngridientService ingridientService) : base(ingridientService)
        {
        }

        public async Task<IActionResult> Index(int? ingridient, string name, int page = 1,
                                    IngridientSortState sortOrder = IngridientSortState.NameAsc)
        {
            IEnumerable<Ingridient> ingridients = await _service.GetAll();//_context.Ingridients;

            if (ingridient != 0 && ingridient != null)
            {
                ingridients = ingridients.Where(x => x.Id == ingridient);
            }
            if (!String.IsNullOrEmpty(name))
            {
                ingridients = ingridients.Where(x => x.Name.Contains(name));
            }

            switch (sortOrder)
            {
                case IngridientSortState.NameDesc:
                    ingridients = ingridients.OrderByDescending(i => i.Name);
                    break;
                default:
                    ingridients = ingridients.OrderBy(i => i.Name);
                    break;
            }

            ingridients.OrderBy(x => x.Name);

            int pageSize = 10;
            int count = ingridients.Count();
            IEnumerable<Ingridient> items = ingridients.Skip((page - 1) * pageSize).Take(pageSize);

            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            IngridientIndexViewModel viewModel = new IngridientIndexViewModel
            {
                PageViewModel = pageViewModel,
                Items = items,
                FilterViewModel = new FilterIngridientViewModel((await _service.GetAll()).ToList(), ingridient, name),
                SortViewModel = new SortIngridientViewModel(sortOrder)
            };
            return View(viewModel);
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _service.Delete(id);
            return RedirectToAction("Index");
        }

        public IActionResult CreateView()
        {
            return View("Create");
        }
        [HttpGet]
        [Route("Ingridients/Update/{id}")]
        public async Task<IActionResult> UpdateView(int id)
        {
            Ingridient ingridient = await _service.GetIngridientById(id);
            return View("Update", ingridient);
        }
        public async Task<IActionResult> Create(string name)
        {
            await _service.CreateIngridient(name);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("Ingridients/Update/{id}")]
        public async Task<IActionResult> Update(int id, string name)
        {
            await _service.Update(id, name);
            return RedirectToAction("Index");
        }
    }
}
