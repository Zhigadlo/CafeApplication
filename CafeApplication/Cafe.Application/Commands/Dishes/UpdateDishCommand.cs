using Cafe.Domain;
using MediatR;

namespace Cafe.Application.Commands.Dishes
{
    public record UpdateDishCommand(int Id, string Name, int Cost, int CookingTime, int[] IngridientIds, int[] Weights) : IRequest<Dish>;
}
