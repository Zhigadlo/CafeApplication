using Cafe.Application.Interfaces;
using Cafe.Domain;
using MediatR;

namespace Cafe.Application.Queries.Professions
{
    public class GetAllProfessionsCommandHandler : CafeContextHandler, IRequestHandler<GetAllProfessionsCommand, IEnumerable<Profession>>
    {
        public GetAllProfessionsCommandHandler(ICafeDbContext context) : base(context) { }

        public async Task<IEnumerable<Profession>> Handle(GetAllProfessionsCommand request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_context.Professions.AsEnumerable());
        }
    }
}
