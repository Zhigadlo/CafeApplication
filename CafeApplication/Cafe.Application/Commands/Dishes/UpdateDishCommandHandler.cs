using Cafe.Application.Interfaces;
using Cafe.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Cafe.Application.Commands.Dishes
{
    public class UpdateDishCommandHandler : CafeContextHandler, IRequestHandler<UpdateDishCommand, Dish>
    {
        public UpdateDishCommandHandler(ICafeDbContext context) : base(context) { }
        public async Task<Dish> Handle(UpdateDishCommand command, CancellationToken cancellationToken)
        {
            var dishForUpdate = _context.Dishes.Include(x => x.IngridientsDishes).First(d => d.Id == command.Id);
            dishForUpdate.Name = command.Name;
            dishForUpdate.Cost = command.Cost;
            dishForUpdate.CookingTime = command.CookingTime;
            for (int i = 0; i < command.IngridientIds.Length; i++)
            {
                var ingridientDish = _context.IngridientsDishes.FirstOrDefault(x => x.IngridientId == command.IngridientIds[i] && x.DishId == dishForUpdate.Id);
                if (ingridientDish == null)
                {
                    var newIngridientDish = new IngridientsDish();
                    newIngridientDish.Dish = dishForUpdate;
                    newIngridientDish.Ingridient = _context.Ingridients.First(x => x.Id == command.IngridientIds[i]);
                    newIngridientDish.IngridientWeight = command.Weights[i];
                    await _context.IngridientsDishes.AddAsync(newIngridientDish);
                }
                else
                {
                    ingridientDish.Dish = dishForUpdate;
                    ingridientDish.Ingridient = _context.Ingridients.First(x => x.Id == command.IngridientIds[i]);
                    ingridientDish.IngridientWeight = command.Weights[i];
                    _context.IngridientsDishes.Update(ingridientDish);
                }
            }
            _context.Dishes.Update(dishForUpdate);
            await _context.Save();
            return await Task.FromResult(dishForUpdate);
        }
    }
}
