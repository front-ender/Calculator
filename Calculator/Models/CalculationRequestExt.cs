namespace Calculator.Models
{
    public class CalculationRequestExt : CalculationRequest
    {
        public CalculationRequestExt(decimal number1, decimal number2, decimal? number3, decimal? number4, decimal? number5) : base(number1, number2) 
        {
            Number3 = number3;
            Number4 = number4;
            Number5 = number5;
        }

        public decimal? Number3 { get; private set; }
        public decimal? Number4 { get; private set; }
        public decimal? Number5 { get; private set; }
    }
}
