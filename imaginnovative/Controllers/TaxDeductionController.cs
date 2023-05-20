using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace imaginnovative.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaxDeductionController : ControllerBase
    {

        private readonly ApplicationDBContext _dbContext;

        public TaxDeductionController(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("taxdeduction")]
        public IActionResult GetEmployeesTaxDeduction()
        {
            List<TaxDeductionResult> results = new List<TaxDeductionResult>();

            var employees = _dbContext.Employees.ToList();

            foreach (var employee in employees)
            {
                decimal yearlySalary = CalculateYearlySalary(employee);

                decimal taxAmount = CalculateTaxAmount(yearlySalary);

                decimal cessAmount = CalculateCessAmount(yearlySalary);

                results.Add(new TaxDeductionResult
                {
                    EmployeeId = employee.EmployeeId,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    YearlySalary = yearlySalary,
                    TaxAmount = taxAmount,
                    CessAmount = cessAmount
                });
            }

            return Ok(results);
        }

        private decimal CalculateYearlySalary(Employee employee)
        {
            DateTime currentFinancialYearStart = new DateTime(DateTime.Now.Year, 4, 1);
            DateTime doj = employee.DOJ.Date;

            int months = (doj >= currentFinancialYearStart) ? DateTime.Now.Month - doj.Month + 1 : DateTime.Now.Month - doj.Month;

            decimal yearlySalary = employee.Salary * months;

            return yearlySalary;
        }

        private decimal CalculateTaxAmount(decimal yearlySalary)
        {
            decimal taxAmount = 0;

            if (yearlySalary > 1000000)
            {
                taxAmount = (yearlySalary - 1000000) * 0.2m + 150000;
            }
            else if (yearlySalary > 500000)
            {
                taxAmount = (yearlySalary - 500000) * 0.1m + 25000; 
            }
            else if (yearlySalary > 250000)
            {
                taxAmount = (yearlySalary - 250000) * 0.05m;
            }

            return taxAmount;
        }

        private decimal CalculateCessAmount(decimal yearlySalary)
        {
            decimal cessAmount = 0;

            if (yearlySalary > 2500000)
            {
                cessAmount = (yearlySalary - 2500000) * 0.02m;
            }

            return cessAmount;
        }
    }

}
