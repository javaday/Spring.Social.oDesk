using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spring.Social.oDesk.Api
{
    public class Job
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Snippet { get; set; }
        public List<string> Skills { get; set; }
        public string Category { get; set; }
        public string Subcategory { get; set; }
        public string JobType { get; set; }
        public string Duration { get; set; }
        public string Budget { get; set; }
        public string Workload { get; set; }
        public string Status { get; set; }
        public string Url { get; set; }
        public DateTime DateCreated { get; set; }
        public JobClient Client { get; set; }

        public Job()
        {
            this.Client = new JobClient();
        }
    }
}
