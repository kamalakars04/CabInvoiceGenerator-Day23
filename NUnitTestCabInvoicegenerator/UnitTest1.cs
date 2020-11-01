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
    }
}