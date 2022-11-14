using Cafe.Application.Interfaces;
using Cafe.Domain;
using MediatR;

namespace Cafe.Application.Commands.Dishes
{
    public class DeleteDishCommandHandler : CafeContextHandler, IRequestHandler<DeleteDishCommand, Dish>
    {
        public DeleteDishCommandHandler(ICafeDbContext context) : base(context) { }
        public async Task<Dish> Handle(DeleteDishCommand command, CancellationToken cancellationToken)
        {
            Dish? dish = _context.Dishes.FirstOrDefault(d => d.Id == command.Id);
            _context.IngridientsDishes.RemoveRange(_context.IngridientsDishes.Where(d => d.DishId == command.Id));
            _context.OrderDishes.RemoveRange(_context.OrderDishes.Where(d => d.DishId == command.Id));
            _context.Dishes.Remove(dish);
            await _context.Save();
            return await Task.FromResult(dish);
        }
    }
}
