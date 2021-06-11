using System.Collections.Generic;
using DeliveryTracker.API.Models;
using DeliveryTracker.API.Services;
using DeliveryTracker.API.Services.Data;
using DeliveryTracker.API.Services.Interfaces;
using NSubstitute;

namespace DeliveryTracker.API.UnitTest
{
    public class BaseTestClass
    {
        protected readonly IDeliveryTrackingService _service;
        protected readonly IDataQuery _query;
        protected List<Item> sampleData;
        public BaseTestClass()
        {
            _service = Substitute.For<DeliveryTrackerService>(new List<Item>(), null);
            _query = Substitute.For<DataQuery>(new List<Item>());
            sampleData = _service.GetsampleData();
        }
    }
}