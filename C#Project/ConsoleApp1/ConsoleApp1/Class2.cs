using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    /// <summary>
    /// Using <c>CelciusToKelvin</c> class you can convert temperature from celsius to kelvin and vise versa
    /// </summary>
    internal class CelciusToKelvin
    {
        /// <summary>
        /// Converting Celsius to Kelvin
        /// </summary>
        /// <param name="celc">
        /// Indicates temp in Celsius
        /// Type is <see cref="int"/>
        /// </param>
        /// <returns>Returns temp in Kelvin</returns>
        public static int CelToKel(int celc) 
        {
            return celc + 273;
        }

        /// <summary>
        /// Converting Kelvin to Celsius
        /// </summary>
        /// <param name="kel">
        /// Indicates temp in Celvin
        /// Type is <see cref="int"/>
        /// </param>
        /// <returns>Returns temp in Celsius</returns>
        public static int KelToCel(int kel) 
        {
            return kel - 273;
        } 
    }
}
