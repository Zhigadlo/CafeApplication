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
            Ingridient ingridient = command.Ingridient;
            ingridient.Id = command.Id;
            _context.Ingridients.Update(ingridient);
            await _context.Save();
            return ingridient;
        }
    }
}
