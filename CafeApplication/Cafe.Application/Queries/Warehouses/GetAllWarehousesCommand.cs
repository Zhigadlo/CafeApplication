using Cafe.Domain;
using MediatR;

namespace Cafe.Application.Queries.Warehouses
{
    public record GetAllWarehousesCommand() : IRequest<IEnumerable<IngridientsWarehouse>>;
}
