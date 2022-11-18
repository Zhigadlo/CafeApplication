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
            IEnumerable<Provider> providers;
            if (!_cache.TryGetValue("providers", out providers))
            {
                providers = await _mediator.Send(new GetAllProvidersCommand());
                _cache.Set("providers", providers.ToList());
            }
            return providers;
        }
    }
}
