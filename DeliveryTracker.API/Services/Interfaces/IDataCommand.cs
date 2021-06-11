using DeliveryTracker.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryTracker.API.Services.Interfaces
{
    public interface IDataCommand
    {
        Task<bool> Create(Item data);
        Task<bool> update(string id, Item data);
        Task<bool> Remove(string id);
    }
}
