// --------------------------------------------------------------------------------------------------------------------
// <copyright file="fileName.cs" company="Bridgelabz">
//   Copyright © 2018 Company
// </copyright>
// <creator Name="Your name"/>
// --------------------------------------------------------------------------------------------------------------------
namespace CabInvoiceGenerator
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            Ride ride = new Ride(5, 10);
            InvoiceGenerator generator = new InvoiceGenerator();
            generator.CalculateFare(ride);
        }
    }
}
