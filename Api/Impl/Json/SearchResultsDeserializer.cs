using Spring.Json;
using Spring.Social.oDesk.Api.Impl.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spring.Social.oDesk.Api.Impl.Json
{
    public class SearchResultsDeserializer : IJsonDeserializer
    {
        #region IJsonDeserializer Members

        object IJsonDeserializer.Deserialize(JsonValue json, JsonMapper mapper)
        {
            var results = new SearchResults();
            var userJson = json.GetValue("auth_user");
            var pagingJson = json.GetValue("paging");
            var jobsJson = json.GetValue("jobs");


            results.ServerTime = json.GetValueOrDefault<long>("server_time");
            results.ProfileAccess = json.GetValueOrDefault<string>("profile_access");

            if (userJson != null)
            {
                results.AuthUser.FirstName = userJson.GetValue<string>("first_name");
                results.AuthUser.LastName = userJson.GetValue<string>("last_name");
                results.AuthUser.Username = userJson.GetValue<string>("uid");
                results.AuthUser.Email = userJson.GetValue<string>("mail");
                results.AuthUser.TimeZone = userJson.GetValue<string>("timezone");
                results.AuthUser.TimeZoneOffset = userJson.GetValue<string>("timezone_offset");
            }

            if (pagingJson != null)
            {
                results.Paging.Count = pagingJson.GetValue<int>("count");
                results.Paging.Offset = pagingJson.GetValue<int>("offset");
                results.Paging.Total = pagingJson.GetValue<int>("total");
            }

            results.Jobs = mapper.Deserialize<List<Job>>(jobsJson);

            return results;
        }

        #endregion
    }
}
