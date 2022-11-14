using Cafe.Domain;
using MediatR;

namespace Cafe.Application.Queries.Orders
{
    public record GetOrderByIdCommand(int Id) : IRequest<Order>;
}
