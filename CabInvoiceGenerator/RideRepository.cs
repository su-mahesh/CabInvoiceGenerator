using System.Collections.Generic;

namespace Cab_Invoice_Generator
{
    public class RideRepository
    {
        readonly Dictionary<string, List<Ride>> userRides;

        public RideRepository()
        {
            userRides = new Dictionary<string, List<Ride>>();
        }
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