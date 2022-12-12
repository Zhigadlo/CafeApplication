using Cafe.Application.Interfaces;
using Cafe.Domain;
using MediatR;

namespace Cafe.Application.Commands.Providers
{
    public class AddProviderCommandHandler : CafeContextHandler, IRequestHandler<AddProviderCommand, Provider>
    {
        public AddProviderCommandHandler(ICafeDbContext context) : base(context) { }

        public async Task<Provider> Handle(AddProviderCommand command, CancellationToken cancellationToken)
        {
            _context.Providers.Add(command.Provider);
            await _context.Save();
            return await Task.FromResult(command.Provider);
        }
    }
}
