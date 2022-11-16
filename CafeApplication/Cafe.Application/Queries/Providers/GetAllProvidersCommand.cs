using Cafe.Domain;
using MediatR;

namespace Cafe.Application.Queries.Providers
{
    public record GetAllProvidersCommand() : IRequest<IEnumerable<Provider>>;
}
