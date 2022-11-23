using Cafe.Application.Commands.Dishes;
using Cafe.Application.Queries.Dishes;
using Cafe.Domain;
using MediatR;
using Microsoft.Extensions.Caching.Memory;

namespace Cafe.Web.Services
{
    public class DishService : BaseService
    {
        public DishService(IMediator mediator, IMemoryCache cache) : base(mediator, cache) { }

        public async Task<IEnumerable<Dish>> GetAll()
        {
            IEnumerable<Dish> dishes;

            if (!_cache.TryGetValue("dishes", out dishes))
            {
                dishes = await _mediator.Send(new GetAllDishesCommand());
                _cache.Set("dishes", dishes.ToList());
            }

            return dishes;
        }

        public async Task<Dish> GetDishById(int id)
        {
            return await _mediator.Send(new GetDishByIdCommand(id));
        }

        public async Task<Dish> AddDish(Dish dish, int[] ingridientIds, int[] weights)
        {
            CacheClear();
            return await _mediator.Send(new AddDishCommand(dish, ingridientIds, weights));
        }
        public async Task<Dish> Delete(int id)
        {
            CacheClear();
            return await _mediator.Send(new DeleteDishCommand(id));
        }

        public async Task<Dish> Update(int id, Dish dish, int[] ingridientIds, int[] weights)
        {
            CacheClear();
            return await _mediator.Send(new UpdateDishCommand(id, dish, ingridientIds, weights));
        }
    }
}
