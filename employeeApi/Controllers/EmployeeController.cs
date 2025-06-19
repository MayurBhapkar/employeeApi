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
        public IActionResult Get(int id)
        {
            var res = _dbContext.employees.FirstOrDefault(x => x.id == id);
            return new JsonResult(res);
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
        public IActionResult Put(int id, [FromBody] employeeDto value)
        {
            var res = _dbContext.employees.FirstOrDefault(x => x.id == id);

            res.name= value.name;
            res.address= value.address;
            res.salary= value.salary;
            res.gender= value.gender;
            res.dob= value.dob;
            res.departmentId= value.departmentId;

            _dbContext.employees.Update(res);
            _dbContext.SaveChanges();
            return new JsonResult(new { message = "Record Updated Successfully." });

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
