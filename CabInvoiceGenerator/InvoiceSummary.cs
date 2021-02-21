using System;
using System.Collections.Generic;
using System.Text;

namespace Cab_Invoice_Generator
{
    public class InvoiceSummary
    {
        private readonly int numberOfRides;
        private readonly float totalFare;
        private readonly double averageFare;

        public InvoiceSummary(int numberOfRides, float totalFare)
        {
            this.numberOfRides = numberOfRides;
            this.totalFare = totalFare;
            averageFare = this.totalFare / this.numberOfRides;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (!(obj is InvoiceSummary))
            {
                return false;
            }

            InvoiceSummary invoiceSummary = (InvoiceSummary)obj;
            return numberOfRides == invoiceSummary.numberOfRides && totalFare == invoiceSummary.totalFare && averageFare == invoiceSummary.averageFare;
        }
    }
}
