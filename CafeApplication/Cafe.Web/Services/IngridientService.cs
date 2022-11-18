using Cafe.Application.Commands.Ingridients;
using Cafe.Application.Queries.Ingridients;
using Cafe.Domain;
using MediatR;
using Microsoft.Extensions.Caching.Memory;

namespace Cafe.Web.Services
{
    public class IngridientService : BaseService
    {
        public IngridientService(IMediator mediator, IMemoryCache cache) : base(mediator, cache) { }
        public async Task<IEnumerable<Ingridient>> GetAll()
        {
            IEnumerable<Ingridient> ingridients;
            if (!_cache.TryGetValue("ingridients", out ingridients))
            {
                ingridients = await _mediator.Send(new GetAllIngridientsCommand());
                _cache.Set("ingridients", ingridients.ToList());
            }
            return ingridients;
        }

        public async Task<Ingridient> GetIngridientById(int id)
        {
            return await _mediator.Send(new GetIngridientByIdCommand(id));
        }
        public async Task CreateIngridient(string name)
        {
            CacheClear();
            await _mediator.Send(new AddIngridientCommand(name));
        }

        public async Task Delete(int id)
        {
            CacheClear();
            await _mediator.Send(new DeleteIngridientCommand(id));
        }

        public async Task Update(int id, string name)
        {
            var command = new UpdateIngridientCommand(id, name);
            await _mediator.Send(command);
            CacheClear();
        }
    }
}
