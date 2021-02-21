using System.Collections.Generic;

namespace Cab_Invoice_Generator
{
    /// <summary>
    /// RideRepository contains user rides
    /// </summary>
    public class RideRepository
    {
        /// <summary>
        /// The user rides list
        /// </summary>
        readonly Dictionary<string, List<Ride>> userRides;
        /// <summary>
        /// Initializes a new instance of the <see cref="RideRepository"/> class.
        /// </summary>
        public RideRepository()
        {
            userRides = new Dictionary<string, List<Ride>>();
        }
        /// <summary>
        /// Adds the rides.
        /// </summary>
        /// <param name="userID">The user identifier.</param>
        /// <param name="rides">The rides.</param>
        /// <exception cref="CabInvoiceException">rides are null</exception>
        public void AddRides(string userID, Ride[] rides)
        {
            try
            {
                if (!userRides.ContainsKey(userID))
                {
                    List<Ride> list = new List<Ride>();
                    list.AddRange(rides);
                    userRides.Add(userID, list);
                }
                else
                {
                    userRides[userID].AddRange(rides);
                }
            }
            catch (CabInvoiceException)
            {
                throw new CabInvoiceException(CabInvoiceException.ExceptionType.NULL_RIDES, "rides are null");
            }
        }
        /// <summary>
        /// Gets the rides.
        /// </summary>
        /// <param name="userID">The user identifier.</param>
        /// <returns></returns>
        /// <exception cref="CabInvoiceException">invalid user id</exception>
        public Ride[] GetRides(string userID)
        {
            try
            {
                return userRides[userID].ToArray();
            }
            catch (System.Exception)
            {
                throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_USER_ID, "invalid user id");
            }
        }
    }
}