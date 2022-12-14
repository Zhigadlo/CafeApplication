using Cafe.Application.Interfaces;
using Cafe.Domain;
using MediatR;

namespace Cafe.Application.Commands.Orders
{
    public class CreateOrderCommandHandler : CafeContextHandler, IRequestHandler<CreateOrderCommand, Order>
    {
        public CreateOrderCommandHandler(ICafeDbContext context) : base(context) { }

        public async Task<Order> Handle(CreateOrderCommand command, CancellationToken cancellationToken)
        {
            var newOrder = command.Order;
            newOrder.Employee = _context.Employees.First(e => e.Id == command.Employee);
            newOrder.IsCompleted = 0;
            _context.Orders.Add(newOrder);
            await _context.Save();

            for (int i = 0; i < command.DishIds.Length; i++)
            {
                var orderDish = new OrderDish()
                {
                    OrderId = newOrder.Id,
                    DishId = command.DishIds[i],
                    DishCount = command.Count[i]
                };

                _context.OrderDishes.Add(orderDish);
            }
            await _context.Save();
            return await Task.FromResult(newOrder);
        }
    }
}
