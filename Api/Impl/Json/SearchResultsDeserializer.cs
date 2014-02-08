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

using Spring.Json;
using System.Collections.Generic;

namespace Spring.Social.oDesk.Api.Impl.Json
{
    /// <summary>
    /// JSON deserializer for oDesk job search results data. 
    /// </summary>
    /// <author>Tom Day</author>
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
