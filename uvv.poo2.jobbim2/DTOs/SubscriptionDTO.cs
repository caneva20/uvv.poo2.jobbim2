using System;
using ajj.Models;

namespace ajj.DTOs
{
    public class SubscriptionDTO
    {
        public long CourseId { get; set; }
        public long EmployeeId { get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; }
    }
}