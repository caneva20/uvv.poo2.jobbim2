using System;

namespace ajj.Models {
    public class Subscription {
        public long Id { get; set; }
        public DateTime Date { get; set; }
        public SubscriptionStatus Status { get; set; }
        public Employee Employee { get; set; }
        public Course Course { get; set; }
    }

    public enum SubscriptionStatus {
        
    }
}
