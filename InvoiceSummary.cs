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

        /// <summary>
        /// Implements the operator +.
        /// </summary>
        /// <param name="invoiceOne">The invoice one.</param>
        /// <param name="invoiceTwo">The invoice two.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static InvoiceSummary operator+(InvoiceSummary invoiceOne, InvoiceSummary invoiceTwo)
        {
            // If both the entries are null
            if (invoiceOne == null && invoiceTwo == null)
                throw new InvoiceException(InvoiceException.ExceptionType.NULL_RIDES, "Rides are 0");

            //  if any one entry is null
            if (invoiceOne == null)
                return invoiceTwo;
            if (invoiceTwo == null)
                return invoiceOne;

            // If no entry is null
            double totalFare = invoiceOne.totalFare + invoiceTwo.totalFare;
            int noOfRides = invoiceOne.noOfRides + invoiceTwo.noOfRides;
            double average = totalFare / noOfRides;
            return new InvoiceSummary(totalFare, noOfRides, average);
        }
    }
}
