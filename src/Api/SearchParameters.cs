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

using System.ComponentModel;

namespace Spring.Social.oDesk.Api
{
    /// <summary>
    /// Enum to define allowable job types.
    /// </summary>
    public enum JobType
    {
        [Description("any")]
        Any,
        [Description("hourly")]
        Hourly,
        [Description("fixed")]
        Fixed
    }

    /// <summary>
    /// Enum to define allowable durations.
    /// </summary>
    public enum Duration
    {
        [Description("any")]
        Any,
        [Description("week")]
        Week,
        [Description("month")]
        Month,
        [Description("quarter")]
        Quarter,
        [Description("semester")]
        Semester,
        [Description("ongoing")]
        Ongoing
    }

    /// <summary>
    /// Enum to define allowable work loads.
    /// </summary>
    public enum WorkLoad
    {
        [Description("any")]
        Any,
        [Description("as_needed")]
        AsNeeded,
        [Description("part_time")]
        PartTime,
        [Description("full_time")]
        FullTime
    }

    /// <summary>
    /// Enum to define allowable job statuses.
    /// </summary>
    public enum JobStatus
    {
        [Description("any")]
        Any,
        [Description("open")]
        Open,
        [Description("completed")]
        Completed,
        [Description("cancelled")]
        Cancelled
    }

    /// <summary>
    /// Enum to define allowable sorting fields.
    /// </summary>
    public enum SortBy
    {
        [Description("create_time")]
        CreateTime,
        [Description("client_rating")]
        ClientRating,
        [Description("client_total_charge")]
        ClientTotalCharge,
        [Description("client_total_hours")]
        ClientTotalHours,
        [Description("score")]
        Score,
        [Description("workload")]
        Workload,
        [Description("duration")]
        Duration
    }

    /// <summary>
    /// Enum to define sorting directions.
    /// </summary>
    public enum SortDirection
    {
        [Description("desc")]
        Descending,
        [Description("asc")]
        Ascending
    }

    /// <summary>
    /// Class for defining an oDesk job search query string.
    /// </summary>
    /// <author>Tom Day</author>
    public class SearchParameters
    {
        public string Query { get; set; }
        public string Title { get; set; }
        public string Skills { get; set; }
        public string Category { get; set; }
        public string Subcategory { get; set; }
        public JobType JobType { get; set; }
        public Duration Duration { get; set; }
        public WorkLoad WorkLoad { get; set; }
        public string ClientFeedback { get; set; }
        public string ClientHires { get; set; }
        public string Budget { get; set; }
        public JobStatus JobStatus { get; set; }
        public int DaysPosted { get; set; }
        public int PageOffset { get; set; }
        public int PageSize { get; set; }
        public SortBy SortBy { get; set; }
        public SortDirection SortDirection { get; set; }

        public override string ToString()
        {
            var query = "";

            if (!string.IsNullOrEmpty(Query))
            {
                query = appendQueryParameter(query, "q", Query);
            }

            if (!string.IsNullOrEmpty(Title))
            {
                query = appendQueryParameter(query, "title", Title);
            }

            if (!string.IsNullOrEmpty(Skills))
            {
                query = appendQueryParameter(query, "skills", Skills);
            }

            if (!string.IsNullOrEmpty(Category))
            {
                query = appendQueryParameter(query, "category", Category);
            }

            if (!string.IsNullOrEmpty(Subcategory))
            {
                query = appendQueryParameter(query, "subcategory", Subcategory);
            }

            if (JobType.GetDescription() != "any")
            {
                query = appendQueryParameter(query, "job_type", JobType.GetDescription());
            }

            if (Duration.GetDescription() != "any")
            {
                query = appendQueryParameter(query, "duration", Duration.GetDescription());
            }

            if (WorkLoad.GetDescription() != "any")
            {
                query = appendQueryParameter(query, "workload", WorkLoad.GetDescription());
            }

            if (!string.IsNullOrEmpty(ClientFeedback))
            {
                query = appendQueryParameter(query, "client_feedback", ClientFeedback);
            }

            if (!string.IsNullOrEmpty(ClientHires))
            {
                query = appendQueryParameter(query, "client_hires", ClientHires);
            }

            if (!string.IsNullOrEmpty(Budget))
            {
                query = appendQueryParameter(query, "budget", Budget);
            }

            if (JobStatus.GetDescription() != "any")
            {
                query = appendQueryParameter(query, "job_status", JobStatus.GetDescription());
            }

            if (DaysPosted > 0)
            {
                query = appendQueryParameter(query, "days_posted", DaysPosted.ToString());
            }

            if (PageOffset > 0 || PageSize > 0)
            {
                // Limit paging count to 100
                if (PageSize > 100) PageSize = 100;

                query = appendQueryParameter(query, "paging", PageOffset.ToString() + ";" + PageSize.ToString());
            }

            if (SortBy.GetDescription() != "create_time" || SortDirection.GetDescription() != "desc")
            {
                query = appendQueryParameter(query, "sort", SortBy.GetDescription() + "%20" + SortDirection.GetDescription());
            }

            return query;
        }

        private string appendQueryParameter(string query, string key, string value)
        {
            if (string.IsNullOrEmpty(query))
            {
                query = "?" + key + "=" + value;
            }
            else
            {
                query = query + "&" + key + "=" + value;
            }

            return query;
        }
    }
}
