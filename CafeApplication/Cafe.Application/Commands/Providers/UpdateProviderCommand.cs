using Cafe.Domain;
using MediatR;

namespace Cafe.Application.Commands.Providers
{
    public record UpdateProviderCommand(int Id, Provider UpdatedProvider) : IRequest<Provider>;
}
