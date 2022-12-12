using Cafe.Domain;
using MediatR;

namespace Cafe.Application.Commands.Providers
{
    public record AddProviderCommand(Provider Provider) : IRequest<Provider>;
}
