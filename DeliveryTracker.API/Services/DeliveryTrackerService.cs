using DeliveryTracker.API.Models;
using DeliveryTracker.API.Services.Data;
using DeliveryTracker.API.Services.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryTracker.API.Services
{
    public class DeliveryTrackerService : IDeliveryTrackingService
    {
        private List<Item> store;
        readonly IDataQuery _query;
        readonly IDataCommand _command;
        public DeliveryTrackerService(List<Item> store, ILogger logger)
        {
            // dateQuery
            this.store = store;
            _query = new DataQuery(store);
            _command = new DataCommand(store, logger);
            Samples(100).ConfigureAwait(false);
        }
        public async Task<bool> createNewItem(Item item)
        {
            return await _command.Create(item);
        }

        async Task Samples(int n=10)
        {
            for(int i =0;i<n;i++)
            {
                if(i % 2 == 0)
                {
                    await createNewItem(new Item()
                    {
                        status = ItemStatus.IN_TRANSIT,
                        DateCreated = DateTime.Now,
                        description = "item_" + i,
                        itemId = Guid.NewGuid().ToString(),
                        itemName= "Item_"+i,
                        price = (i * store.Count)+20
                    }) ;
                }

                if(i % 2 ==1)
                {
                    await createNewItem(new Item()
                    {
                        status = ItemStatus.PICKED_UP,
                        DateCreated = DateTime.Now,
                        description = "item_" + i,
                        itemId = Guid.NewGuid().ToString(),
                        itemName = "Item_" + i,
                        price = (i * store.Count) + 20
                    });
                }
                if (i % 3 == 1)
                {
                    await createNewItem(new Item()
                    {
                        status = ItemStatus.WAREHOUSE,
                        DateCreated = DateTime.Now,
                        description = "item_" + i,
                        itemId = Guid.NewGuid().ToString(),
                        itemName = "Item_" + i,
                        price = (i * store.Count) + 20
                    });
                }

                if (i % 3 == 0)
                {
                    await createNewItem(new Item()
                    {
                        status = ItemStatus.DEVELIVERED,
                        DateCreated = DateTime.Now,
                        description = "item_" + i,
                        itemId = Guid.NewGuid().ToString(),
                        itemName = "Item_" + i,
                        price = (i * store.Count) + 20
                    });
                }
            }
        }

        public async Task<List<Item>> GetAllItemsBasedOnStatus(string status, int pageIndex, int pageSize)
        {
            return (List<Item>)await _query.QueryAsync(x => x.status == status, pageIndex, pageSize);
        }

        public Item getItemInformation(string itemId)
        {
            return _query.GetByIdAsync(itemId).Result;
        }

        public string getItemStatus(string itemId)
        {
            return _query.GetByIdAsync(itemId).Result.status;
        }
    }
}
