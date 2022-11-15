using Cafe.Domain;
using Cafe.Web.Models;
using Cafe.Web.Models.WarehouseViewModels;
using Cafe.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace Cafe.Web.Controllers
{
    public class WarehousesController : BaseController<WarehouseService>
    {
        public WarehousesController(WarehouseService service) : base(service) { }

        public async Task<IActionResult> Index(string ingridient, int? provider, int page = 1,
                                    WarehouseSortState sortOrder = WarehouseSortState.StorageLifeAsc)
        {
            IEnumerable<IngridientsWarehouse> warehouses = await _service.GetAllWarehouses();;

            if (provider != 0 && provider != null)
            {
                warehouses = warehouses.Where(x => x.ProviderId == provider);
            }
            if (!String.IsNullOrEmpty(ingridient))
            {
                warehouses = warehouses.Where(x => x.Ingridient.Name.Contains(ingridient));
            }

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
                FilterViewModel = new FilterWarehouseViewModel((await _service.GetAllProviders()), provider, ingridient),
                SortViewModel = new SortWarehouseViewModel(sortOrder)
            };
            return View(viewModel);
        }

        public async Task<IActionResult> CreateView()
        {

            return View("Create", new CreateWarehouseViewModel(await _service.GetAllIngridients(), 
                                                               await _service.GetAllProviders()));
        }

        public async Task<IActionResult> Create(IngridientsWarehouse warehouse)
        {
            await _service.Create(warehouse);
            return RedirectToAction("Index");
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
            return View("Update", new UpdateWarehouseViewModel(await _service.GetAllIngridients(), 
                                                               await _service.GetAllProviders(), 
                                                               await _service.GetWarehouseById(id)));
        }

        [HttpPost]
        [Route("Warehouses/Update/{id}")]
        public async Task<IActionResult> Update(int id, IngridientsWarehouse warehouse)
        {
            await _service.Update(id, warehouse);
            return RedirectToAction("Index");
        }
    }
}
