// --------------------------------------------------------------------------------------------------------------------
// <copyright file="fileName.cs" company="Bridgelabz">
//   Copyright © 2018 Company
// </copyright>
// <creator Name="Your name"/>
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

            // Calculate fare for multiple rides
            InvoiceGenerator generator = new InvoiceGenerator();
            generator.CalculateFare(rides);
        }
    }
}
