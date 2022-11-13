using Cafe.Application.Interfaces;
using Cafe.Domain;
using MediatR;

namespace Cafe.Application.Commands.Ingridients
{
    public class AddIngridientCommandHandler : IRequestHandler<AddIngridientCommand, Ingridient>
    {
        private ICafeDbContext _context;

        public AddIngridientCommandHandler(ICafeDbContext context)
        {
            _context = context;
        }
        public async Task<Ingridient> Handle(AddIngridientCommand command, CancellationToken cancellationToken)
        {
            Ingridient ingridient = new Ingridient { Name = command.Name };

            await _context.Ingridients.AddAsync(ingridient);
            await _context.Save();
            return ingridient;
        }
    }
}
