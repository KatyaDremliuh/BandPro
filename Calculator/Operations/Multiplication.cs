namespace Calculator.Operations
{
    public class Multiplication : Operation
    {
        public override double DoOperation()
        {
            return FirstValue * SecondValue;
        }
    }
}