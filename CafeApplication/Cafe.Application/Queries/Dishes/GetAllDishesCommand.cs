using Cafe.Domain;
using MediatR;

namespace Cafe.Application.Queries.Dishes
{
    public record GetAllDishesCommand() : IRequest<IEnumerable<Dish>>;
}
