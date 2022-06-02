using System.Collections.Generic;
using System.Threading.Tasks;

namespace SunBaby.BL.Services.Abstract
{
    public interface IToyService
    {
        Task<IEnumerable<string>> GetCategoriesListAsync();
    }
}
