using Project_Main.Interface_Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_Main.Class_Operations
{
    public class Class_OperationDivision : Interface_BasicOperations
    {
        public double Operations(double FirstNumber, double SecondNumber)
        {
            if (SecondNumber != 0)
            {
                return FirstNumber / SecondNumber;
            }
            else
            {           
                return 0 ;
            }
          
        }  
    }
}
