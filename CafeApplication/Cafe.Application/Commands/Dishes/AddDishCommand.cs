using Cafe.Domain;
using MediatR;

namespace Cafe.Application.Commands.Dishes
{
    public record AddDishCommand(Dish Dish, int[] IngridientIds, int[] Weights) : IRequest<Dish>;
}
