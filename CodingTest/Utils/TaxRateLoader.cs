using System.Collections.Generic;
using CodingTest.Models;

namespace CodingTest.Utils
{
    public static class TaxRateLoader
    {
        public static IEnumerable<TaxRate> Load()
        {
            return new List<TaxRate>
            {
                new TaxRate
                {
                    StartRangeTaxableIncome = 0,
                    EndRangeTaxableIncome = 18200,
                    BaseTax = 0,
                    VariableTaxAmount = 0
                },
                new TaxRate
                {
                    StartRangeTaxableIncome = 18201,
                    EndRangeTaxableIncome = 37000,
                    BaseTax = 0,
                    VariableTaxAmount = 0.19m
                },
                new TaxRate
                {
                    StartRangeTaxableIncome = 37001,
                    EndRangeTaxableIncome = 87000,
                    BaseTax = 3572,
                    VariableTaxAmount = 0.325m
                },
                new TaxRate
                {
                    StartRangeTaxableIncome = 87001,
                    EndRangeTaxableIncome = 180000,
                    BaseTax = 19822,
                    VariableTaxAmount = 0.37m
                },
                new TaxRate
                {
                    StartRangeTaxableIncome = 180001,
                    EndRangeTaxableIncome = decimal.MaxValue,
                    BaseTax = 54232,
                    VariableTaxAmount = 0.45m
                }
            };
        }
    }
}
