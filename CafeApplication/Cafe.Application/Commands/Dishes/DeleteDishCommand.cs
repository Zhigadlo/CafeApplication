using Cafe.Domain;
using MediatR;

namespace Cafe.Application.Commands.Dishes
{
    public record DeleteDishCommand(int Id) : IRequest<Dish>;
}
