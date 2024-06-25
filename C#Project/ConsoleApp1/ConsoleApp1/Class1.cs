using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    /// <summary>
    /// Class <c>Power</c> calculates the power of a number
    /// </summary>
    internal class Power
    {
        /// <summary>
        /// Power of a number
        /// </summary>
        /// <param name="num">
        /// Indicates number
        /// Type is <see cref="int"/>
        /// </param>
        /// <param name="power">
        /// Indicates power
        /// Type is <see cref="int"/>
        /// </param>
        /// <returns>Returns the power of a num</returns>
        /// <exception cref="ArgumentException">
        /// if <param name="power"/> is negative
        /// </exception>
        public static int ToPower(int num, int power) 
        {
            if (power == 1)
                return num;
            else if (power == 0)
                return 1;
            else if (power < 0)
                throw new ArgumentException();

            while(power > 1) 
            {
                num *= num;
                power--;
            }

            return num;
        }
    }
}
