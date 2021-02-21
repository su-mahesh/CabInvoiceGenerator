using Cab_Invoice_Generator;
using NUnit.Framework;

namespace CabInvoiceGeneratorNUnitTestProject
{
    public class Tests
    {
        InvoiceGenerator invoiceGenerator;

        [Test]
        public void GivenDistanceTime_ShouldReturnTotalFare()
        {
            invoiceGenerator = new InvoiceGenerator(10, 1, 5);
            float distance = 2;
            float time = 5;
            float fare = invoiceGenerator.CalculateFare(distance, time);
            float expectedFare = 25;
            Assert.AreEqual(expectedFare, fare);
        }
        [Test]
        public void GivenMultipleRides_ShouldReturnTotalFare()
        {
            invoiceGenerator = new InvoiceGenerator(10, 1, 5);
            Ride[] rides = { new Ride(2, 5), new Ride(2, 1) };
            InvoiceSummary result = invoiceGenerator.CalculateFare(rides);
            InvoiceSummary expectedInvoiceSummary = new InvoiceSummary(2, 46);

            Assert.AreEqual(expectedInvoiceSummary, result);
        }
    }
}