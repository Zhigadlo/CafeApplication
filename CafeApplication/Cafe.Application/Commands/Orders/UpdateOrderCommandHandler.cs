using Cafe.Application.Interfaces;
using Cafe.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Cafe.Application.Commands.Orders
{
    public class UpdateOrderCommandHandler : CafeContextHandler, IRequestHandler<UpdateOrderCommand, Order>
    {
        public UpdateOrderCommandHandler(ICafeDbContext context) : base(context) { }

        public async Task<Order> Handle(UpdateOrderCommand command, CancellationToken cancellationToken)
        {
            var orderForUpdate = command.Order;
            orderForUpdate.Id = command.Id;
            orderForUpdate.Employee = _context.Employees.First(e => e.Id == command.Employee);
            for (int i = 0; i < command.DishIds.Length; i++)
            {
                var orderDish = _context.OrderDishes.FirstOrDefault(x => x.DishId == command.DishIds[i] && x.OrderId == orderForUpdate.Id);
                if (orderDish == null)
                {
                    var newOrderDish = new OrderDish();
                    newOrderDish.Order = orderForUpdate;
                    newOrderDish.Dish = _context.Dishes.First(x => x.Id == command.DishIds[i]);
                    newOrderDish.DishCount = command.Count[i];
                    await _context.OrderDishes.AddAsync(newOrderDish);
                }
                else
                {
                    orderDish.Order = orderForUpdate;
                    orderDish.Dish = _context.Dishes.First(x => x.Id == command.DishIds[i]);
                    orderDish.DishCount = command.Count[i];
                    _context.OrderDishes.Update(orderDish);
                }
            }
            _context.OrderDishes.RemoveRange(_context.OrderDishes.Where(od => od.OrderId == command.Id && !command.DishIds.Contains(od.DishId)));
            _context.Orders.Update(orderForUpdate);
            await _context.Save();
            return await Task.FromResult(orderForUpdate);
        }
    }
}
