using Cafe.Domain;
using MediatR;

namespace Cafe.Application.Commands.Employees
{
    public record UpdateEmployeeCommand(int Id, Employee Employee, string Profession) : IRequest<Employee>;
}
