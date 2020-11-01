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

    class Program
    {
        static void Main(string[] args)
        {
            // Create list for multiple rides
            List<Ride> rides = new List<Ride>();
            rides.Add(new Ride(5, 10));
            rides.Add(new Ride(5, 10));
            InvoiceService invoiceService = new InvoiceService();
            invoiceService.AddRides("Ram", rides);

            // Calculate fare for multiple rides
            Console.WriteLine(invoiceService.GetInvoiceSummary("Ram").noOfRides); 
        }
    }
}
