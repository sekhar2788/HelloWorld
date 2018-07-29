using System.Net.Http;
using CodingTest.Models;

namespace CodingTest.Mappers
{
    public interface IMapper
    {
        EmployeeGrossSalaryResponse Map(EmployeeDetailsRequest request, TaxRate matchingTaxRate);
    }
}