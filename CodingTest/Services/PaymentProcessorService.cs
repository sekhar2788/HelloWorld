using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using CodingTest.Mappers;
using CodingTest.Models;
using CodingTest.Utils;
using CodingTest.Validators;
using Newtonsoft.Json;

namespace CodingTest.Services
{
    public class PaymentProcessorService
    {
        private readonly IRequestValidator _requestValidator;
        private readonly IMapper _mapper;

        public PaymentProcessorService(IRequestValidator requestValidator, IMapper mapper)
        {
            _requestValidator = requestValidator ?? throw new ArgumentNullException(nameof(requestValidator));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public HttpResponseMessage Process(EmployeeDetailsRequest request)
        {
            //TODO: return Bad request
            if (!_requestValidator.IsValid()) return null;

            var matchingTaxRate = GetTaxRate(request.AnnualSalary);

            return new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(_mapper.Map(request, matchingTaxRate)))
            };
        }

        private static TaxRate GetTaxRate(decimal annualSalary)
        {
            var taxRates = TaxRateLoader.Load() ?? throw new ArgumentNullException();

            return taxRates.FirstOrDefault(rate => annualSalary > rate.StartRangeTaxableIncome &&
                                                   annualSalary < rate.EndRangeTaxableIncome);
        }
    }
}
