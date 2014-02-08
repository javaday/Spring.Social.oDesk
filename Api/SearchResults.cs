using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spring.Social.oDesk.Api
{
    public class SearchResults
    {
        public long ServerTime { get; set; }
        public AuthUser AuthUser { get; set; }
        public string ProfileAccess { get; set; }
        public List<Job> Jobs { get; set; }
        public SearchResultsPaging Paging { get; set; }

        public SearchResults()
        {
            this.AuthUser = new AuthUser();
            this.Jobs = new List<Job>();
            this.Paging = new SearchResultsPaging();
        }
    }
}
