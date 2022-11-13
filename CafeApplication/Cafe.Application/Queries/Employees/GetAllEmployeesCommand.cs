using Cafe.Domain;
using MediatR;

namespace Cafe.Application.Queries.Employees
{
    public record GetAllEmployeesCommand() : IRequest<IEnumerable<Employee>>;
}
