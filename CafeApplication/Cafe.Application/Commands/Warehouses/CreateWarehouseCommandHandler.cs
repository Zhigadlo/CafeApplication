using Cafe.Application.Interfaces;
using Cafe.Domain;
using MediatR;

namespace Cafe.Application.Commands.Warehouses
{
    public class CreateWarehouseCommandHandler : CafeContextHandler, IRequestHandler<CreateWarehouseCommand, IngridientsWarehouse>
    {
        public CreateWarehouseCommandHandler(ICafeDbContext context) : base(context) { }

        public async Task<IngridientsWarehouse> Handle(CreateWarehouseCommand command, CancellationToken cancellationToken)
        {
            await _context.IngridientsWarehouses.AddAsync(command.Warehouse);
            await _context.Save();
            return command.Warehouse;
        }
    }
}
