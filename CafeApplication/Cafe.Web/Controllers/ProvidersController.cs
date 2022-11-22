using Cafe.Domain;
using Cafe.Web.Models;
using Cafe.Web.Models.ProviderViewModels;
using Cafe.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace Cafe.Web.Controllers
{
    public class ProvidersController : BaseController<ProviderService>
    {
        public ProvidersController(ProviderService service) : base(service) { }

        public async Task<IActionResult> Index(int page = 1,
                                    ProviderSortState sortOrder = ProviderSortState.NameAsc)
        {
            IEnumerable<Provider> providers = await _service.GetAll();

            string name = GetStringFromSession(HttpContext, "provider", "name");
            HttpContext.Session.SetString("provider", name);
            providers = providers.Where(x => x.Name.Contains(name));

            switch (sortOrder)
            {
                case ProviderSortState.NameDesc:
                    providers = providers.OrderByDescending(i => i.Name);
                    break;
                default:
                    providers = providers.OrderBy(i => i.Name);
                    break;
            }

            providers.OrderBy(x => x.Name);

            int pageSize = 10;
            int count = providers.Count();
            IEnumerable<Provider> items = providers.Skip((page - 1) * pageSize).Take(pageSize);

            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            ProviderIndexViewModel viewModel = new ProviderIndexViewModel
            {
                PageViewModel = pageViewModel,
                Items = items,
                FilterViewModel = new ProviderFilterViewModel(name),
                SortViewModel = new SortProviderViewModel(sortOrder)
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
        [Route("Providers/Update/{id}")]
        public async Task<IActionResult> UpdateView(int id)
        {
            Provider provider = await _service.GetProviderById(id);
            return View("Update", provider);
        }
        public async Task<IActionResult> Create(Provider provider)
        {
            await _service.AddProvider(provider);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("Providers/Update/{id}")]
        public async Task<IActionResult> Update(int id, Provider provider)
        {
            await _service.UpdateProvider(id, provider);
            return RedirectToAction("Index");
        }
    }
}
