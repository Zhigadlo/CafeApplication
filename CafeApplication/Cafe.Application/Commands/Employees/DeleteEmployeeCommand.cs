using Cafe.Domain;
using MediatR;

namespace Cafe.Application.Commands.Employees
{
    public record DeleteEmployeeCommand(int Id) : IRequest<Employee>;
}
