using Cafe.Application.Queries.Providers;
using Cafe.Domain;
using MediatR;
using Microsoft.Extensions.Caching.Memory;

namespace Cafe.Web.Services
{
    public class ProviderService : BaseService
    {
        public ProviderService(IMediator mediator, IMemoryCache cache) : base(mediator, cache) { }

        public async Task<IEnumerable<Provider>> GetAll()
        {
            return await _mediator.Send(new GetAllProvidersCommand());
        }
    }
}
