using Cafe.Domain;
using MediatR;

namespace Cafe.Application.Queries.Ingridients
{
    public record GetAllIngridientsCommand : IRequest<IEnumerable<Ingridient>>;
}
