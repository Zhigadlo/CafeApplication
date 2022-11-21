using Cafe.Domain;
using MediatR;

namespace Cafe.Application.Commands.Providers
{
    public record DeleteProviderCommand(int Id) : IRequest<Provider>;
}
