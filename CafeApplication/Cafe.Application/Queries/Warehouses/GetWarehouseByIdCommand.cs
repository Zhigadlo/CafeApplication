using Cafe.Domain;
using MediatR;

namespace Cafe.Application.Queries.Warehouses
{
    public record GetWarehouseByIdCommand(int Id) : IRequest<IngridientsWarehouse>;
}
