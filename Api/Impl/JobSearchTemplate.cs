using Spring.Rest.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spring.Social.oDesk.Api.Impl
{
    public class JobSearchTemplate : IJobSearchOperations
    {
        private static readonly Uri searchBaseUri = new Uri("https://www.odesk.com/api/profiles/v2/search/jobs.json");
        private RestTemplate restTemplate;

        public JobSearchTemplate(RestTemplate restTemplate)
        {
            this.restTemplate = restTemplate;
        }

        #region IJobSearchOperations Members

        public SearchResults Search(SearchParameters parameters)
        {
            if (string.IsNullOrEmpty(parameters.Query) && string.IsNullOrEmpty(parameters.Title) && string.IsNullOrEmpty(parameters.Skills))
            {
                throw new ArgumentException("At least one of the Query, Title, or Skills parameters must be specified.");
            }

            return restTemplate.GetForObject<SearchResults>(searchBaseUri + parameters.ToString());
        }

        #endregion
    }
}
