using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace imaginnovative.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly ApplicationDBContext _dbContext;

        public EmployeesController(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }


        [HttpPost]
        public IActionResult StoreEmployeeDetails(Employee employee)
        {
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            _dbContext.Employees.Add(employee);
            _dbContext.SaveChanges();

            return Ok();
        }
    }
}
