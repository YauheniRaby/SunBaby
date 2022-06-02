using SunBaby.BL.Services.Abstract;
using SunBaby.DA.Models;
using SunBaby.DA.Repositories.Abstract;
using System;

namespace SunBaby.BL.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }        
    }
}