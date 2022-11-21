using Cafe.Application.Interfaces;
using Cafe.Domain;
using MediatR;

namespace Cafe.Application.Commands.Providers
{
    public class DeleteProviderCommandHandler : CafeContextHandler, IRequestHandler<DeleteProviderCommand, Provider>
    {
        public DeleteProviderCommandHandler(ICafeDbContext context) : base(context) { }

        public async Task<Provider> Handle(DeleteProviderCommand command, CancellationToken cancellationToken)
        {
            var provider = _context.Providers.First(p => p.Id == command.Id);
            _context.Providers.Remove(provider);
            await _context.Save();
            return provider;
        }
    }
}
