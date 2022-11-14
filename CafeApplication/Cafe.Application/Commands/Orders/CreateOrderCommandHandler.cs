using Cafe.Application.Interfaces;
using Cafe.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.Application.Commands.Orders
{
    public class CreateOrderCommandHandler : CafeContextHandler, IRequestHandler<CreateOrderCommand, Order>
    {
        public CreateOrderCommandHandler(ICafeDbContext context) : base(context) { }

        public async Task<Order> Handle(CreateOrderCommand command, CancellationToken cancellationToken)
        {
            var newOrder = new Order()
            {
                CustomerName = command.CustomerName,
                OrderDate = command.Date,
                Employee = _context.Employees.First(e => e.Id == command.Employee),
                CustomerPhoneNumber = command.PhoneNumber,
                PaymentMethod = command.PaymentMethod,
                IsCompleted = 0
            };
            _context.Orders.Add(newOrder);
            await _context.Save();
            
            for(int i = 0; i < command.DishIds.Length; i++)
            {
                for(int j = 0; j < command.Count[i]; j++)
                {
                    var orderDish = new OrderDish()
                    {
                        OrderId = newOrder.Id,
                        DishId = command.DishIds[i]
                    };
                    
                    _context.OrderDishes.Add(orderDish);
                }
            }
            await _context.Save();
            return await Task.FromResult(newOrder);
        }
    }
}
