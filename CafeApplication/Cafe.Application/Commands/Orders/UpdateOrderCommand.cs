using Cafe.Domain;
using MediatR;

namespace Cafe.Application.Commands.Orders
{
    public record UpdateOrderCommand(int Id, string CustomerName, DateTime Date, string PhoneNumber, int PaymentMethod,
                                     int IsComplete, int Employee, int[] DishIds, int[] Count) : IRequest<Order>;
}
