namespace Calculator.Models
{
    /// <summary>
    /// 2 numbers to be added Number1 and Number2
    /// </summary>
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