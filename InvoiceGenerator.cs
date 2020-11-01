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
        double averageFare;

        /// <summary>
        /// Initializes a new instance of the <see cref="InvoiceGenerator"/> class.
        /// </summary>
        /// <param name="rideType">Type of the ride.</param>
        public InvoiceGenerator(RideType rideType)
        {
           switch(rideType)
            {
                case RideType.NORMAL:
                    this.COST_PER_KM = 10;
                    this.COST_PER_MIN = 1;
                    this.MIN_FARE = 5;
                    break;

                case RideType.PREMIUM:
                    this.COST_PER_KM = 15;
                    this.COST_PER_MIN = 2;
                    this.MIN_FARE = 20;
                    break;
           }
        }

        /// <summary>
        /// UC 1 Calculates the fare.
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
            try
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
            }
            catch(NullReferenceException)
            {
                throw new InvoiceException(InvoiceException.ExceptionType.NULL_RIDES, "Null ride not accepted");
            }

            // Calculate total fare and return it
            rideFare = ride.distance * COST_PER_KM + ride.time * COST_PER_MIN;
            return Math.Max(MIN_FARE, rideFare);
        }

        /// <summary>
        /// UC 2, UC3 Calculates the fare.
        /// UC 4 Refactored for UC4
        /// </summary>
        /// <param name="rides">The rides.</param>
        /// <returns></returns>
        public InvoiceSummary GetInvoiceSummary(List<Ride> rides)
        {
            if (rides.Count == 0)
                return default;

            // Calculate total ride fare
            foreach(Ride ride in rides)
            {
                // Calculate total fare and return it
                rideFare += CalculateFare(ride);
            }
            rideFare = Math.Max(MIN_FARE, rideFare);
            averageFare = rideFare / rides.Count;

            // Return in enhanced Summary format
            return new InvoiceSummary(rideFare, rides.Count, averageFare);
        }
    }
}
