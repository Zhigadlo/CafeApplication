using Cafe.Domain;
using MediatR;

namespace Cafe.Application.Queries.Ingridients
{
    public record GetIngridientByIdCommand(int Id) : IRequest<Ingridient>;
}
