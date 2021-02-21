using System;

namespace Cab_Invoice_Generator
{
    public class InvoiceGenerator
    {           
        public RideRepository rideRepository;
        /// <summary>
        /// constatants
        /// </summary>
        private readonly float MINIMUM_COST_PER_KM;
        private readonly float COST_PER_TIME;
        private readonly float MINIMUM_FARE;

        public InvoiceGenerator(float MINIMUM_COST_PER_KM, float COST_PER_TIME, float MINIMUM_FARE)
        {
            rideRepository = new RideRepository();
            this.MINIMUM_COST_PER_KM = MINIMUM_COST_PER_KM;
            this.COST_PER_TIME = COST_PER_TIME;
            this.MINIMUM_FARE = MINIMUM_FARE;
        }

        public float CalculateFare(float distance, float time)
        {
            float totalFare = 0;
            try
            {
                totalFare = distance * MINIMUM_COST_PER_KM + time * COST_PER_TIME;
            }
            catch (CabInvoiceException)
            {
                if (distance <= 0)
                {
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_DISTANCE, "invalid distance");
                }
                if (time < 0)
                {
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_TIME, "invalid time");
                }
            }
            return Math.Max(totalFare, MINIMUM_FARE);
        }

        public InvoiceSummary CalculateFare(Ride[] rides)
        {
            float totalFare = 0;
            try
            {
                foreach (var ride in rides)
                {
                    totalFare += CalculateFare(ride.distance, ride.time);
                }
            }
            catch (CabInvoiceException)
            {
                if (rides == null)
                {
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.NULL_RIDES, "invalid ride");
                }
            }
            return new InvoiceSummary(rides.Length, Math.Max(totalFare, MINIMUM_FARE));
        }
        public InvoiceSummary CalculateFareForUser(string userID, Ride[] rides)
        {
                if (userID == null || userID.Length == 0)
                {
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_USER_ID, "invalid user");
                }
            var invoiceSummary = CalculateFare(rides);
            rideRepository.AddRides(userID, rides);
            return invoiceSummary;
        }

        public Ride[] GetRides(string userID)
        {
            return rideRepository.GetRides(userID);
        }
    }
}