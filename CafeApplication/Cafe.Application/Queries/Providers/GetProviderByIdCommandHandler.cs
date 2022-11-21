using Cafe.Application.Interfaces;
using Cafe.Domain;
using MediatR;

namespace Cafe.Application.Queries.Providers
{
    public class GetProviderByIdCommandHandler : CafeContextHandler, IRequestHandler<GetProviderByIdCommand, Provider>
    {
        public GetProviderByIdCommandHandler(ICafeDbContext context) : base(context) { }

        public async Task<Provider> Handle(GetProviderByIdCommand command, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_context.Providers.First(p => p.Id == command.Id));
        }
    }
}
