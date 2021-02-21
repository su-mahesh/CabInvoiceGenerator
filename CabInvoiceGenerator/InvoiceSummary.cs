using System;
using System.Collections.Generic;
using System.Text;

namespace Cab_Invoice_Generator
{
    /// <summary>
    /// class include invoice fields
    /// </summary>
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
        /// <summary>
        /// Determines whether the specified <see cref="System.Object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
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
