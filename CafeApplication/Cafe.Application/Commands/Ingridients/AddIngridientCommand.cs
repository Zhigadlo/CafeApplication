using Cafe.Domain;
using MediatR;

namespace Cafe.Application.Commands.Ingridients
{
    public record AddIngridientCommand(Ingridient Ingridient) : IRequest<Ingridient>;
}
