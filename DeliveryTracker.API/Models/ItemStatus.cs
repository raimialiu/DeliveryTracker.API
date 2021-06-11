using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryTracker.API.Models
{
    public class ItemStatus
    {
        public const string DEVELIVERED = "DELIVERED";
        public const string PICKED_UP = "PICKED_UP";
        public const string IN_TRANSIT = "IN_TRANSIT";
        public const string WAREHOUSE = "WAREHOUSE";
    }
}
