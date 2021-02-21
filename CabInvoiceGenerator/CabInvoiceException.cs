using System;
using System.Collections.Generic;
using System.Text;

namespace Cab_Invoice_Generator
{
    /// <summary>
    /// custom exception class
    /// </summary>
    /// <seealso cref="System.Exception" />
    class CabInvoiceException : Exception
    {
        public enum ExceptionType
        { 
            INVALID_DISTANCE,
            INVALID_TIME
        }
        /// <summary>
        /// The exception type
        /// </summary>
        public ExceptionType exceptionType;
        /// <summary>
        /// Initializes a new instance of the <see cref="CabInvoiceException"/> class.
        /// </summary>
        /// <param name="exceptionType">Type of the exception.</param>
        /// <param name="message">The message.</param>
        public CabInvoiceException(ExceptionType exceptionType, string message) : base(message)
        {
            this.exceptionType = exceptionType;
        }
    }
}
