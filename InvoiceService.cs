using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoiceGenerator
{
    public class InvoiceService : IInvoiceService
    {
        RideRepository repository;

        /// <summary>
        /// UC 4 Initializes a new instance of the <see cref="InvoiceService"/> class.
        /// </summary>
        public InvoiceService()
        {
            repository = new RideRepository();
        }

        /// <summary>
        /// UC 4 Adds the rides.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="rides">The rides.</param>
        public void AddRides(string userId, List<Ride> rides)
        {
            repository.AddRides(userId, rides);
        }

        /// <summary>
        /// UC 4 Gets all user rides.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        public List<Ride> GetAllUserRides(string userId)
        {
            return repository.GetAllUserRides(userId);
        }

        /// <summary>
        /// UC 4 Gets the total invoice summary.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        public InvoiceSummary TotalInvoiceSummary(string userId)
        {
            List<Ride> totalRides = GetAllUserRides(userId);
            InvoiceSummary normalRides = new InvoiceGenerator(RideType.NORMAL).GetInvoiceSummary(
                                                              totalRides.FindAll(ride => ride.rideType == RideType.NORMAL));
            InvoiceSummary premiumRides = new InvoiceGenerator(RideType.PREMIUM).GetInvoiceSummary(
                                                              totalRides.FindAll(ride => ride.rideType == RideType.PREMIUM));
            return normalRides + premiumRides;
        }
    }
}
