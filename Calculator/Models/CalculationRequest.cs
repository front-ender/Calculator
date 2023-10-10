namespace Calculator.Models
{
    public class CalculationRequest
    {
        public CalculationRequest(decimal number1, decimal number2)
        {
            Number1 = number1;
            Number2 = number2;
        }

        public decimal Number1 { get; private set; }
        public decimal Number2 { get; private set; }
    }
}