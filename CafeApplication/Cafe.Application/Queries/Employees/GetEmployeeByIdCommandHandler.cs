using Cafe.Application.Interfaces;
using Cafe.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Cafe.Application.Queries.Employees
{
    internal class GetEmployeeByIdCommandHandler : CafeContextHandler, IRequestHandler<GetEmployeeByIdCommand, Employee>
    {
        public GetEmployeeByIdCommandHandler(ICafeDbContext context) : base(context) { }

        public async Task<Employee> Handle(GetEmployeeByIdCommand command, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_context.Employees.Include(e => e.Profession).First(e => e.Id == command.Id));
        }
    }
}
