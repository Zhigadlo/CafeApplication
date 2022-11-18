using Cafe.Application.Commands.Employees;
using Cafe.Application.Queries.Employees;
using Cafe.Application.Queries.Professions;
using Cafe.Domain;
using MediatR;
using Microsoft.Extensions.Caching.Memory;

namespace Cafe.Web.Services
{
    public class EmployeeService : BaseService
    {
        public EmployeeService(IMediator mediator, IMemoryCache cache) : base(mediator, cache) { }

        public async Task<IEnumerable<Employee>> GetAll()
        {
            return await _mediator.Send(new GetAllEmployeesCommand());
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            return await _mediator.Send(new GetEmployeeByIdCommand(id));
        }

        public async Task<Employee> Add(Employee employee, string profession)
        {
            return await _mediator.Send(new AddEmployeeCommand(employee, profession));
        }

        public async Task<Employee> Delete(int id)
        {
            return await _mediator.Send(new DeleteEmployeeCommand(id));
        }

        public async Task<Employee> Update(int id, Employee employee, string proffession)
        {
            return await _mediator.Send(new UpdateEmployeeCommand(id, employee, proffession));
        }
    }
}
