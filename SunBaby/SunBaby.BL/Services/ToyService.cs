using SunBaby.BL.Services.Abstract;
using SunBaby.DA.Models;
using SunBaby.DA.Repositories.Abstract;
using System;

namespace SunBaby.BL.Services
{
    public class ToyService : IToyService
    {
        private readonly IToyRepository _toyRepository;

        public ToyService(IToyRepository toyRepository)
        {
            _toyRepository = toyRepository;
        }

        public void AddToy()
        {
            var toy = new Toy()
            {
                Description = "TestTest",
                Id = Guid.NewGuid(),
                Name = "TestName",
                Price = 100,
                Tarif1 = 1,
                Tarif2 = 2,
                Tarif3 = 3,
                Tarif4 = 4,
                Type = "TestType"
            }; 
            _toyRepository.CreateAsync(toy);
        }
    }
}
