using Cafe.Domain;
using MediatR;

namespace Cafe.Application.Commands.Orders
{
    public record DeleteOrderCommand(int Id) : IRequest<Order>;
}
