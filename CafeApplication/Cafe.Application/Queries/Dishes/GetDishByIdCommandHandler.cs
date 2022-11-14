using Cafe.Application.Interfaces;
using Cafe.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Cafe.Application.Queries.Dishes
{
    public class GetDishByIdCommandHandler : CafeContextHandler, IRequestHandler<GetDishByIdCommand, Dish>
    {
        public GetDishByIdCommandHandler(ICafeDbContext context) : base(context) { }
        public async Task<Dish> Handle(GetDishByIdCommand command, CancellationToken cancellationToken)
        {
            var dish = _context.Dishes.Include(x => x.IngridientsDishes).First(x => x.Id == command.Id);
            return await Task.FromResult(dish);
        }
    }
}
