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

using Spring.Http;
using Spring.Http.Client;
using Spring.Rest.Client.Support;
using System;
using System.Net;

namespace Spring.Social.oDesk.Api
{
    /// <summary>
    /// The handler for errors that occur while consuming the oDesk REST API.
    /// </summary>
    /// <author>Tom Day</author>
    public class oDeskErrorHandler : DefaultResponseErrorHandler
    {
        public override void HandleError(Uri requestUri, HttpMethod requestMethod, IClientHttpResponse response)
        {
            var statusCode = response.StatusCode;

            switch (statusCode)
            {
                case HttpStatusCode.BadRequest:
                    throw new oDeskApiException("Missing parameter.");
                    break;

                case HttpStatusCode.Forbidden:
                    throw new oDeskApiException("Could not authenticate with OAuth.");
                    break;

                case HttpStatusCode.InternalServerError:
                    throw new oDeskApiException("oDesk server error.");
                    break;

                case HttpStatusCode.RequestTimeout:
                    throw new oDeskApiException("oDesk did not respond in a timely manner.");
                    break;

                case HttpStatusCode.ServiceUnavailable:
                    throw new oDeskApiException("oDesk is unavailable.");
                    break;

                case HttpStatusCode.Unauthorized:
                    throw new oDeskApiException("Could not authenticate with OAuth.");
                    break;

                default:
                    base.HandleError(requestUri, requestMethod, response);
                    break;
            }
        }
    }
}
