using Microsoft.Extensions.Options;
using SunBaby.DA.Configuration;
using SunBaby.DA.Models;
using SunBaby.DA.Repositories.Abstract;

namespace SunBaby.DA.Repositories
{
    public class ToyRepository : BaseRepository<Toy>, IToyRepository
    {
        public ToyRepository(IOptions<MongoSettings> options)
           : base(options)
        {
        }
    }
}
