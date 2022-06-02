using Microsoft.Extensions.Options;
using SunBaby.DA.Configuration;
using SunBaby.DA.Models;
using SunBaby.DA.Repositories.Abstract;

namespace SunBaby.DA.Repositories
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(IOptions<MongoSettings> options)
           : base(options)
        {
        }
    }
}
