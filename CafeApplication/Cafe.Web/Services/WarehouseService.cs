using Cafe.Application.Commands.Warehouses;
using Cafe.Application.Queries.Warehouses;
using Cafe.Domain;
using MediatR;
using Microsoft.Extensions.Caching.Memory;

namespace Cafe.Web.Services
{
    public class WarehouseService : BaseService
    {
        public WarehouseService(IMediator mediator, IMemoryCache cache) : base(mediator, cache) { }

        public async Task<IEnumerable<IngridientsWarehouse>> GetAll()
        {
            IEnumerable<IngridientsWarehouse> ingridientsWarehouses;

            if (!_cache.TryGetValue("warehouses", out ingridientsWarehouses))
            {
                ingridientsWarehouses = await _mediator.Send(new GetAllWarehousesCommand());
                _cache.Set("warehouses", ingridientsWarehouses.ToList());
            }

            return ingridientsWarehouses;
        }

        public async Task<IngridientsWarehouse> GetWarehouseById(int id)
        {
            return await _mediator.Send(new GetWarehouseByIdCommand(id));
        }

        public async Task<IngridientsWarehouse> Create(IngridientsWarehouse warehouse)
        {
            CacheClear();
            return await _mediator.Send(new CreateWarehouseCommand(warehouse));
        }

        public async Task<IngridientsWarehouse> Update(int id, IngridientsWarehouse warehouse)
        {
            CacheClear();
            return await _mediator.Send(new UpdateWarehouseCommand(id, warehouse));
        }

        public async Task<IngridientsWarehouse> Delete(int id)
        {
            CacheClear();
            return await _mediator.Send(new DeleteWarehouseCommand(id));
        }
    }
}
