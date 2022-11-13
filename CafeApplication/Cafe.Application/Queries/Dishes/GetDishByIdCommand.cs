using Cafe.Domain;
using MediatR;

namespace Cafe.Application.Queries.Dishes
{
    public record GetDishByIdCommand(int Id) : IRequest<Dish>;
}
