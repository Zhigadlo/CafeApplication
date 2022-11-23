using Cafe.Domain;
using Cafe.Web.Models;
using Cafe.Web.Models.Validators;
using Cafe.Web.Models.WarehouseViewModels;
using Cafe.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace Cafe.Web.Controllers
{
    public class WarehousesController : BaseController<WarehouseService>
    {
        private ProviderService _providerService;
        private IngridientService _ingridientService;
        public WarehousesController(WarehouseService service,
                                    ProviderService providerService,
                                    IngridientService ingridientService) : base(service)
        {
            _providerService = providerService;
            _ingridientService = ingridientService;
        }

        public async Task<IActionResult> Index(int? provider, int page = 1,
                                    WarehouseSortState sortOrder = WarehouseSortState.StorageLifeAsc)
        {
            IEnumerable<IngridientsWarehouse> warehouses = await _service.GetAll(); ;

            if (provider != null)
            {
                HttpContext.Session.SetInt32("providerid", (int)provider);
            }
            else
            {
                provider = HttpContext.Session.Keys.Contains("providerid")
                         ? HttpContext.Session.GetInt32("providerid") : -1;
            }

            if (provider != -1)
                warehouses = warehouses.Where(x => x.ProviderId == provider);


            string ingridient = GetStringFromSession(HttpContext, "warehouseingridient", "ingridient");
            HttpContext.Session.SetString("warehouseingridient", ingridient);
            warehouses = warehouses.Where(x => x.Ingridient.Name.ToLower().Contains(ingridient.ToLower()));

            switch (sortOrder)
            {
                case WarehouseSortState.WeightAsc:
                    warehouses = warehouses.OrderBy(w => w.Weight);
                    break;
                case WarehouseSortState.WeightDesc:
                    warehouses = warehouses.OrderByDescending(w => w.Weight);
                    break;
                case WarehouseSortState.CostAsc:
                    warehouses = warehouses.OrderBy(w => w.Cost);
                    break;
                case WarehouseSortState.CostDesc:
                    warehouses = warehouses.OrderByDescending(w => w.Cost);
                    break;
                case WarehouseSortState.IngridientAsc:
                    warehouses = warehouses.OrderBy(w => w.Ingridient.Name);
                    break;
                case WarehouseSortState.IngridientDesc:
                    warehouses = warehouses.OrderByDescending(w => w.Ingridient.Name);
                    break;
                case WarehouseSortState.ProviderAsc:
                    warehouses = warehouses.OrderBy(w => w.Provider.Name);
                    break;
                case WarehouseSortState.ProviderDesc:
                    warehouses = warehouses.OrderByDescending(w => w.Provider.Name);
                    break;
                case WarehouseSortState.ReleaseDateAsc:
                    warehouses = warehouses.OrderBy(w => w.ReleaseDate);
                    break;
                case WarehouseSortState.ReleaseDateDesc:
                    warehouses = warehouses.OrderByDescending(w => w.ReleaseDate);
                    break;
                case WarehouseSortState.StorageLifeDesc:
                    warehouses = warehouses.OrderByDescending(w => w.StorageLife);
                    break;
                default:
                    warehouses = warehouses.OrderBy(w => w.StorageLife);
                    break;
            }

            int pageSize = 10;
            int count = warehouses.Count();
            IEnumerable<IngridientsWarehouse> items = warehouses.Skip((page - 1) * pageSize).Take(pageSize);

            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            WarehouseIndexViewModel viewModel = new WarehouseIndexViewModel
            {
                PageViewModel = pageViewModel,
                Items = items,
                FilterViewModel = new FilterWarehouseViewModel((await _providerService.GetAll()).ToList(), provider, ingridient),
                SortViewModel = new SortWarehouseViewModel(sortOrder)
            };
            return View(viewModel);
        }

        public async Task<IActionResult> CreateView()
        {

            return View("Create", new CreateWarehouseViewModel(await _ingridientService.GetAll(),
                                                               await _providerService.GetAll()));
        }

        public async Task<IActionResult> Create(IngridientsWarehouse warehouse)
        {
            WarehouseValidator validator = new WarehouseValidator();
            var result = validator.Validate(warehouse);
            if (result.IsValid)
            {
                await _service.Create(warehouse);
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Error", "Home", new { errors = result.Errors.Select(e => e.ErrorMessage).ToArray() });
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _service.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("Warehouses/Update/{id}")]
        public async Task<IActionResult> UpdateView(int id)
        {
            return View("Update", new UpdateWarehouseViewModel(await _ingridientService.GetAll(),
                                                               await _providerService.GetAll(),
                                                               await _service.GetWarehouseById(id)));
        }

        [HttpPost]
        [Route("Warehouses/Update/{id}")]
        public async Task<IActionResult> Update(int id, IngridientsWarehouse warehouse)
        {
            WarehouseValidator validator = new WarehouseValidator();
            var result = validator.Validate(warehouse);
            if (result.IsValid)
            {
                await _service.Update(id, warehouse);
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Error", "Home", new { errors = result.Errors.Select(e => e.ErrorMessage).ToArray() });
            }
        }
    }
}
