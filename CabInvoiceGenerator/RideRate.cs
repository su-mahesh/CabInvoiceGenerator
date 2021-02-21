using System;
using System.Collections.Generic;
using System.Text;

namespace Cab_Invoice_Generator
{
    /// <summary>
    /// ride type rates
    /// </summary>
    public class RideRate
    {
        public static float NORMAL_MINIMUM_COST_PER_KM { get; } = 10;
        public static float NORMAL_COST_PER_TIME { get; } = 1;
        public static float NORMAL_MINIMUM_FARE { get; } = 5;

        public static float PREMIUM_MINIMUM_COST_PER_KM { get; } = 15;
        public static float PREMIUM_COST_PER_TIME { get; } = 2;
        public static float PREMIUM_MINIMUM_FARE { get; } = 20;


    }
}
