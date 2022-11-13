using Cafe.Domain;
using MediatR;

namespace Cafe.Application.Commands.Employees
{
    public record AddEmployeeCommand(Employee Employee, string Profession) : IRequest<Employee>;
}
