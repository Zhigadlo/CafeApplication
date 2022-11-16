using Cafe.Application.Interfaces;
using Cafe.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Cafe.Application.Queries.Warehouses
{
    public class GetAllWarehousesCommandHandler : CafeContextHandler, IRequestHandler<GetAllWarehousesCommand, IEnumerable<IngridientsWarehouse>>
    {
        public GetAllWarehousesCommandHandler(ICafeDbContext context) : base(context) { }

        public async Task<IEnumerable<IngridientsWarehouse>> Handle(GetAllWarehousesCommand request, CancellationToken cancellationToken)
        {
            var ingridientWarhouses = _context.IngridientsWarehouses.Include(iw => iw.Provider).Include(iw => iw.Ingridient);
            return await Task.FromResult(ingridientWarhouses);
        }
    }
}
