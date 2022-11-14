using Cafe.Application.Interfaces;
using Cafe.Domain;
using MediatR;

namespace Cafe.Application.Queries.Ingridients
{
    public class GetAllIngridientsCommandHandler : CafeContextHandler, IRequestHandler<GetAllIngridientsCommand, IEnumerable<Ingridient>>
    {
        public GetAllIngridientsCommandHandler(ICafeDbContext context) : base(context) { }

        public Task<IEnumerable<Ingridient>> Handle(GetAllIngridientsCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_context.Ingridients.AsEnumerable());
        }
    }
}
