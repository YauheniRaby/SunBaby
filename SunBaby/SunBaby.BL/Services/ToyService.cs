using SunBaby.BL.Services.Abstract;
using SunBaby.DA.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SunBaby.BL.Services
{
    public class ToyService : IToyService
    {
        private readonly IToyRepository _toyRepository;

        public ToyService(IToyRepository toyRepository)
        {
            _toyRepository = toyRepository;
        }

        public Task<IEnumerable<string>> GetCategoriesListAsync()
        {
            return _toyRepository.GetCategoriesListAsync();
        }
    }
}
