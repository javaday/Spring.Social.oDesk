#region License

/*
 * Copyright 2014 the original author or authors.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

#endregion

using Spring.Rest.Client;
using System;

namespace Spring.Social.oDesk.Api.Impl
{
    /// <summary>
    /// Implementation of <see cref="IJobSearchOperations"/>, providing a binding to oDesk's job search REST resources.
    /// </summary>
    /// <author>Tom Day</author>
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
