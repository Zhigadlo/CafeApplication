using Cafe.Application.Interfaces;
using Cafe.Domain;
using MediatR;

namespace Cafe.Application.Queries.Providers
{
    public class GetAllProvidersCommandHandler : CafeContextHandler, IRequestHandler<GetAllProvidersCommand, IEnumerable<Provider>>
    {
        public GetAllProvidersCommandHandler(ICafeDbContext context) : base(context) { }

        public async Task<IEnumerable<Provider>> Handle(GetAllProvidersCommand request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_context.Providers.AsEnumerable());
        }
    }
}
