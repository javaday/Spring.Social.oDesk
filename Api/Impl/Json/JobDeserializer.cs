using Spring.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spring.Social.oDesk.Api.Impl.Json
{
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
