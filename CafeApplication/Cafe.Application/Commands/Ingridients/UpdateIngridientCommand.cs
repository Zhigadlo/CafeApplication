using Cafe.Domain;
using MediatR;

namespace Cafe.Application.Commands.Ingridients
{
    public record UpdateIngridientCommand(int Id, string NewName) : IRequest<Ingridient>;
}
