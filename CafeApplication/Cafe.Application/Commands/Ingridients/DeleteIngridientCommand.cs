using Cafe.Domain;
using MediatR;

namespace Cafe.Application.Commands.Ingridients
{
    public record DeleteIngridientCommand(int Id) : IRequest<Ingridient>;
}
