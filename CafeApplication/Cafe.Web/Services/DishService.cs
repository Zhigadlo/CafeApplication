using Cafe.Application.Commands.Dishes;
using Cafe.Application.Queries.Dishes;
using Cafe.Application.Queries.Ingridients;
using Cafe.Domain;
using MediatR;
using Microsoft.Extensions.Caching.Memory;

namespace Cafe.Web.Services
{
    public class DishService : BaseService
    {
        public DishService(IMediator mediator, IMemoryCache cache) : base(mediator, cache) { }

        public async Task<IEnumerable<Dish>> GetAllDishes()
        {
            return await _mediator.Send(new GetAllDishesCommand());
        }

        public async Task<IEnumerable<Ingridient>> GetAllIngridients()
        {
            return await _mediator.Send(new GetAllIngridientsCommand());
        }
        public async Task<Dish> GetDishById(int id)
        {
            return await _mediator.Send(new GetDishByIdCommand(id));
        }

        public async Task<Dish> AddDish(string name, int cost, int cookingTime, int[] ingridientIds, int[] weights)
        {
            return await _mediator.Send(new AddDishCommand(name, cost, cookingTime, ingridientIds, weights));
        }
        public async Task<Dish> Delete(int id)
        {
            return await _mediator.Send(new DeleteDishCommand(id));
        }

        public async Task<Dish> Update(int id, string name, int cost, int cookingTime, int[] ingridientIds, int[] weights)
        {
            return await _mediator.Send(new UpdateDishCommand(id, name, cost, cookingTime, ingridientIds, weights));
        }
    }
}
