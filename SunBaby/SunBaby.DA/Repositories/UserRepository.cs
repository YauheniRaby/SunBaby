using Microsoft.Extensions.Options;
using MongoDB.Driver;
using SunBaby.DA.Configuration;
using SunBaby.DA.Models;
using SunBaby.DA.Repositories.Abstract;

namespace SunBaby.DA.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(IOptions<MongoSettings> options)
           : base(options)
        {
        }                
    }
}