using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoiceGenerator
{
    public interface IInvoiceService
    {
        void AddRides(string userId, List<Ride> rides);
        List<Ride> GetAllUserRides(string userId);
        InvoiceSummary TotalInvoiceSummary(string userId);
    }
}
