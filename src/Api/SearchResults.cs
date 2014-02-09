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

using System.Collections.Generic;

namespace Spring.Social.oDesk.Api
{
    /// <summary>
    /// Representation of oDesk job search results.
    /// </summary>
    /// <author>Tom Day</author>
    public class SearchResults
    {
        public long ServerTime { get; set; }
        public AuthUser AuthUser { get; set; }
        public string ProfileAccess { get; set; }
        public List<Job> Jobs { get; set; }
        public SearchResultsPaging Paging { get; set; }

        public SearchResults()
        {
            this.AuthUser = new AuthUser();
            this.Jobs = new List<Job>();
            this.Paging = new SearchResultsPaging();
        }
    }
}
