using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookingSystem.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingSystem.Model;

namespace BookingSystem.Helpers.Test
{
    [TestClass()]
    public class BookingAvailabilityCheckerTests
    {
        [TestMethod()]
        public void CheckTest_MissingBookingToCompare_ExpectedReturnFalse()
        {
            BookingAvailabilityChecker checker = new();
            Resource resource = new() { Id = 1, Quantity = 10, Name = "resource1" };
            List<Booking> bookings = new()
            { 
                new Booking{Id = 1, DateFrom = DateTime.Parse("2021-12-24T13:31:14.056Z"), DateTo = DateTime.Parse("2021-12-24T13:31:14.056Z"), BookedQuantity = 2, ResourceId = 1},
                new Booking{Id = 2, DateFrom = DateTime.Parse("2021-12-24T13:31:14.056Z"), DateTo = DateTime.Parse("2021-12-24T13:31:14.056Z"), BookedQuantity = 2, ResourceId = 1},
                new Booking{Id = 3, DateFrom = DateTime.Parse("2021-12-24T13:31:14.056Z"), DateTo = DateTime.Parse("2021-12-24T13:31:14.056Z"), BookedQuantity = 2, ResourceId = 1}
            };


            var actual = checker.Check(bookings, resource, null);


            Assert.AreEqual(false, actual);
        }
        [TestMethod()]
        public void CheckTest_MissingBookingList_ExpectedReturnFalse()
        {
            BookingAvailabilityChecker checker = new();
            Resource resource = new() { Id = 1, Quantity = 2, Name = "resource1" };
            Booking booking = new() { Id = 1, DateFrom = DateTime.Parse("2021-12-24T13:31:14.056Z"), DateTo = DateTime.Parse("2021-12-24T13:31:14.056Z"), BookedQuantity = 2, ResourceId = 1 };


            var actual = checker.Check(null, resource, booking);


            Assert.AreEqual(false, actual);
        }
        [TestMethod()]
        public void CheckTest_MissingResource_ExpectedReturnFalse()
        {
            BookingAvailabilityChecker checker = new();
            List<Booking> bookings = new()
            {
                new Booking{Id = 1, DateFrom = DateTime.Parse("2021-12-24T13:31:14.056Z"), DateTo = DateTime.Parse("2021-12-24T13:31:14.056Z"), BookedQuantity = 2, ResourceId = 1},
                new Booking{Id = 2, DateFrom = DateTime.Parse("2021-12-24T13:31:14.056Z"), DateTo = DateTime.Parse("2021-12-24T13:31:14.056Z"), BookedQuantity = 2, ResourceId = 1},
                new Booking{Id = 3, DateFrom = DateTime.Parse("2021-12-24T13:31:14.056Z"), DateTo = DateTime.Parse("2021-12-24T13:31:14.056Z"), BookedQuantity = 2, ResourceId = 1}
            };
            Booking booking = new() { Id = 4, DateFrom = DateTime.Parse("2021-12-24T13:31:14.056Z"), DateTo = DateTime.Parse("2021-12-24T13:31:14.056Z"), BookedQuantity = 2, ResourceId = 1 };


            var actual = checker.Check(bookings, null, booking);


            Assert.AreEqual(false, actual);
        }
        [TestMethod()]
        public void CheckTest_EmptyBookingList_ExpectedReturnTrue()
        {
            BookingAvailabilityChecker checker = new();
            List<Booking> bookings = new() { };
            Booking booking = new() { Id = 4, DateFrom = DateTime.Parse("2021-12-24T13:31:14.056Z"), DateTo = DateTime.Parse("2021-12-24T13:31:14.056Z"), BookedQuantity = 2, ResourceId = 1 };
            Resource resource = new() { Id = 1, Quantity = 10, Name = "resource1" };

            var actual = checker.Check(bookings, resource, booking);

            Assert.AreEqual(true, actual);
        }

