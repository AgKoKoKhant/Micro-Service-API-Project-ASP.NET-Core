using Alpha.ServiceB.Interface;
using Alpha.ServiceB.Model;
using Microsoft.AspNetCore.Mvc;

namespace Alpha.ServiceB.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("Application/json")]
    // REST API Backend Api, Service > Server Side Application > Host on IIS, Apache, Nginx, Docker, Thread, User Concurrency
    // Angular > Frontend Application (Web), Windows Application, Desktop , Client Side Applicaton, Build and Compile on Web Browser Desktop Application
    // xml > SOAP Werservices > System Integration
    public class ServiceBController : ControllerBase
    {
        private readonly IServiceB _serviceB;
        public ServiceBController(IServiceB serviceB)
        {
            _serviceB = serviceB;
        }

        #region Teacher

        [HttpGet("GetTeachers")]
        public async Task<IActionResult> GetAllTeacher()
        {
            var result = _serviceB.GetTeacherSB();
            return Ok(result);
        }

        [HttpGet("GetTeacherByName")]
        public async Task<IActionResult> GetTeacherByName([FromQuery] string name) // Http Reqeust header
        {
            var result = _serviceB.GetTeacherSB(name);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost("AddTeacher")]
        public async Task<IActionResult> GetTeachers([FromBody] TeacherModel teacher)
        {
            var result = _serviceB.AddTeacherSB(teacher);
            return Ok(result);
        }
        #endregion

        #region Student
        [HttpGet("GetStduents")]
        public async Task<IActionResult> GetAllStudent()
        {
            var result = _serviceB.GetStudentSB();
            return Ok(result);
        }

        [HttpGet("GetStudentByName")]
        public async Task<IActionResult> GetStudentByName([FromQuery] string name)
        {
            var result = _serviceB.GetStudentSB(name);
            return Ok(result);
        }

        [HttpPost("AddStudent")]
        public async Task<IActionResult> AddStudent([FromBody] StudentModel student)
        {
            var result = _serviceB.AddStudentSB(student);
            return Ok(result);
        }


        #endregion

    }
}
