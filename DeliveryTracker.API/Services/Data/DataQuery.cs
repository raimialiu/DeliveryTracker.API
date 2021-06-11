using DeliveryTracker.API.Models;
using DeliveryTracker.API.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryTracker.API.Services.Data
{
    public class DataQuery : IDataQuery
    {
        private readonly List<Item> items;

        public DataQuery(List<Item> items)
        {
            this.items = items;
        }
        public async Task<List<Item>> GetAllAsync(int pageIndex, int pageSize)
        {
            return items
                        .Skip((pageIndex - 1) * pageSize)
                        .Take(pageSize).ToList();
        }

        public async Task<Item> GetByIdAsync(string id)
        {
            Func<Item, bool> predicate = x => { return x.itemId == id; };
            return items.FirstOrDefault(predicate);
        }

        public async Task<List<Item>> QueryAsync(Func<Item, bool> predicate, int pageIndesx, int pageSize)
        {
            return items.Where(predicate)
                    .Skip((pageIndesx - 1) * pageSize)
                    .Take(pageSize)
                    .ToList();
        }
    }
}
