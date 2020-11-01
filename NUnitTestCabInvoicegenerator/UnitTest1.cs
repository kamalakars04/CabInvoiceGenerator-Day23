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
            generator = new InvoiceGenerator();
        }

        /// <summary>
        /// TC 1 Whens the given distance and time return fare.
        /// </summary>
        [Test]
        public void WhenGivenDistanceAndTimeReturnFare()
        {
            Ride ride = new Ride(5, 15);
            double totalFare = generator.CalculateFare(ride);
            double expected = 65;
            Assert.AreEqual(expected, totalFare);
        }

        /// <summary>
        /// Whens the given distance and time return fare for multiple rides.
        /// </summary>
        [Test]
        public void WhenGivenDistanceAndTimeReturnFareForMultipleRides()
        {
            // Create list for multiple rides
            List<Ride> rides = new List<Ride>();
            rides.Add(new Ride(5, 15));
            rides.Add(new Ride(5, 15));

            // Calculate fare for multiple rides
            double totalFare = generator.CalculateFare(rides);
            double expected = 130;
            Assert.AreEqual(expected, totalFare);
        }
    }
}