using Cafe.Application.Commands.Warehouses;
using Cafe.Application.Queries.Ingridients;
using Cafe.Application.Queries.Providers;
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
            return await _mediator.Send(new GetAllWarehousesCommand());
        }

        public async Task<IngridientsWarehouse> GetWarehouseById(int id)
        {
            return await _mediator.Send(new GetWarehouseByIdCommand(id));
        }

        public async Task<IngridientsWarehouse> Create(IngridientsWarehouse warehouse)
        {
            return await _mediator.Send(new CreateWarehouseCommand(warehouse));
        }

        public async Task<IngridientsWarehouse> Update(int id, IngridientsWarehouse warehouse)
        {
            return await _mediator.Send(new UpdateWarehouseCommand(id, warehouse));
        }

        public async Task<IngridientsWarehouse> Delete(int id)
        {
            return await _mediator.Send(new DeleteWarehouseCommand(id));
        }
    }
}
