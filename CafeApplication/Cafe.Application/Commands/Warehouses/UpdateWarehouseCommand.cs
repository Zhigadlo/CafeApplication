using Cafe.Domain;
using MediatR;

namespace Cafe.Application.Commands.Warehouses
{
    public record UpdateWarehouseCommand(int Id, IngridientsWarehouse Warehouse) : IRequest<IngridientsWarehouse>;
}
