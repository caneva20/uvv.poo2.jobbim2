using System;
using System.Collections.Generic;
using System.Linq;
using ajj.Data;
using ajj.DTOs;
using ajj.Models;
using Microsoft.AspNetCore.Mvc;

namespace ajj.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly Context _context;

        public EmployeeController(Context context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public ActionResult<Employee> GetEmployees(long id)
        {
            var employee = _context.Employees.SingleOrDefault(x => x.Id == id);
            if (employee == null)
            {
                return NotFound("Employee not found");
            }

            return employee;
        }

        [HttpGet("{id}")]
        [ActionName("courses")]
        public ActionResult<IEnumerable<Course>> GetEmployeesCourses(long id)
        {
            var employee = _context.Employees.SingleOrDefault(x => x.Id == id);
            if (employee == null)
            {
                return NotFound("Employee not found");
            }

            var employeeCourses = new List<Course>();
            foreach (var subscription in _context.Subscriptions.Where(x => x.Employee == employee))
            {
                employeeCourses.Add(subscription.Course);
            }

            return employeeCourses;
        }

        [HttpPost]
        public IActionResult CreateEmployee([FromBody] EmployeeDTO dto)
        {
            var employee = new Employee()
            {
                Name = dto.Name,
                AdmissionDate = dto.AdmissionDate,
            };

            _context.Add(employee);
            _context.SaveChanges();

            return Ok();
        }

        [HttpPost("{id}")]
        public IActionResult TerminateContract(long id)
        {
            var employee = _context.Employees.SingleOrDefault(x => x.Id == id);
            if (employee == null)
            {
                return NotFound("Employee not found");
            }

            employee.TerminationDate = DateTime.UtcNow;

            _context.Update(employee);
            _context.SaveChanges();

            return Ok();
        }
    }
}