using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTNU_FirstPlugin
{
    public class NTNU_methods
    {
        public static string giveMeText(string s1)
        {
            string gmt = "I give you a text " + s1;
            return gmt;
        }

        public static double giveMeSum(double d1, double d2)
        {
            double r = d1+d2;
            return r;
        }
    }
}
