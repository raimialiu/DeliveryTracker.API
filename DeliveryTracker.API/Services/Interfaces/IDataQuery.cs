using DeliveryTracker.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryTracker.API.Services.Interfaces
{
    public interface IDataQuery
    {
        Task<List<Item>> GetAllAsync(int pageIndex, int pageSize);
        Task<Item> GetByIdAsync(string id);
        Task<IEnumerable<Item>> QueryAsync(Func<Item, bool> predicate, int pageIndesx, int pageSize);
    }
}
