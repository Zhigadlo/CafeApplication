using Cafe.Application.Interfaces;
using Cafe.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Cafe.Application.Queries.Orders
{
    public class GetAllOrdersCommandHandler : CafeContextHandler, IRequestHandler<GetAllOrdersCommand, IEnumerable<Order>>
    {
        public GetAllOrdersCommandHandler(ICafeDbContext context) : base(context) { }

        public async Task<IEnumerable<Order>> Handle(GetAllOrdersCommand request, CancellationToken cancellationToken)
        {
            var orders = _context.Orders.Include(o => o.Employee).Include(o => o.OrderDishes);
            return await Task.FromResult(orders.AsEnumerable());
        }
    }
}
