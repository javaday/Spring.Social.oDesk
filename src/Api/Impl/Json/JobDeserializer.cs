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
using System;
using System.Collections.Generic;

namespace Spring.Social.oDesk.Api.Impl.Json
{
    /// <summary>
    /// JSON deserializer for oDesk job data. 
    /// </summary>
    /// <author>Tom Day</author>
    public class JobDeserializer : IJsonDeserializer
    {
        #region IJsonDeserializer Members

        public object Deserialize(JsonValue json, JsonMapper mapper)
        {
            var job = new Job();

            var clientJson = json.GetValue("client");

            job.Id = json.GetValueOrDefault<string>("id", "");
            job.Title = json.GetValueOrDefault<string>("title", "");
            job.Snippet = json.GetValueOrDefault<string>("snippet", "");
            job.Skills = deserializeSkills(json.GetValues("skills"));
            job.Category = json.GetValueOrDefault<string>("category", "");
            job.Subcategory = json.GetValueOrDefault<string>("subcategory", "");
            job.JobType = json.GetValueOrDefault<string>("job_type", "");
            job.Duration = json.GetValueOrDefault<string>("duration", "");
            job.Budget = json.GetValueOrDefault<string>("budget", "");
            job.Workload = json.GetValueOrDefault<string>("workload", "");
            job.Status = json.GetValueOrDefault<string>("job_status", "");
            job.Url = json.GetValueOrDefault<string>("url", "");
            job.DateCreated = json.GetValueOrDefault<DateTime>("date_created", DateTime.MinValue);

            if (clientJson != null)
            {
                job.Client.Country = clientJson.GetValueOrDefault<string>("country", "");
                job.Client.FeedbackRating = clientJson.GetValueOrDefault<float>("feedback", 0);
                job.Client.ReviewCount = clientJson.GetValueOrDefault<int>("reviews_count", 0);
                job.Client.JobCount = clientJson.GetValueOrDefault<int>("jobs_posted", 0);
                job.Client.HireCount = clientJson.GetValueOrDefault<int>("past_hires", 0);
                job.Client.PaymentVerificationStatus = clientJson.GetValueOrDefault<string>("payment_verification_status", "");
            }

            return job;
        }

        #endregion

        private List<string> deserializeSkills(ICollection<JsonValue> skillsJson)
        {
            var skillList = new List<string>();

            foreach(var skillJson in skillsJson)
            {
                var skill = skillJson.GetValue<string>();

                skillList.Add(skill);
            }

            return skillList;
        }
    }
}
