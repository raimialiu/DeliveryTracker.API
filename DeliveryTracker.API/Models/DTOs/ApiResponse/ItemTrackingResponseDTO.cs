using DeliveryTracker.API.Models.DTOs.ApiRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryTracker.API.Models.DTOs.ApiResponse
{
    public class ItemTrackingResponseDTO
    {
        public Item item { get; set; }

        public string status { get; set; }
    }
}
