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

using System;
using System.Collections.Generic;

namespace Spring.Social.oDesk.Api
{
    /// <summary>
    /// Representation of oDesk job data.
    /// </summary>
    /// <author>Tom Day</author>
    public class Job
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Snippet { get; set; }
        public List<string> Skills { get; set; }
        public string Category { get; set; }
        public string Subcategory { get; set; }
        public string JobType { get; set; }
        public string Duration { get; set; }
        public string Budget { get; set; }
        public string Workload { get; set; }
        public string Status { get; set; }
        public string Url { get; set; }
        public DateTime DateCreated { get; set; }
        public JobClient Client { get; set; }

        public Job()
        {
            this.Client = new JobClient();
        }
    }
}
