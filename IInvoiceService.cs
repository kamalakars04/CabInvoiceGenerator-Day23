using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoiceGenerator
{
    interface IInvoiceService
    {
        void AddRides(string userId, List<Ride> rides);
        List<Ride> GetAllUserRides(string userId);
    }
}
