// --------------------------------------------------------------------------------------------------------------------
// <copyright file="fileName.cs" company="Bridgelabz">
//   Copyright © 2018 Company
// </copyright>
// <creator Name="Your name"/>
// --------------------------------------------------------------------------------------------------------------------
namespace NUnitTestCabInvoicegenerator
{
    using NUnit.Framework;
    using CabInvoiceGenerator;
    using System.Collections.Generic;

    public class Tests
    {
        InvoiceGenerator generator;
        [SetUp]
        public void Setup()
        {
            generator = new InvoiceGenerator(RideType.NORMAL);
        }

        /// <summary>
        /// TC 1 Whens the given distance and time return fare.
        /// </summary>
        [Test]
        public void WhenGivenDistanceAndTimeReturnFare()
        {
            Ride ride = new Ride(RideType.NORMAL, 5, 15);
            double totalFare = generator.CalculateFare(ride);
            double expected = 65;
            Assert.AreEqual(expected, totalFare);
        }

        /// <summary>
        /// TC 2 Whens the given distance and time return fare for multiple rides.
        /// </summary>
        [Test]
        public void WhenGivenDistanceAndTimeReturnFareForMultipleRides()
        {
            // Create list for multiple rides
            List<Ride> rides = new List<Ride>();
            rides.Add(new Ride(RideType.NORMAL, 5, 15));
            rides.Add(new Ride(RideType.NORMAL, 5, 15));

            // Calculate fare for multiple rides
            double totalFare = generator.GetInvoiceSummary(rides).totalFare;
            double expected = 130;
            Assert.AreEqual(expected, totalFare);
        }

        /// <summary>
        /// TC 3 Whens the given multiple rides get invoice summary.
        /// </summary>
        [Test]
        public void WhenGivenMultipleRidesGetInvoiceSummary()
        {
            // Create list for multiple rides
            List<Ride> rides = new List<Ride>();
            rides.Add(new Ride(RideType.NORMAL, 5, 15));
            rides.Add(new Ride(RideType.NORMAL, 5, 15));

            // Get invoice summary for multiple rides
            InvoiceSummary actual = generator.GetInvoiceSummary(rides);
            InvoiceSummary expected = new InvoiceSummary(130,2,65);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// TC 4.1 Given the user identifier get invoice summary.
        /// </summary>
        [Test]
        public void GivenUserIdGetInvoiceSummary()
        {
            // Create list for multiple rides
            List<Ride> rides = new List<Ride>();
            rides.Add(new Ride(RideType.NORMAL, 5, 15));
            rides.Add(new Ride(RideType.NORMAL, 5, 15));

            // Add rides using invoice service
            InvoiceService invoiceService = new InvoiceService();
            invoiceService.AddRides("Ram", rides);

            // Get invoice summary for given user id
            InvoiceSummary actual = invoiceService.TotalInvoiceSummary("Ram");
            InvoiceSummary expected = new InvoiceSummary(130, 2, 65);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// TC 4.2 Given the invalid user identifier get exception.
        /// </summary>
        [Test]
        public void GivenInvalidUserIdGetException()
        {
            InvoiceService invoiceService = new InvoiceService();

            // Get invoice summary for given user id
            var actual = Assert.Throws<InvoiceException>(()=> invoiceService.TotalInvoiceSummary("Ram"));
            Assert.AreEqual(InvoiceException.ExceptionType.INVALID_USER_ID, actual.type);
        }

        
    }
}