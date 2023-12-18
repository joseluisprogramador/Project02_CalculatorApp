using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Project_Main.Class_Operations;

namespace Project_Main
{
    public partial class Form_Calculator : Form
    {

        public Form_Calculator()
        {
            InitializeComponent();
            this.Paint += TextBox_OperationsAddBorderColor ;
            TextBox_Operations.BorderStyle = BorderStyle.None ;

            InitializeNumberButton();
            InitializeOperatorButton();
        }

        private void TextBox_OperationsAddBorderColor(object sender , PaintEventArgs e)
        {
            Color oColor = Color.MediumSeaGreen;
            Pen oPen = new Pen(oColor);

            int x = TextBox_Operations.Left - 1 ;
            int y = TextBox_Operations.Top - 1;
            int width = TextBox_Operations.Width + 1 ;
            int height = TextBox_Operations.Height +  1 ;

            e.Graphics.DrawRectangle(oPen, 
                new Rectangle(x,y,width,height));
        }

        private void TextBox_Operations_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) 
                || char.IsSeparator(e.KeyChar) 
                || char.IsSymbol(e.KeyChar) || char.IsPunctuation(e.KeyChar))
            {
                e.Handled = true ;
            }
        }

        private void InitializeNumberButton()
        {
            string[ ] numbers = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };
            foreach (Control oControl in Controls)
            {
                foreach (string number in numbers)
                {
                    if (oControl is Button oButton && oControl.Text.Equals(number))
                    {
                        oControl.Click += AddNumber ;
                    }
                }
               
            }

        }
        private void AddNumber(object sender , EventArgs e)
        {
            Button oButton = (Button)sender ;

            if (TextBox_Operations.Text.Equals("0"))
            {
                TextBox_Operations.Text = "" ;
            } 

            TextBox_Operations.Text = TextBox_Operations.Text + oButton.Text ;
            
        }

        private void InitializeOperatorButton()
        {
            string[  ] Operators = { "S", "R", "M", "D" };
            foreach (Control oControl in Controls)
            {
                foreach (string Operator in Operators)
                {
                    if (oControl is Button oButton && oControl.Text.Equals(Operator))
                    {
                       oControl.Click += AddOperator ;
                    }
                }

            }

        }

        string Operator ;
        double FirstNumber = 0, SecondNumber = 0  ;

        private void AddOperator(object sender, EventArgs e)
        {
            FirstNumber = double.Parse(TextBox_Operations.Text);
            Button oButton = (Button)sender;
            Operator = oButton.Text;
            TextBox_Operations.Text = "0" ;
        }

        private void Button_Equal_Click(object sender, EventArgs e)
        {
            SecondNumber = double.Parse(TextBox_Operations.Text);

            if (Operator.Equals("S"))
            {
                Class_OperationAdition oAdition = new Class_OperationAdition();
                TextBox_Operations.Text = oAdition.Adition(FirstNumber, SecondNumber).ToString();
            }

            if (Operator.Equals("R"))
            {
                Class_OperationSubtraction oSubtraction = new Class_OperationSubtraction();
                TextBox_Operations.Text = oSubtraction.Subtraction(FirstNumber, SecondNumber).ToString();
            }

            if (Operator.Equals("M"))
            {
                Class_OperationMultiplication oMultiplication = new Class_OperationMultiplication();
                TextBox_Operations.Text = oMultiplication.Multiplication(FirstNumber,SecondNumber).ToString();
            }

            if (Operator.Equals("D"))
            {
                Class_OperationDivision oDivision = new Class_OperationDivision();
                TextBox_Operations.Text = oDivision.Division(FirstNumber, SecondNumber).ToString();
            }

        }



        /*
             SUSCRIBIR UN METODO : "Subscribir un método" en el contexto de eventos en programación
             significa asociar ese método a un evento específico. En términos más sencillos, estás diciendo al programa
             que ejecute ese método cuando ocurra un evento particular.
             */

        /*
        Cuando asignas un manejador de eventos, como en Btn_0.Click += AddNumber;,
        el método AddNumber se convierte en el controlador de eventos para el 
        evento Click del botón Btn_0. Cuando se hace clic en el botón Btn_0, el sistema de eventos de .NET
        invoca el método AddNumber y pasa automáticamente el objeto que generó el evento como 
        argumento al parámetro sender.
        En este caso, como has asociado AddNumber al evento Click de Btn_0, cuando se hace clic en Btn_0,
        sender será una referencia al objeto Btn_0.
        Cuando realizas el casting con la línea Button oButton = (Button)sender;, 
        estás diciendo al compilador que confíe en ti y asumas que el objeto al que apunta sender es
        realmente un objeto de tipo Button. Esto es seguro hacerlo en este contexto porque sabes que
        estás trabajando con botones y que el evento Click proviene de un botón.
        Entonces, después del casting, oButton es una referencia al objeto Btn_0 (o al botón correspondiente, 
        dependiendo de cuál haya disparado el evento). Por lo tanto, puedes acceder a las propiedades
        del botón, como oButton.Text, para obtener el texto del botón que se hizo clic.
         */

    }
}
