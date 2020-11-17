using System;

namespace ajj.Models {
    public enum OfferStatus {
        Open = 0,
        Suspended = 1,
        Canceled = 2,
    }
    public class Offer {
        public long Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Course Course { get; set; }
        public OfferStatus Status { get; set; }
    }
    
}
