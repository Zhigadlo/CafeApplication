using Cafe.Application.Interfaces;
using Cafe.Domain;
using MediatR;

namespace Cafe.Application.Commands.Warehouses
{
    public class UpdateWarehouseCommandHandler : CafeContextHandler, IRequestHandler<UpdateWarehouseCommand, IngridientsWarehouse>
    {
        public UpdateWarehouseCommandHandler(ICafeDbContext context) : base(context) { }

        public Task<IngridientsWarehouse> Handle(UpdateWarehouseCommand command, CancellationToken cancellationToken)
        {
            var updatedWarehouse = command.Warehouse;
            updatedWarehouse.Id = command.Id;
            _context.IngridientsWarehouses.Update(updatedWarehouse);
            _context.Save();
            return Task.FromResult(updatedWarehouse);
        }
    }
}
