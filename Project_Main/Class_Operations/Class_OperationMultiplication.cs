using Project_Main.Interface_Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Main.Class_Operations
{
    public class Class_OperationMultiplication : Interface_BasicOperations
    {
        public double Operations(double FirstNumber, double SecondNumber)
        {
            return FirstNumber * SecondNumber ;
        }  
    }
}
