using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryTracker.API.Models
{
    public class Item
    {
        public string itemId { get; set; }
        public string itemName { get; set; }
        public double price { get; set; }
        public string description { get; set; }
        public string status { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
