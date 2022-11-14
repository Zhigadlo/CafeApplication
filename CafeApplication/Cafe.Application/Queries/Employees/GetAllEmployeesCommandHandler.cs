using Cafe.Application.Interfaces;
using Cafe.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Cafe.Application.Queries.Employees
{
    public class GetAllEmployeesCommandHandler : CafeContextHandler, IRequestHandler<GetAllEmployeesCommand, IEnumerable<Employee>>
    {
        public GetAllEmployeesCommandHandler(ICafeDbContext context) : base(context) { }

        public async Task<IEnumerable<Employee>> Handle(GetAllEmployeesCommand command, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_context.Employees.Include(e => e.Profession));
        }
    }
}
