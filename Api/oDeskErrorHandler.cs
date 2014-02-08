using Spring.Http;
using Spring.Http.Client;
using Spring.Rest.Client;
using Spring.Rest.Client.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Spring.Social.oDesk.Api
{
    public class oDeskErrorHandler : DefaultResponseErrorHandler
    {
        public override void HandleError(Uri requestUri, HttpMethod requestMethod, IClientHttpResponse response)
        {
            var statusCode = response.StatusCode;

            switch (statusCode)
            {
                case HttpStatusCode.BadRequest:
                    throw new RestClientException("Missing parameter.");
                    break;

                case HttpStatusCode.Forbidden:
                    throw new RestClientException("Could not authenticate with OAuth.");
                    break;

                case HttpStatusCode.InternalServerError:
                    throw new RestClientException("oDesk server error.");
                    break;

                case HttpStatusCode.RequestTimeout:
                    throw new RestClientException("oDesk did not respond in a timely manner.");
                    break;

                case HttpStatusCode.ServiceUnavailable:
                    throw new RestClientException("oDesk is unavailable.");
                    break;

                case HttpStatusCode.Unauthorized:
                    throw new RestClientException("Could not authenticate with OAuth.");
                    break;

                default:
                    base.HandleError(requestUri, requestMethod, response);
                    break;
            }
        }
    }
}
