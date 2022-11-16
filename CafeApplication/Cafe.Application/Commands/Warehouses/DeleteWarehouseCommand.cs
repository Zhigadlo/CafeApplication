using Cafe.Domain;
using MediatR;

namespace Cafe.Application.Commands.Warehouses
{
    public record DeleteWarehouseCommand(int Id) : IRequest<IngridientsWarehouse>;
}
