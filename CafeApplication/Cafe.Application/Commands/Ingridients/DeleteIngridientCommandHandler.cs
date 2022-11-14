using Cafe.Application.Interfaces;
using Cafe.Domain;
using MediatR;

namespace Cafe.Application.Commands.Ingridients
{
    public class DeleteIngridientCommandHandler : CafeContextHandler, IRequestHandler<DeleteIngridientCommand, Ingridient>
    {
        public DeleteIngridientCommandHandler(ICafeDbContext context) : base(context) { }

        public async Task<Ingridient> Handle(DeleteIngridientCommand command, CancellationToken cancellationToken)
        {
            Ingridient ingridient = _context.Ingridients.FirstOrDefault(i => i.Id == command.Id);
            _context.Ingridients.Remove(ingridient);
            await _context.Save();
            return ingridient;
        }
    }
}
