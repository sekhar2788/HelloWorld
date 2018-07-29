namespace CodingTest.Models
{
    public class EmployeeGrossSalaryResponse
    {
        public string EmployeeFullName { get; set; }

        public decimal GrossIncome { get; set; }

        public decimal IncomeTax { get; set; }

        public decimal NetIncome => GrossIncome - IncomeTax;

        public decimal Super { get; set; }
    }
}
