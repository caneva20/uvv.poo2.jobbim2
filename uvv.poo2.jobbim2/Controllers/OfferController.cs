using System.Linq;
using ajj.Data;
using ajj.DTOs;
using ajj.Models;
using Microsoft.AspNetCore.Mvc;

namespace ajj.Controllers
{
    [Route("[controller]")][ApiController]
    public class OfferController : ControllerBase
    {
        private readonly Context _context;

        public OfferController(Context context)
        {
            _context = context;
        }
        
        [HttpGet("{id}")]
        public ActionResult<Offer> GetOffer(long id)
        {
            return Ok("aleatorio");
            var offer = _context.Offers.SingleOrDefault(x => x.Id == id);
            if (offer == null)
            {
                return NotFound("Offer not found");
            }

            return offer;
        }

        [HttpPost()]
        public IActionResult CreateOffer([FromBody]OfferDTO dto)
        {
            var course = _context.Courses.SingleOrDefault(x=> x.Id == dto.CourseId);
            if (course == null)
            {
                return NotFound("Course not found");
            }

            var offer = new Offer
            {
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
        public IActionResult UpdateStatus(long id, [FromBody] OfferStatusDTO dto)
        {
            var offer = _context.Offers.SingleOrDefault(x => x.Id == id);
            if (offer == null)
            {
                return NotFound("Offer not found");
            }

            offer.Status = dto.Status;
            
            _context.Update(offer);
            _context.SaveChanges();

            return Ok();
        }
    }
}