using System.Collections.Generic;
using System.Linq;
using ajj.Data;
using ajj.DTOs;
using ajj.Models;
using Microsoft.AspNetCore.Mvc;

namespace ajj.Controllers {
    [Route("[controller]")]
    [ApiController]
    public class OfferController : ControllerBase {
        private readonly Context _context;

        public OfferController(Context context) {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Offer>> GetOffers() {
            var courses = _context.Courses.ToList();

            var offers = new List<Offer>();

            foreach (var course in courses) {
                offers.AddRange(_context.Offers.Where(x => x.Course == course)
                   .ToList());
            }

            return offers;
        }
        
        [HttpGet("{courseId}")]
        public ActionResult<IEnumerable<Offer>> GetOffers(long courseId) {
            var course = _context.Courses.SingleOrDefault(x => x.Id == courseId);
            if (course == null) {
                return NotFound("Offer not found");
            }

            var result = _context.Offers.Where(x => x.Course == course)
               .ToList();
            
            return result;
        }

        [HttpPost()]
        public IActionResult CreateOffer([FromBody] OfferDTO dto) {
            var course = _context.Courses.SingleOrDefault(x => x.Id == dto.CourseId);
            if (course == null) {
                return NotFound("Course not found");
            }

            var offer = new Offer {
                Course = course,
                Status = dto.Status,
                EndDate = dto.EndDate,
                StartDate = dto.StartDate
            };

            _context.Add(offer);
            _context.SaveChanges();

            return Ok();
        }

        [HttpPost("{id}")]
        public IActionResult UpdateStatus(long id, [FromBody] OfferStatusDTO dto) {
            var offer = _context.Offers.SingleOrDefault(x => x.Id == id);
            if (offer == null) {
                return NotFound("Offer not found");
            }

            offer.Status = dto.Status;

            _context.Update(offer);
            _context.SaveChanges();

            return Ok();
        }
    }
}
