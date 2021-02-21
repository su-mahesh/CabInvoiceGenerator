using Cab_Invoice_Generator;
using NUnit.Framework;

namespace CabInvoiceGeneratorNUnitTestProject
{
    public class Tests
    {
        InvoiceGenerator invoiceGenerator;
        /// <summary>
        /// Givens the distance time should return total fare.
        /// </summary>
        [Test]
        public void GivenDistanceTime_ShouldReturnTotalFare()
        {
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            float distance = 2;
            float time = 5;
            float fare = invoiceGenerator.CalculateFare(distance, time);
            float expectedFare = 25;
            Assert.AreEqual(expectedFare, fare);
        }
        /// <summary>
        /// Givens the multiple rides should return total fare.
        /// </summary>
        [Test]
        public void GivenMultipleRides_ShouldReturnTotalFare()
        {
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            Ride[] rides = { new Ride(2, 5), new Ride(2, 1) };
            InvoiceSummary result = invoiceGenerator.CalculateFare(rides);
            InvoiceSummary expectedInvoiceSummary = new InvoiceSummary(2, 46);
            Assert.AreEqual(expectedInvoiceSummary, result);
        }
        /// <summary>
        /// Givens the multiple rides should return invoice summary.
        /// </summary>
        [Test]
        public void GivenMultipleRides_ShouldReturnInvoiceSummary()
        {
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            Ride[] rides = { new Ride(2, 5), new Ride(2, 1) };
            InvoiceSummary result = invoiceGenerator.CalculateFare(rides);
            InvoiceSummary expectedInvoiceSummary = new InvoiceSummary(2, 46);
            Assert.AreEqual(expectedInvoiceSummary, result);
        }

        [Test]
        public void GivenUserID_ShouldReturnRideRepository()
        {
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            Ride[] rides = { new Ride(2, 5), new Ride(2, 1) };
            string userID = new User().CreateNewUser();
            InvoiceSummary result = invoiceGenerator.CalculateFareForUser(userID, rides);
            InvoiceSummary expectedInvoiceSummary = new InvoiceSummary(2, 46);
            Ride[] expectedRides = invoiceGenerator.GetRides(userID);
            Assert.AreEqual(expectedInvoiceSummary, result);
            Assert.AreEqual(expectedRides, rides);
        }
        /// <summary>
        /// Givens the premium rides should return total fare.
        /// </summary>
        [Test]
        public void GivenPremiumRides_ShouldReturnTotalFare()
        {
            invoiceGenerator = new InvoiceGenerator(RideType.PREMIUM);
            Ride[] rides = { new Ride(2, 5), new Ride(2, 1) };
            InvoiceSummary result = invoiceGenerator.CalculateFare(rides);
            InvoiceSummary expectedInvoiceSummary = new InvoiceSummary(2, 72);
            Assert.AreEqual(expectedInvoiceSummary, result);
        }
    }
}