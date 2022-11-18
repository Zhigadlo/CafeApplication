using Cafe.Application.Queries.Professions;
using Cafe.Domain;
using MediatR;
using Microsoft.Extensions.Caching.Memory;

namespace Cafe.Web.Services
{
    public class ProfessionService : BaseService
    {
        public ProfessionService(IMediator mediator, IMemoryCache cache) : base(mediator, cache) { }

        public async Task<IEnumerable<Profession>> GetAll()
        {
            IEnumerable<Profession> professions;
            if (!_cache.TryGetValue("professions", out professions))
            {
                professions = await _mediator.Send(new GetAllProfessionsCommand());
                _cache.Set("professions", professions.ToList());
            }
            return professions;
        }
    }
}
