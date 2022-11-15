using Cafe.Application.Interfaces;
using Cafe.Domain;
using MediatR;

namespace Cafe.Application.Queries.Warehouses
{
    public class GetWarehouseByIdCommandHandler : CafeContextHandler, IRequestHandler<GetWarehouseByIdCommand, IngridientsWarehouse>
    {
        public GetWarehouseByIdCommandHandler(ICafeDbContext context) : base(context) { }

        public Task<IngridientsWarehouse> Handle(GetWarehouseByIdCommand command, CancellationToken cancellationToken)
        {
            return Task.FromResult(_context.IngridientsWarehouses.First(iw => iw.Id == command.Id));
        }
    }
}
