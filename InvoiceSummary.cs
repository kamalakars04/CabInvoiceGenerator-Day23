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

    public class InvoiceSummary
    {
        //Variables
        public double totalFare;
        public int noOfRides;
        public double averageFarePerRide;

        /// <summary>
        /// UC 3 Initializes a new instance of the <see cref="InvoiceSummary"/> class.
        /// </summary>
        /// <param name="totalFare">The total fare.</param>
        /// <param name="noOfRides">The no of rides.</param>
        /// <param name="averageFairPerRide">The average fair per ride.</param>
        public InvoiceSummary(double totalFare, int noOfRides, double averageFairPerRide)
        {
            this.totalFare = totalFare;
            this.noOfRides = noOfRides;
            this.averageFarePerRide = averageFairPerRide;
        }

        /// <summary>
        /// Equalses the specified invoice summary.
        /// </summary>
        /// <param name="invoiceSummary">The invoice summary.</param>
        /// <returns></returns>
        public override bool Equals(Object invoiceSummary)
        {
            if (invoiceSummary == null)
            {
                return false;
            }
            if (!(invoiceSummary is InvoiceSummary))
            {
                return false;
            }
            InvoiceSummary invoice = (InvoiceSummary)invoiceSummary;
            return this.totalFare == invoice.totalFare && this.noOfRides == invoice.noOfRides && this.averageFarePerRide == invoice.averageFarePerRide;
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode()
        {
            return this.totalFare.GetHashCode() ^ this.noOfRides.GetHashCode() ^ this.averageFarePerRide.GetHashCode();
        }
    }
}
