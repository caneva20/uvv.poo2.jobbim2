using System;

namespace ajj.Models {
    public enum OfferStatus {
        Closed,
        Open,
        Suspended,
        Canceled,
        Finished
    }
    public class Offer {
        public long Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Course Course { get; set; }
        public OfferStatus Status { get; set; }
    }
    
}
