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

            Assert.AreEqual(25, fare);
        }
    }
}