using System;
using System.Windows.Forms;

namespace Calculator.Operations
{
    public class Division : Operation
    {
        public override double DoOperation()
        {
            try
            {

                return FirstValue / SecondValue;
            }
            catch (DivideByZeroException exception)
            {
                MessageBox.Show(exception.Message);
            }
            finally
            {
                MessageBox.Show(@"Division by zero is forbidden.");
            }

            return 0;
        }
    }
}