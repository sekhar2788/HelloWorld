namespace CodingTest.Models
{
    public class TaxRate
    {
        public decimal StartRangeTaxableIncome { get; set; }

        public decimal EndRangeTaxableIncome { get; set; }

        public decimal BaseTax { get; set; }

        public decimal VariableTaxAmount { get; set; }
    }
}
