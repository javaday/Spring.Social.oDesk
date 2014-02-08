using Spring.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spring.Social.oDesk.Api.Impl.Json
{
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
