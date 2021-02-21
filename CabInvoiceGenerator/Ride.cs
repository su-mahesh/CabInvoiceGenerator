using System;
using System.Collections.Generic;
using System.Text;

namespace Cab_Invoice_Generator
{
    /// <summary>
    /// ride class to set distance and time
    /// </summary>
    public class Ride
    {
        /// <summary>
        /// variables
        /// </summary>
        public float distance;
        public int time;

        /// <summary>
        /// Initializes a new instance of the <see cref="Ride"/> class.
        /// </summary>
        /// <param name="distance">The distance.</param>
        /// <param name="time">The time.</param>
        public Ride(float distance, int time)
        {
            this.distance = distance;
            this.time = time;
        }
    }
}
