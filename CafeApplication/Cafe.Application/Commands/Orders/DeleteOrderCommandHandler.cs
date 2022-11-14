using Cafe.Application.Interfaces;
using Cafe.Domain;
using MediatR;

namespace Cafe.Application.Commands.Orders
{
    public class DeleteOrderCommandHandler : CafeContextHandler, IRequestHandler<DeleteOrderCommand, Order>
    {
        public DeleteOrderCommandHandler(ICafeDbContext context) : base(context) { }

        public async Task<Order> Handle(DeleteOrderCommand command, CancellationToken cancellationToken)
        {
            var order = _context.Orders.First(o => o.Id == command.Id);
            _context.Orders.Remove(order);
            _context.OrderDishes.RemoveRange(_context.OrderDishes.Where(od => od.OrderId == command.Id));
            await _context.Save();

            return await Task.FromResult(order);
        }
    }
}
