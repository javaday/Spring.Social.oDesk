using Spring.Http.Converters;
using Spring.Http.Converters.Json;
using Spring.Json;
using Spring.Rest.Client;
using Spring.Social.OAuth1;
using Spring.Social.oDesk.Api.Impl.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spring.Social.oDesk.Api.Impl
{
    public class oDeskTemplate : AbstractOAuth1ApiBinding, IoDesk
    {
        private static readonly Uri apiBaseUri = new Uri("http://www.odesk.com/api/");

        private IJobSearchOperations jobSearchOperations;

        public oDeskTemplate(string consumerKey, string consumerSecret, string accessToken, string accessTokenSecret) 
            : base(consumerKey, consumerSecret, accessToken, accessTokenSecret)
        {
            initSubApis();
        }

        #region IoDesk Members

        public IJobSearchOperations JobSearchOperations
        {
            get { return this.jobSearchOperations; }
        }

        public IRestOperations RestOperations
        {
            get { return RestTemplate; }
        }

        #endregion

        protected override IList<IHttpMessageConverter> GetMessageConverters()
        {
            IList<IHttpMessageConverter> converters = base.GetMessageConverters();
            converters.Add(new ByteArrayHttpMessageConverter());
            converters.Add(GetJsonMessageConverter());
            return converters;
        }

        protected override void ConfigureRestTemplate(RestTemplate restTemplate)
        {
            base.ConfigureRestTemplate(restTemplate);

            restTemplate.ErrorHandler = new oDeskErrorHandler();
        }

        private SpringJsonHttpMessageConverter GetJsonMessageConverter()
        {
            var jsonMapper = new JsonMapper();

            jsonMapper.RegisterDeserializer(typeof(SearchResults), new SearchResultsDeserializer());
            jsonMapper.RegisterDeserializer(typeof(List<Job>), new JobListDeserializer());
            jsonMapper.RegisterDeserializer(typeof(Job), new JobDeserializer());

            return new SpringJsonHttpMessageConverter(jsonMapper);
        }

        private void initSubApis()
        {
            this.jobSearchOperations = new JobSearchTemplate(base.RestTemplate);
        }
    }
}
