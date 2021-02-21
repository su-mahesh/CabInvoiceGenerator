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
        /// <summary>
        /// Initializes a new instance of the <see cref="InvoiceGenerator"/> class.
        /// </summary>
        /// <param name="rideType">Type of the ride.</param>
        public InvoiceGenerator(RideType rideType)
        {
            rideRepository = new RideRepository();
            if (rideType == RideType.NORMAL)
            {
                MINIMUM_COST_PER_KM = RideRate.NORMAL_MINIMUM_COST_PER_KM;
                COST_PER_TIME = COST_PER_TIME = RideRate.NORMAL_COST_PER_TIME;
                MINIMUM_FARE = MINIMUM_FARE = RideRate.NORMAL_MINIMUM_FARE;
            }
            else
            {
                MINIMUM_COST_PER_KM = RideRate.PREMIUM_MINIMUM_COST_PER_KM;
                COST_PER_TIME = COST_PER_TIME = RideRate.PREMIUM_COST_PER_TIME;
                MINIMUM_FARE = MINIMUM_FARE = RideRate.PREMIUM_MINIMUM_FARE;
            }
        }
        /// <summary>
        /// Calculates the fare.
        /// </summary>
        /// <param name="distance">The distance.</param>
        /// <param name="time">The time.</param>
        /// <returns></returns>
        /// <exception cref="CabInvoiceException">
        /// invalid distance
        /// or
        /// invalid time
        /// </exception>
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
        /// <summary>
        /// Calculates the fare for user.
        /// </summary>
        /// <param name="userID">The user identifier.</param>
        /// <param name="rides">The rides.</param>
        /// <returns></returns>
        /// <exception cref="CabInvoiceException">invalid user</exception>
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
        /// <summary>
        /// Gets the rides.
        /// </summary>
        /// <param name="userID">The user identifier.</param>
        /// <returns></returns>
        public Ride[] GetRides(string userID)
        {
            return rideRepository.GetRides(userID);
        }
    }
}