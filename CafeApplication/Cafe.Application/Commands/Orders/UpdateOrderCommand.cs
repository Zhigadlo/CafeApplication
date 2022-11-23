using Cafe.Domain;
using MediatR;

namespace Cafe.Application.Commands.Orders
{
    public record UpdateOrderCommand(int Id, Order Order, int Employee, int[] DishIds, int[] Count) : IRequest<Order>;
}
