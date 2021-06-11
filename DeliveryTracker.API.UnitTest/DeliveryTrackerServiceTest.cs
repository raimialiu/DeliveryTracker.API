using System;
using System.Threading.Tasks;
using DeliveryTracker.API.Models;
using FluentAssertions;
using Xunit;

namespace DeliveryTracker.API.UnitTest
{
    public class DeliveryTrackerServiceTest : BaseTestClass
    {
        [Fact]
        public async Task ShouldNotChangeStatusWHenAnItemIsDeliveredOrPickedUp()
        {
            // arrange
            var firstItemFromAllItem = (await _service.GetAllItemsBasedOnStatus(ItemStatus.DEVELIVERED,1, 1))[0];
            
            //act
            if (firstItemFromAllItem == null)
            {
                firstItemFromAllItem.Should().BeNull();
                return;
            }
            var updateResult = await _service.UpdateItemInfo(firstItemFromAllItem.itemId, firstItemFromAllItem);

            updateResult.Should().BeFalse();
        }
        [Fact]
        public async Task ShouldBeToPackgeAnItemForDelivery()
        {
            // arrange
            var item = new Item()
            {
                DateCreated = DateTime.Now,
                price = 23409,
                itemName = "simple Item",
                description = "This is simple tiem",
                status = ItemStatus.IN_TRANSIT
                    
                
            };
            //act
            var result = await _service.createNewItem(item);
            //assert

            result.Should().BeTrue();
        }
        [Fact]
        public async Task ShouldReturnNullOrInvalidWhenGivenRandomID()
        {
            // arrange
            var itemId = Guid.NewGuid().ToString();
            //act
            var itemInfo = _service.getItemInformation(itemId);
            //asert
            itemInfo.Should().BeNull();
        }
    }
}