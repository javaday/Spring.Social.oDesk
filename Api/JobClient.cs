using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spring.Social.oDesk.Api
{
    public class JobClient
    {
        public string Country { get; set; }
        public float FeedbackRating { get; set; }
        public int ReviewCount { get; set; }
        public int JobCount { get; set; }
        public int HireCount { get; set; }
        public string PaymentVerificationStatus { get; set; }
    }
}
