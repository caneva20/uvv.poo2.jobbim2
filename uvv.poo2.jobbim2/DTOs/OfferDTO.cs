using System;
using ajj.Models;

namespace ajj.DTOs
{
    public class OfferDTO
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public OfferStatus Status { get; set; }
        public long CourseId { get; set; }
    }
}