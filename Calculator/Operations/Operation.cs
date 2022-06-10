namespace Calculator.Operations
{
    public abstract class Operation
    {
        public double FirstValue { get; set; }
        public double SecondValue { get; set; }

        public abstract double DoOperation();
    }
}