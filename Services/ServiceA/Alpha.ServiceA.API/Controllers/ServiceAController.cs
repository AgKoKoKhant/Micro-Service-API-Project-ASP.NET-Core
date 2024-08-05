﻿using Microsoft.AspNetCore.Mvc;
using Alpha.ServiceA.Model;
using Alpha.ServiceA.Interface;
using Microsoft.AspNetCore.Mvc;


namespace ServiceA.API.Controllers
{
    [ApiController]
    [Produces("application/json")]
    // REST API Backend Api, Service > Server Side Application > Host on IIS, Apache, Nginx, Docker, Thread, User Concurrency
    // Angular > Frontend Application (Web), Windows Application, Desktop , Client Side Applicaton, Build and Compile on Web Browser Desktop Application
    // xml > SOAP Werservices > System Integration
    [Route("controller")]

    public class ServiceAController : ControllerBase
    {
        private readonly IServiceA _serviceA;

        public ServiceAController(IServiceA serviceA)
        {
            _serviceA = serviceA;
        }



        //  [HttpPost(Name = "SaveTeachers")]  // Create
        [HttpGet("GetTeachers")]    // Read
                                    //   [HttpPut(Name = "UpdateTeachers")] // Update
                                    //   [HttpDelete(Name = "GetTeachers")] // Delete
                                    // Multi Thread Support, စောင့်မယ် မစောင့်ဘူး ဆုံးဖြတ်နိုင်ဖို့
        public async Task<IActionResult> GetTeachers()
        {
            var result = _serviceA.GetTeachers();
            return Ok(result);
        }

        [HttpGet("GetTeacherbyName")]
        public async Task<IActionResult> GetTeachertByName([FromQuery] string name)
        {
            var result = _serviceA.GetTeacher(name);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }


        [HttpPost("AddStudent")]
        public async Task<IActionResult> AddStudent([FromBody] StudentModel student)
        {
            var result = _serviceA.AddStudent(student);
            return Ok(result);
        }



        [HttpGet("GetStudents")]
        public async Task<IActionResult> GetStudents()
        {
            var result = _serviceA.GetStudents();

            //try
            //{
            //    _logger.InformationLog("Started GetStudents");
            //}
            //catch (Exception ex)
            //{
            //    _logger.ErrorLog(ex);
            //}
            return Ok(result);
        }

        [HttpGet("GetProducts")]
        public async Task<IActionResult> GetProducts()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, "http://localhost:5158/api/Products");
            request.Headers.Add("accept", "text/plain");
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            Console.WriteLine(await response.Content.ReadAsStringAsync());
            return Ok(await response.Content.ReadAsStringAsync());
        }
    }
}
