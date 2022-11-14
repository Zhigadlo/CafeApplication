using Cafe.Application.Interfaces;
using Cafe.Domain;
using MediatR;

namespace Cafe.Application.Commands.Employees
{
    public class AddEmployeeCommandHandler : CafeContextHandler, IRequestHandler<AddEmployeeCommand, Employee>
    {
        public AddEmployeeCommandHandler(ICafeDbContext context) : base(context) { }

        public async Task<Employee> Handle(AddEmployeeCommand command, CancellationToken cancellationToken)
        {
            var employee = command.Employee;
            employee.Profession = _context.Professions.First(p => p.Name == command.Profession);
            await _context.Employees.AddAsync(employee);
            await _context.Save();
            return await Task.FromResult(employee);
        }
    }
}
