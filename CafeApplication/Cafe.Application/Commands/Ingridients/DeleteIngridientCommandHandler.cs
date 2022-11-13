using Cafe.Application.Interfaces;
using Cafe.Domain;
using MediatR;

namespace Cafe.Application.Commands.Ingridients
{
    public class DeleteIngridientCommandHandler : IRequestHandler<DeleteIngridientCommand, Ingridient>
    {
        private ICafeDbContext _context;
        public DeleteIngridientCommandHandler(ICafeDbContext context)
        {
            _context = context;
        }

        public async Task<Ingridient> Handle(DeleteIngridientCommand command, CancellationToken cancellationToken)
        {
            Ingridient ingridient = _context.Ingridients.FirstOrDefault(i => i.Id == command.Id);
            _context.Ingridients.Remove(ingridient);
            await _context.Save();
            return ingridient;
        }
    }
}
