using DeliveryTracker.API.Models;
using DeliveryTracker.API.Models.DTOs.ApiRequest;
using DeliveryTracker.API.Models.DTOs.ApiResponse;
using DeliveryTracker.API.Services;
using DeliveryTracker.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryTracker.API.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class DeliveryController : ControllerBase
    {
        readonly IDeliveryTrackingService _service;
        public DeliveryController(IDeliveryTrackingService service)
        {
            _service = service;
        }

        [Route("AllDeliveredItems")]
        [HttpGet]
        public async Task<IActionResult> AllDeliveredItemAsync([FromQuery] QueryDTO query)
        {
            var allItems = await _service.GetAllItemsBasedOnStatus(ItemStatus.DEVELIVERED, query.pageIndex, query.pageSize);
            return Ok(GenericResponse<List<Item>>.Success(allItems));
        }


        [Route("AllPickedUpItems")]
        [HttpGet]
        public async Task<IActionResult> AllPickedUpItemsAsync([FromQuery] QueryDTO query)
        {
            var allItems = await _service.GetAllItemsBasedOnStatus(ItemStatus.PICKED_UP, query.pageIndex, query.pageSize);
            return Ok(GenericResponse<List<Item>>.Success(allItems));
        }

        [Route("AllItems")]
        [HttpGet]
        public async Task<IActionResult> AllItems([FromQuery] QueryDTO query)
        {
            var allItems = await _service.AllItems(query.pageIndex, query.pageSize);
            return Ok(GenericResponse<List<Item>>.Success(allItems));
        }

        [Route("{status}")]
        [HttpGet]
        public async Task<IActionResult> AllItemByStatusAsync(string status, [FromQuery] QueryDTO query)
        {
            var allItems = await _service.GetAllItemsBasedOnStatus(status, query.pageIndex, query.pageSize);
            return Ok(GenericResponse<List<Item>>.Success(allItems));
        }

        [Route("PackageItemForDelivery")]
        [HttpGet]
        public async Task<IActionResult> PackageItemForDeliveryAsync([FromBody] Item item)
        {
            var getItemStatus = _service.getItemStatus(item.itemId);

            if(getItemStatus == ItemStatus.DEVELIVERED)
            {
                return BadRequest(GenericResponse<string>.Failed("item has been delievered before"));
            }

            if(getItemStatus == ItemStatus.PICKED_UP)
            {
                return BadRequest(GenericResponse<string>.Failed("item has been picked up"));
            }

            var response = await _service.createNewItem(item);

            if(response)
            {
                return Ok(GenericResponse<string>.Success("item successfully posted for delivery", null));
            }

            return BadRequest(GenericResponse<string>.Failed("failed to process item for delivery"));
        }

        [Route("trackItemStatus/{itemId}")]
        [HttpGet]
        public async Task<IActionResult> TrackItemStatusAsync(string itemId)
        {
            var response =  _service.getItemInformation(itemId);

            return Ok(GenericResponse<string>.Success(response.status));
        }
        [Route("trackItem/{itemId}")]
        [HttpGet]
        public async Task<IActionResult> TrackItemAsync(string itemId)
        {
            var response =  _service.getItemInformation(itemId);

            return Ok(GenericResponse<Item>.Success(response));
        }
    }
}
