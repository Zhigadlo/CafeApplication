using Cafe.Application.Interfaces;
using Cafe.Domain;
using MediatR;

namespace Cafe.Application.Commands.Warehouses
{
    public class DeleteWarehouseCommandHandler : CafeContextHandler, IRequestHandler<DeleteWarehouseCommand, IngridientsWarehouse>
    {
        public DeleteWarehouseCommandHandler(ICafeDbContext context) : base(context) { }

        public async Task<IngridientsWarehouse> Handle(DeleteWarehouseCommand command, CancellationToken cancellationToken)
        {
            var warehouseForDelete = _context.IngridientsWarehouses.First(iw => iw.Id == command.Id);
            _context.IngridientsWarehouses.Remove(warehouseForDelete);
            await _context.Save();
            return await Task.FromResult(warehouseForDelete);
        }
    }
}
