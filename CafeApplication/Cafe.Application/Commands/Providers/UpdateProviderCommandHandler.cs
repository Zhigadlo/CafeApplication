using Cafe.Application.Interfaces;
using Cafe.Domain;
using MediatR;

namespace Cafe.Application.Commands.Providers
{
    public class UpdateProviderCommandHandler : CafeContextHandler, IRequestHandler<UpdateProviderCommand, Provider>
    {
        public UpdateProviderCommandHandler(ICafeDbContext context) : base(context) { }

        public async Task<Provider> Handle(UpdateProviderCommand command, CancellationToken cancellationToken)
        {
            var provider = command.UpdatedProvider;
            provider.Id = command.Id;
            _context.Providers.Update(provider);
            await _context.Save();
            return await Task.FromResult(provider);
        }
    }
}
