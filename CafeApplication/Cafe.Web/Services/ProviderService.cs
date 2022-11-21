using Cafe.Application.Commands.Providers;
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

        public async Task<Provider> GetProviderById(int id)
        {
            return await _mediator.Send(new GetProviderByIdCommand(id));
        }
        public async Task<Provider> Delete(int id)
        {
            CacheClear();
            return await _mediator.Send(new DeleteProviderCommand(id));
        }

        public async Task<Provider> AddProvider(Provider provider)
        {
            CacheClear();
            return await _mediator.Send(new AddProviderCommand(provider));
        }

        public async Task<Provider> UpdateProvider(int id, Provider provider)
        {
            CacheClear();
            return await _mediator.Send(new UpdateProviderCommand(id, provider));
        }
    }
}
