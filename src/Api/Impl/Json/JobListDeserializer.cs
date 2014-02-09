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
    /// JSON deserializer for a list of oDesk job data. 
    /// </summary>
    /// <author>Tom Day</author>
    public class JobListDeserializer : IJsonDeserializer
    {
        #region IJsonDeserializer Members

        public virtual object Deserialize(JsonValue json, JsonMapper mapper)
        {
            var jobList = new List<Job>();

            foreach(var jobJson in json.GetValues())
            {
                var job = mapper.Deserialize<Job>(jobJson);

                jobList.Add(job);
            }

            return jobList;
        }

        #endregion
    }
}
