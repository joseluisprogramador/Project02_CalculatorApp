using Project_Main.Interface_Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Main.Class_Operations
{
    public class Class_RaizerExponent : Interface_BasicOperations
    {
        public double Operations(double FirstNumber, double SecondNumber)
        {
            if (SecondNumber is 0)
            {
                return Math.Pow(FirstNumber, 2);
            }

            return Math.Pow(FirstNumber, SecondNumber);
        }
    }
}
