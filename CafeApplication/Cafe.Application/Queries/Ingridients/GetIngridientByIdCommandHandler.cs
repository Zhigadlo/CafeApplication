using Cafe.Application.Interfaces;
using Cafe.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.Application.Queries.Ingridients
{
    public class GetIngridientByIdCommandHandler : IRequestHandler<GetIngridientByIdCommand, Ingridient>
    {
        private ICafeDbContext _context;
        public GetIngridientByIdCommandHandler(ICafeDbContext context)
        {
            _context = context;
        }
        public async Task<Ingridient> Handle(GetIngridientByIdCommand command, CancellationToken cancellationToken)
        {
            return await _context.Ingridients.FirstAsync(i => i.Id == command.Id);
        }
    }
}
