namespace Calculator.Operations
{
    public class Addition : Operation
    {
        public override double DoOperation()
        {
            return FirstValue + SecondValue;
        }
    }
}