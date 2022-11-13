using Cafe.Application.Interfaces;
using Cafe.Domain;
using MediatR;

namespace Cafe.Application.Commands.Employees
{
    public class DeleteEmployeeCommandHandler : CafeContextHandler, IRequestHandler<DeleteEmployeeCommand, Employee>
    {
        public DeleteEmployeeCommandHandler(ICafeDbContext context) : base(context) { }

        public async Task<Employee> Handle(DeleteEmployeeCommand command, CancellationToken cancellationToken)
        {
            var employee = _context.Employees.First(e => e.Id == command.Id);
            _context.Employees.Remove(employee);
            await _context.Save();
            return await Task.FromResult(employee);
        }
    }
}
