using Cafe.Application.Interfaces;
using Cafe.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Cafe.Application.Queries.Orders
{
    public class GetOrderByIdCommandHandler : CafeContextHandler, IRequestHandler<GetOrderByIdCommand, Order>
    {
        public GetOrderByIdCommandHandler(ICafeDbContext context) : base(context) { }

        public async Task<Order> Handle(GetOrderByIdCommand command, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_context.Orders.Include(o => o.Employee)
                                                        .Include(o => o.OrderDishes)
                                                        .First(o => o.Id == command.Id));
        }
    }
}
