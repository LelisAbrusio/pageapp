using System.Collections.Generic;
using System.Threading.Tasks;

namespace PageApplication.Services
{
    public interface IItemService
    {
        Task<List<string>> GetItemsAsync();
        List<string> GetItems();
    }
}
