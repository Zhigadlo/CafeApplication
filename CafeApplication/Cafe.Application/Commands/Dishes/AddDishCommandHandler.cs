using Cafe.Application.Interfaces;
using Cafe.Domain;
using MediatR;

namespace Cafe.Application.Commands.Dishes
{
    public class AddDishCommandHandler : CafeContextHandler, IRequestHandler<AddDishCommand, Dish>
    {
        public AddDishCommandHandler(ICafeDbContext context) : base(context) { }
        public async Task<Dish> Handle(AddDishCommand command, CancellationToken cancellationToken)
        {
            var newDish = new Dish();
            newDish.Name = command.Name;
            newDish.Cost = command.Cost;
            newDish.CookingTime = command.CookingTime;
            await _context.Dishes.AddAsync(newDish);
            await _context.Save();
            Dish dish = _context.Dishes.First(x => x.Name == command.Name);
            for (int i = 0; i < command.IngridientIds.Length; i++)
            {
                var ingridientDish = new IngridientsDish();
                ingridientDish.Dish = dish;
                ingridientDish.Ingridient = _context.Ingridients.First(x => x.Id == command.IngridientIds[i]);
                ingridientDish.IngridientWeight = command.Weights[i];
                await _context.IngridientsDishes.AddAsync(ingridientDish);
            }
            await _context.Save();
            return dish;
        }
    }
}
