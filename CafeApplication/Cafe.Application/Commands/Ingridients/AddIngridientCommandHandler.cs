using Cafe.Application.Interfaces;
using Cafe.Domain;
using MediatR;

namespace Cafe.Application.Commands.Ingridients
{
    public class AddIngridientCommandHandler : CafeContextHandler, IRequestHandler<AddIngridientCommand, Ingridient>
    {
        public AddIngridientCommandHandler(ICafeDbContext context) : base(context) { } 
        
        public async Task<Ingridient> Handle(AddIngridientCommand command, CancellationToken cancellationToken)
        {
            Ingridient ingridient = new Ingridient { Name = command.Name };

            await _context.Ingridients.AddAsync(ingridient);
            await _context.Save();
            return ingridient;
        }
    }
}
