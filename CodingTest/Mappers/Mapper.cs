using CodingTest.Models;

namespace CodingTest.Mappers
{
    public class Mapper : IMapper
    {
        public EmployeeGrossSalaryResponse Map(EmployeeDetailsRequest request, TaxRate matchingTaxRate) => new EmployeeGrossSalaryResponse
        {
            EmployeeFullName = $"{request.FirstName} {request.LastName}",
            GrossIncome = CalculateGrossIncome(request.AnnualSalary),
            IncomeTax = CalculateIncomeTax(request.AnnualSalary, matchingTaxRate),
            Super = (CalculateGrossIncome(request.AnnualSalary)/100) * request.SuperRate
        };

        private static decimal CalculateGrossIncome(decimal annualSalary) => annualSalary/12;

        private static decimal CalculateIncomeTax(decimal annualSalary, TaxRate taxRate) =>
            (taxRate.BaseTax + (annualSalary - GetAmountNotSubjectedToVariableTaxRate(taxRate.StartRangeTaxableIncome)) * taxRate.VariableTaxAmount) / 12;

        private static decimal GetAmountNotSubjectedToVariableTaxRate(decimal startTaxRange)
        {
            if (startTaxRange == 0)
                return 0;

            return startTaxRange - 1;
        }
    }
}
