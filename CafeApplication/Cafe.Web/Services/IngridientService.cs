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
            return await _mediator.Send(new GetAllIngridientsCommand()); ;
        }

        public async Task<Ingridient> GetIngridientById(int id)
        {
            Ingridient? ingridient = null;
            if(!_cache.TryGetValue(id, out ingridient))
            {
                ingridient = await _mediator.Send(new GetIngridientByIdCommand(id));
                if(ingridient != null)
                {
                    _cache.Set(id, ingridient);
                }
            }
            return ingridient;
        }
        public async Task CreateIngridient(string name)
        {
            var command = new AddIngridientCommand(name);
            await _mediator.Send(command);
        }

        public async Task Delete(int id)
        {
            var command = new DeleteIngridientCommand(id);
            _cache.Remove(id);
            await _mediator.Send(command);
        }

        public async Task Update(int id, string name)
        {
            var command = new UpdateIngridientCommand(id, name);
            Ingridient ingridient = await _mediator.Send(command);
            _cache.Set(id, ingridient); 
        }
    }
}
