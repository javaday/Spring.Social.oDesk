using Spring.Social.OAuth1;
using Spring.Social.oDesk.Api;
using Spring.Social.oDesk.Api.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spring.Social.oDesk.Connect
{
    public class oDeskServiceProvider : AbstractOAuth1ServiceProvider<IoDesk>
    {
        public oDeskServiceProvider(string consumerKey, string consumerSecret)
            : base(consumerKey, consumerSecret, new OAuth1Template(consumerKey, consumerSecret,
                "https://www.odesk.com/api/auth/v1/oauth/token/request",
                "https://www.odesk.com/services/api/auth",
                "https://www.odesk.com/api/auth/v1/oauth/token/access"))
        {
        }

        public override IoDesk GetApi(string accessToken, string secret)
        {
            return new oDeskTemplate(ConsumerKey, ConsumerSecret, accessToken, secret);
        }
    }
}
