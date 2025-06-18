using employeeApi.Shared;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace employeeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly YouDbContext _dbContext;

        public DepartmentController(YouDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        

        [HttpGet("list")]
        public async Task<IActionResult> list()
        {
            try
            {
                return new JsonResult(_dbContext.departments.Select(x => new
                {
                    ID = x.id,
                    Name = x.name,
                }).ToList());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


       
    }
}
