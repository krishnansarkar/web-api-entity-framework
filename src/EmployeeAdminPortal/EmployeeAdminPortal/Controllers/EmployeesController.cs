using EmployeeAdminPortal.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAdminPortal.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase {

        [HttpGet]
        public async Task<ActionResult<List<Employee>>> GetAllEmployees() {
            var employees = new List<Employee> {
                new Employee {
                    Id = Guid.NewGuid(),
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "JohnDoe@email.com",
                    PhoneNumber = "123-456-7890",
                    Salary = 50000
                }
            };

            return Ok(employees);
        }
    }
}
