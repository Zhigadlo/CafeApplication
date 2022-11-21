using MediatR;
using Cafe.Domain;

namespace Cafe.Application.Queries.Providers
{
    public record GetProviderByIdCommand(int Id) : IRequest<Provider>;
}
