using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommonLayer.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RepositoryLayer.Interface;

namespace SeriloggerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        private readonly ILogger<BaseController> _logger;

        private readonly IServiceRL _serviceRL;
        public BaseController(ILogger<BaseController> logger, IServiceRL serviceRL) 
        {
            _logger = logger;
            _serviceRL = serviceRL;
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployee()
        {
            try
            {
                _logger.LogInformation("Get Employee's Details");
                var status = true;
                var data = await _serviceRL.EmployeeDetails();
                if (!data.Equals(0))
                {
                    _logger.LogInformation("All Employee Details");
                    var Message = "Employee Details";
                    return Ok(new { data, status, Message });
                }
                else
                {
                    _logger.LogError("No Employee's Details");
                    status = false;
                    var Message = "No Employee Details";
                    return this.BadRequest(new { status, Message });
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddEmployee(EmployeeDetails details)
        {
            try
            {
                _logger.LogInformation("Add Employee's Details");
                var status = true;
                var data = await _serviceRL.AddEmployeeDetails(details);
                if (!data.Equals(0))
                {
                    _logger.LogInformation("Added Employee's Details Succesfully");
                    _logger.LogInformation($"Employee's Details {data}");
                    var Message = "Employee Registered Succesfully";
                    return Ok(new { data, status, Message });
                }
                else
                {
                    status = false;
                    var Message = "Employee Registration Failed Try Again!!!";
                    _logger.LogError($"Added Employee's Details Fails {Message}");
                    return this.BadRequest(new { status, Message });
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("{EmployeeId}/update")]
        [HttpPost]
        public async Task<IActionResult> UpdateEmployee(EmployeeDetails details,int EmployeeId)
        {
            try
            {
                _logger.LogInformation("Update Employee's Details");
                var status = true;
                var data = await _serviceRL.UpdateEmployeeDetails(details,EmployeeId);
                if (!data.Equals(0))
                {
                    _logger.LogInformation("Updated Employee's Details Succesfully");
                    _logger.LogInformation($"Employee's Details{data}");
                    var Message = "Employee Update Succesfully";
                    return Ok(new { data, status, Message });
                }
                else
                {
                    _logger.LogError("Update Employee's Details Fails");
                    status = false;
                    var Message = "Employee Update Failed Try Again!!!";
                    _logger.LogError(Message);
                    return this.BadRequest(new { status, Message });
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
