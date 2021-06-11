using DeliveryTracker.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryTracker.API.Services.Interfaces
{
    public interface IDeliveryTrackingService
    {
        string getItemStatus(string itemId);
        Item getItemInformation(string itemId);
        Task<List<Item>> GetAllItemsBasedOnStatus(string status, int pageIndex, int pageSize);
        Task<bool> createNewItem(Item item);
        Task<List<Item>> AllItems(int pageIndex, int pageStatus);
        List<Item> GetsampleData();
        Task<bool> UpdateItemInfo(string id, Item item);
    }
}
