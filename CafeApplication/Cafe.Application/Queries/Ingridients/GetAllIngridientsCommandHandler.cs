using Cafe.Application.Interfaces;
using Cafe.Domain;
using MediatR;

namespace Cafe.Application.Queries.Ingridients
{
    public class GetAllIngridientsCommandHandler : IRequestHandler<GetAllIngridientsCommand, IEnumerable<Ingridient>>
    {
        private readonly ICafeDbContext _context;

        public GetAllIngridientsCommandHandler(ICafeDbContext context)
        {
            _context = context;
        }

        public Task<IEnumerable<Ingridient>> Handle(GetAllIngridientsCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_context.Ingridients.AsEnumerable());
        }
    }
}
