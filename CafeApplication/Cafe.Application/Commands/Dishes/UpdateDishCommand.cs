using Cafe.Domain;
using MediatR;

namespace Cafe.Application.Commands.Dishes
{
    public record UpdateDishCommand(int Id, Dish Dish, int[] IngridientIds, int[] Weights) : IRequest<Dish>;
}
