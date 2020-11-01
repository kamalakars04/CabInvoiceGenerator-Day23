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
        /// UC 4 Gets the invoice summary.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        public InvoiceSummary GetInvoiceSummary(string userId)
        {
            return new InvoiceGenerator().GetInvoiceSummary(GetAllUserRides(userId));
        }
    }
}
