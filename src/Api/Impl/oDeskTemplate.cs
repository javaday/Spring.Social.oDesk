﻿#region License

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

using Spring.Http.Converters;
using Spring.Http.Converters.Json;
using Spring.Json;
using Spring.Rest.Client;
using Spring.Social.OAuth1;
using Spring.Social.oDesk.Api.Impl.Json;
using System;
using System.Collections.Generic;

namespace Spring.Social.oDesk.Api.Impl
{
    /// <summary>
    /// This is the central class for interacting with oDesk.
    /// </summary>
    /// <remarks>
    /// <para>
    /// To perform oDesk operations, <see cref="oDeskTemplate"/> must be constructed 
    /// with the minimal amount of information required to sign requests to oDesk's API 
    /// with an OAuth <code>Authorization</code> header.
    /// </para>
    /// </remarks>
    /// <author>Tom Day</author>
    public class oDeskTemplate : AbstractOAuth1ApiBinding, IoDesk
    {
        private static readonly Uri apiBaseUri = new Uri("http://www.odesk.com/api/");

        private IJobSearchOperations jobSearchOperations;

        /// <summary>
        /// Create a new instance of <see cref="oDeskTemplate"/>.
        /// </summary>
        /// <param name="consumerKey">The application's API key.</param>
        /// <param name="consumerSecret">The application's API secret.</param>
        /// <param name="accessToken">An access token acquired through OAuth authentication with oDesk.</param>
        /// <param name="accessTokenSecret">An access token secret acquired through OAuth authentication with oDesk.</param>
        public oDeskTemplate(string consumerKey, string consumerSecret, string accessToken, string accessTokenSecret) 
            : base(consumerKey, consumerSecret, accessToken, accessTokenSecret)
        {
            initSubApis();
        }

        #region IoDesk Members

        /// <summary>
        /// Gets the portion of the oDesk API containing the job search operations.
        /// </summary>
        public IJobSearchOperations JobSearchOperations
        {
            get { return this.jobSearchOperations; }
        }

        /// <summary>
        /// Gets the underlying <see cref="IRestOperations"/> object allowing for consumption of oDesk endpoints 
        /// that may not be otherwise covered by the API binding. 
        /// </summary>
        /// <remarks>
        /// The <see cref="IRestOperations"/> object returned is configured to include an OAuth "Authorization" header on all requests.
        /// </remarks>
        public IRestOperations RestOperations
        {
            get { return RestTemplate; }
        }

        #endregion

        /// <summary>
        /// Returns a list of <see cref="IHttpMessageConverter"/>s to be used by the internal <see cref="RestTemplate"/>.
        /// </summary>
        /// <returns>
        /// The list of <see cref="IHttpMessageConverter"/>s to be used by the internal <see cref="RestTemplate"/>.
        /// </returns>
        protected override IList<IHttpMessageConverter> GetMessageConverters()
        {
            IList<IHttpMessageConverter> converters = base.GetMessageConverters();

            converters.Add(new ByteArrayHttpMessageConverter());
            converters.Add(GetJsonMessageConverter());

            return converters;
        }

        /// <summary>
        /// Enables customization of the <see cref="RestTemplate"/> used to consume provider API resources.
        /// </summary>
        /// <remarks>
        /// An example use case might be to configure a custom error handler. 
        /// Note that this method is called after the RestTemplate has been configured with the message converters returned from GetMessageConverters().
        /// </remarks>
        /// <param name="restTemplate">The RestTemplate to configure.</param>
        protected override void ConfigureRestTemplate(RestTemplate restTemplate)
        {
            base.ConfigureRestTemplate(restTemplate);

            restTemplate.ErrorHandler = new oDeskErrorHandler();
        }

        /// <summary>
        /// Returns a <see cref="SpringJsonHttpMessageConverter"/> to be used by the internal <see cref="RestTemplate"/>.
        /// </summary>
        /// <returns>The configured <see cref="SpringJsonHttpMessageConverter"/>.</returns>
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
