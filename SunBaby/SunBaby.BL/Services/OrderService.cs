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

        public void AddOrder()
        {
            var order = new Order()
            {
                Id = Guid.NewGuid(),
                StartRent = new DateTime(2021, 10, 11),
                PeriodWeeks = 4,
                User = new UserShort()
                {
                    Id= Guid.NewGuid(),
                    Address = "TestAddress",
                    Birthday = new DateTime(1994, 01, 05),
                    FirstName = "TestName",
                    LastName = "TestName2",
                    Surname = "TestName3",
                    PassportDate = new DateTime(2020, 05, 15),
                    PassportNumber =  "МС233333",
                    Phone = "+375336360124"              
                },
                Toy = new ToyShort() 
                {
                    Id = Guid.NewGuid(),
                    Description = "TestComment",
                    Name = "TestName",
                    Price = 200,
                    Type = "TestType",
                    Tarif = 2
                }
            };
            _orderRepository.CreateAsync(order);
        }
    }
}