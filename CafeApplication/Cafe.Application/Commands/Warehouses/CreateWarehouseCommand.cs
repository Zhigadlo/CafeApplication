using Cafe.Domain;
using MediatR;

namespace Cafe.Application.Commands.Warehouses
{
    public record CreateWarehouseCommand(IngridientsWarehouse Warehouse) : IRequest<IngridientsWarehouse>;
}
