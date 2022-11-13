using Cafe.Application.Interfaces;
using Cafe.Domain;
using MediatR;

namespace Cafe.Application.Commands.Ingridients
{
    public class UpdateIngridientCommandHandler : CafeContextHandler, IRequestHandler<UpdateIngridientCommand, Ingridient>
    {
        public UpdateIngridientCommandHandler(ICafeDbContext context) : base(context) { }
        public async Task<Ingridient> Handle(UpdateIngridientCommand command, CancellationToken cancellationToken)
        {
            Ingridient ingridient = _context.Ingridients.FirstOrDefault(i => i.Id == command.Id);
            ingridient.Name = command.NewName;
            _context.Ingridients.Update(ingridient);
            await _context.Save();
            return ingridient;
        }
    }
}
