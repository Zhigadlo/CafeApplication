using Cafe.Application.Interfaces;
using Cafe.Domain;
using MediatR;

namespace Cafe.Application.Commands.Employees
{
    public class UpdateEmployeeCommandHandler : CafeContextHandler, IRequestHandler<UpdateEmployeeCommand, Employee>
    {
        public UpdateEmployeeCommandHandler(ICafeDbContext context) : base(context) { }

        public async Task<Employee> Handle(UpdateEmployeeCommand command, CancellationToken cancellationToken)
        {
            var employee = command.Employee;
            employee.Id = command.Id;
            employee.Profession = _context.Professions.First(p => p.Name == command.Profession);
            _context.Employees.Update(employee);
            await _context.Save();
            return await Task.FromResult(employee);
        }
    }
}