        [TestMethod()]
        public void CheckTest_BookedQuantityUnavailable_ExpectedReturnFalse()
        {
            BookingAvailabilityChecker checker = new();
            List<Booking> bookings = new()
            {
                new Booking { Id = 1, DateFrom = DateTime.Parse("2021-12-24T13:31:14.056Z"), DateTo = DateTime.Parse("2021-12-24T13:31:14.056Z"), BookedQuantity = 2, ResourceId = 1 },
                new Booking { Id = 2, DateFrom = DateTime.Parse("2021-12-24T13:31:14.056Z"), DateTo = DateTime.Parse("2021-12-24T13:31:14.056Z"), BookedQuantity = 2, ResourceId = 1 },
                new Booking { Id = 3, DateFrom = DateTime.Parse("2021-12-24T13:31:14.056Z"), DateTo = DateTime.Parse("2021-12-24T13:31:14.056Z"), BookedQuantity = 2, ResourceId = 1 }
            };
            Booking booking = new() { Id = 4, DateFrom = DateTime.Parse("2021-12-24T13:31:14.056Z"), DateTo = DateTime.Parse("2021-12-24T13:31:14.056Z"), BookedQuantity = 2, ResourceId = 1 };
            Resource resource = new() { Id = 1, Quantity = 6, Name = "resource1" };

            var actual = checker.Check(bookings, resource, booking);

            Assert.AreEqual(false, actual) ;
        }

        [TestMethod()]
        public void CheckTest_BookedQuantityAvailable_ExpectedReturnTrue()
        {
            BookingAvailabilityChecker checker = new();
            List<Booking> bookings = new()
            {
                new Booking { Id = 1, DateFrom = DateTime.Parse("2021-12-24T13:31:14.056Z"), DateTo = DateTime.Parse("2021-12-24T13:31:14.056Z"), BookedQuantity = 2, ResourceId = 1 },
                new Booking { Id = 2, DateFrom = DateTime.Parse("2021-12-24T13:31:14.056Z"), DateTo = DateTime.Parse("2021-12-24T13:31:14.056Z"), BookedQuantity = 2, ResourceId = 1 },
                new Booking { Id = 3, DateFrom = DateTime.Parse("2021-12-24T13:31:14.056Z"), DateTo = DateTime.Parse("2021-12-24T13:31:14.056Z"), BookedQuantity = 2, ResourceId = 1 }
            };
            Booking booking = new() { Id = 4, DateFrom = DateTime.Parse("2021-12-24T13:31:14.056Z"), DateTo = DateTime.Parse("2021-12-24T13:31:14.056Z"), BookedQuantity = 2, ResourceId = 1 };
            Resource resource = new() { Id = 1, Quantity = 10, Name = "resource1" };

            var actual = checker.Check(bookings, resource, booking);

            Assert.AreEqual(true, actual);
        }

        [TestMethod()]
        public void CheckTest_BookingsDoesNotOverlap_ExpectedReturnTrue()
        {
            BookingAvailabilityChecker checker = new();
            List<Booking> bookings = new()
            {
                new Booking { Id = 1, DateFrom = DateTime.Parse("2021-12-24T13:31:14.056Z"), DateTo = DateTime.Parse("2021-12-25T13:31:14.056Z"), BookedQuantity = 2, ResourceId = 1 },
                new Booking { Id = 2, DateFrom = DateTime.Parse("2021-12-24T13:31:14.056Z"), DateTo = DateTime.Parse("2021-12-25T13:31:14.056Z"), BookedQuantity = 2, ResourceId = 1 },
                new Booking { Id = 3, DateFrom = DateTime.Parse("2021-12-24T13:31:14.056Z"), DateTo = DateTime.Parse("2021-12-25T13:31:14.056Z"), BookedQuantity = 2, ResourceId = 1 }
            };
            Booking booking = new() { Id = 4, DateFrom = DateTime.Parse("2021-12-26T13:31:14.056Z"), DateTo = DateTime.Parse("2021-12-29T13:31:14.056Z"), BookedQuantity = 6, ResourceId = 1 };
            Resource resource = new() { Id = 1, Quantity = 6, Name = "resource1" };

            var actual = checker.Check(bookings, resource, booking);

            Assert.AreEqual(true, actual);
        }
    }
}