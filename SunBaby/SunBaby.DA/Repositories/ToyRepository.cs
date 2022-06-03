using Microsoft.Extensions.Options;
using MongoDB.Driver;
using SunBaby.DA.Configuration;
using SunBaby.DA.Models;
using SunBaby.DA.Repositories.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SunBaby.DA.Repositories
{
    public class ToyRepository : BaseRepository<Toy>, IToyRepository
    {
        public ToyRepository(IOptions<MongoSettings> options)
           : base(options)
        {
        }

        public async Task<IEnumerable<string>> GetCategoriesListAsync()
        {
            var categoriesList = await GetCollection().DistinctAsync<string>(nameof(Toy.Type), _filterBuilder.Empty);
            return categoriesList.ToEnumerable();
        }

        public async Task<IEnumerable<Toy>> GetToysByAsync(string categoryName)
        {
            var filter = _filterBuilder.Eq(u => u.Type, categoryName);
            var toys = await GetCollection().FindAsync(filter);
            return toys.ToEnumerable();
        }
    }
}