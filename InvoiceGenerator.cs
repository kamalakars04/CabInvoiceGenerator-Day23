// --------------------------------------------------------------------------------------------------------------------
// <copyright file="fileName.cs" company="Bridgelabz">
//   Copyright © 2018 Company
// </copyright>
// <creator Name="Your name"/>
// --------------------------------------------------------------------------------------------------------------------
namespace CabInvoiceGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class InvoiceGenerator
    {
        private readonly int COST_PER_KM;
        private readonly int COST_PER_MIN;
        private readonly int MIN_FARE;
        double rideFare;

        public InvoiceGenerator()
        {
            COST_PER_KM = 10;
            COST_PER_MIN = 1;
            MIN_FARE = 5;
        }

        /// <summary>
        /// Calculates the fare.
        /// </summary>
        /// <param name="ride">The ride.</param>
        /// <returns></returns>
        /// <exception cref="CabInvoiceGenerator.InvoiceException">
        /// Distance cannot be non positive
        /// or
        /// Time cannot be non positive
        /// </exception>
        public double CalculateFare(Ride ride)
        {
            // Throw exceptions for wrong values
            if (ride.distance <= 0)
            {
                throw new InvoiceException(InvoiceException.ExceptionType.INVALID_DISTANCE, "Distance cannot be non positive");
            }
            else if (ride.time <= 0)
            {
                throw new InvoiceException(InvoiceException.ExceptionType.INVALID_TIME, "Time cannot be non positive");
            }

            // Calculate total fare and return it
            rideFare = ride.distance * COST_PER_KM + ride.time * COST_PER_MIN;
            return Math.Max(MIN_FARE, rideFare);
        }
    }
}
