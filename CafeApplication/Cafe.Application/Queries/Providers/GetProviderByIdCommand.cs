using Cafe.Domain;
using MediatR;

namespace Cafe.Application.Queries.Providers
{
    public record GetProviderByIdCommand(int Id) : IRequest<Provider>;
}
