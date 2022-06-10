namespace Calculator.Operations
{
    public class Subtraction : Operation
    {
        public override double DoOperation()
        {
            return FirstValue - SecondValue;
        }
    }
}