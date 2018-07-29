using System;
using System.Net.Http;
using CodingTest.Mappers;
using CodingTest.Models;
using CodingTest.Services;
using CodingTest.Validators;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;

namespace CodingTest
{
    public class PayrollProcessing
    {
        private const string ApiUri = 
            "employeeName/{firstName}/{lastName}/annualSalary/{annualSalary}/taxRate/{superRate}/paymentPeriod/{paymentPeriod}";

        [FunctionName("ProcessPayroll")]
        public static HttpResponseMessage Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = ApiUri)]EmployeeDetailsRequest request,
            TraceWriter log)
        {
            log.Info($"Received request for gross payment processing for employee {request.FirstName} {request.LastName}");

            try
            {
                var paymentProcessorService = new PaymentProcessorService(new RequestValidator(), new Mapper());
                return paymentProcessorService.Process(request);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
