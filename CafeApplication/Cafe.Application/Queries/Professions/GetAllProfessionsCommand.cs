using Cafe.Domain;
using MediatR;

namespace Cafe.Application.Queries.Professions
{
    public record GetAllProfessionsCommand() : IRequest<IEnumerable<Profession>>;
}
