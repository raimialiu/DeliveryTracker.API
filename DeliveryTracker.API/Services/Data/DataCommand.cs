using DeliveryTracker.API.Models;
using DeliveryTracker.API.Services.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryTracker.API.Services.Data
{
    public class DataCommand : IDataCommand
    {
        private readonly List<Item> items;
        readonly ILogger logger;

        public DataCommand(List<Item> items, ILogger logger)
        {
            this.items = items;
            this.logger = logger;
        }

        public async Task<bool> Create(Item data)
        {
            try
            {
                items.Add(data);
                return true;
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message, null);
                return false;
            }
        }

        public async Task<bool> Remove(string id)
        {
            try
            {
                Item itemToRemove = new Item { itemId = id };
                return items.Remove(itemToRemove);
                //return true;
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message, null);
                return false;
            }
        }

        public async Task<bool> update(string id, Item data)
        {
            try
            {
                Item itemToRemove = new Item { itemId = id };

                int index = items.IndexOf(itemToRemove);

                items[index] = data;

                return true;

            }
            catch (Exception ex)
            {

                logger.LogError(ex.Message, null);
                return false;
            }
        }
    }
}
