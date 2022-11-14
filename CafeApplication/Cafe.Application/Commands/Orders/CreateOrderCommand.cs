using Cafe.Domain;
using MediatR;

namespace Cafe.Application.Commands.Orders
{
    public record CreateOrderCommand(string CustomerName, DateTime Date, string PhoneNumber, int PaymentMethod, 
                                     int Employee, int[] DishIds, int[] Count) : IRequest<Order>;
}
