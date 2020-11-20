using System;
using System.Collections.Generic;
using System.Linq;
using ajj.Data;
using ajj.DTOs;
using ajj.Models;
using Microsoft.AspNetCore.Mvc;

namespace ajj.Controllers
{
    [Route("[controller]")][ApiController]
    public class SubscriptionController : ControllerBase
    {
        private readonly Context _context;

        public SubscriptionController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Subscription>> GetSubscriptions() {
            return _context.Subscriptions.ToList();
        }
        
        [HttpGet("{id}")]
        public ActionResult<Subscription> GetSubscription(long id)
        {
            var subscription = _context.Subscriptions.SingleOrDefault(x => x.Id == id);
            if (subscription == null)
            {
                return NotFound("Subscription not found");
            }

            return subscription;
        }
        
        [HttpPost()]
        public IActionResult CreateSubscription([FromBody]SubscriptionDTO dto)
        {
            var course = _context.Courses.SingleOrDefault(x=> x.Id == dto.CourseId);
            if (course == null)
            {
                return NotFound("Course not found");
            }
            
            var employee = _context.Employees.SingleOrDefault(x=> x.Id == dto.EmployeeId);
            if (employee == null)
            {
                return NotFound("Employee not found");
            }

            var subscription = new Subscription
            {
                     Course = course,
                     Employee = employee,
                     Status = true,
                     Date = DateTime.UtcNow
            };
            
             _context.Add(subscription);
             _context.SaveChanges();
            
             return Ok();
        }
        
        [HttpPost("{id}")]
        public IActionResult UpdateStatus(long id, [FromBody] SubscriptionStatusDTO dto)
        {
            var subscription = _context.Subscriptions.SingleOrDefault(x => x.Id == id);
            if (subscription == null)
            {
                return NotFound("Subscription not found");
            }

            subscription.Status = dto.Status;
            
            _context.Update(subscription);
            _context.SaveChanges();

            return Ok();
        }
    }
}