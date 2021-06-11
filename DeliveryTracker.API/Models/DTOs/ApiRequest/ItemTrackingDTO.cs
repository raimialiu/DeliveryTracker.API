using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryTracker.API.Models.DTOs.ApiRequest
{
    public class ItemTrackingDTO
    {
        public string ItemId { get; set; }
       
    }

    public class QueryDTO
    {
        public int pageIndex { get; set; }
        public int pageSize { get; set; }
    }

    public class ItemRequestDTO
    { 
        public string itemId { get; set; }
        public string itemName { get; set; }
        public double price { get; set; }
        public string description { get; set; }
    }
   
}
