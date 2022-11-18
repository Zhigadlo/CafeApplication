﻿using Cafe.Application.Commands.Orders;
using Cafe.Application.Queries.Dishes;
using Cafe.Application.Queries.Employees;
using Cafe.Application.Queries.Orders;
using Cafe.Domain;
using MediatR;
using Microsoft.Extensions.Caching.Memory;

namespace Cafe.Web.Services
{
    public class OrderService : BaseService
    {
        public OrderService(IMediator mediator, IMemoryCache cache) : base(mediator, cache) { }

        public async Task<IEnumerable<Order>> GetAll()
        {
            IEnumerable<Order> orders;
            if(!_cache.TryGetValue("orders", out orders))
            {
                orders = await _mediator.Send(new GetAllOrdersCommand());
                _cache.Set("orders", orders.ToList());
            }
            return orders;
        }

        public async Task<Order> GetOrderById(int id)
        {
            return await _mediator.Send(new GetOrderByIdCommand(id));
        }

        public async Task<Order> Create(string customerName, DateTime date, string phoneNumber, int paymentMethod, int employee, int[] dishIds, int[] count)
        {
            CacheClear();
            return await _mediator.Send(new CreateOrderCommand(customerName, date, phoneNumber, paymentMethod, employee, dishIds, count));
        }

        public async Task<Order> Delete(int id)
        {
            CacheClear();
            return await _mediator.Send(new DeleteOrderCommand(id));
        }

        public async Task<Order> Update(int id, string customerName, DateTime date, string phoneNumber, int paymentMethod,
                                     int isComplete, int employee, int[] dishIds, int[] count)
        {
            CacheClear();
            return await _mediator.Send(new UpdateOrderCommand(id, customerName, date, phoneNumber, paymentMethod, isComplete, employee, dishIds, count));
        }
    }
}
