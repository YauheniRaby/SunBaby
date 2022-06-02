using SunBaby.DA.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SunBaby.DA.Repositories.Abstract
{
    public interface IToyRepository : IBaseRepository<Toy>
    {
        Task<IEnumerable<string>> GetCategoriesListAsync();
    }
}
