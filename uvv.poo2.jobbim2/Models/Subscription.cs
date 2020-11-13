using System;

namespace ajj.Models {
    public class Subscription {
        public long Id { get; set; }
        
        public long CourseId { get; set; }
        public Course Course { get; set; }

        public long EmployeeId { get; set; }
        public Employee Employee { get; set; }
        
        public DateTime Date { get; set; }
        public SubscriptionStatus Status { get; set; }
    }

    public enum SubscriptionStatus {
        
    }
}
