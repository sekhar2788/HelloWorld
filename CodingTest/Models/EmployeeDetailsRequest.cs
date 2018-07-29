namespace CodingTest.Models
{
    public class EmployeeDetailsRequest
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public decimal AnnualSalary { get; set; }

        public int SuperRate { get; set; }

        public string PaymentPeriod { get; set; }
    }
}
