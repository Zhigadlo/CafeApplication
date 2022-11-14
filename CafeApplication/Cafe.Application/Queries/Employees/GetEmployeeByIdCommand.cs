using Cafe.Domain;
using MediatR;

namespace Cafe.Application.Queries.Employees
{
    public record GetEmployeeByIdCommand(int Id) : IRequest<Employee>;
}
