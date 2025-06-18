using employeeApi.Dto;
using employeeApi.Model;
using employeeApi.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace employeeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly YouDbContext _dbContext;

        public EmployeeController(YouDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var emplist = _dbContext.employees.Include(x => x.Department).ToList();
            return new JsonResult(new { employeeData = emplist });
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public IActionResult Post([FromBody] employeeDto value)
        {
            int Id = _dbContext.employees.Select(p => p.id).DefaultIfEmpty().Max();
            Employee employee = new Employee()
            {
                id = Id + 1,
                name = value.name,
                address = value.address,
                salary= value.salary,
                gender= value.gender,
                dob=value.dob,
                departmentId=value.departmentId
            };

            _dbContext.employees.Add(employee);
            _dbContext.SaveChanges();
            return new JsonResult(new { message = "Record Saved Successfully." ,empdata= employee });
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var res = _dbContext.employees.FirstOrDefault(p => p.id == id);

            _dbContext.employees.Remove(res);
            _dbContext.SaveChanges();
            return Ok();
        }
    }
}
