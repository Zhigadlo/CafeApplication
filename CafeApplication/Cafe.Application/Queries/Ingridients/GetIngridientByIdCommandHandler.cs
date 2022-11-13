using Cafe.Application.Interfaces;
using Cafe.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Cafe.Application.Queries.Ingridients
{
    public class GetIngridientByIdCommandHandler : CafeContextHandler, IRequestHandler<GetIngridientByIdCommand, Ingridient>
    {
        public GetIngridientByIdCommandHandler(ICafeDbContext context) : base(context) { }
        
        public async Task<Ingridient> Handle(GetIngridientByIdCommand command, CancellationToken cancellationToken)
        {
            return await _context.Ingridients.FirstAsync(i => i.Id == command.Id);
        }
    }
}
