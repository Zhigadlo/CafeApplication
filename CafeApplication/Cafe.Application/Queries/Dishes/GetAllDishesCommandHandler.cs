using Cafe.Application.Interfaces;
using Cafe.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Cafe.Application.Queries.Dishes
{
    public class GetAllDishesCommandHandler : CafeContextHandler, IRequestHandler<GetAllDishesCommand, IEnumerable<Dish>>
    {
        public GetAllDishesCommandHandler(ICafeDbContext context) : base(context) { }
        public async Task<IEnumerable<Dish>> Handle(GetAllDishesCommand command, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_context.Dishes.Include(d => d.IngridientsDishes).AsEnumerable());
        }
    }
}
