using Cafe.Domain;
using MediatR;

namespace Cafe.Application.Queries.Orders
{
    public record GetAllOrdersCommand() : IRequest<IEnumerable<Order>>;
}
