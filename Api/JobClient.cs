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


namespace Spring.Social.oDesk.Api
{
    /// <summary>
    /// Representation of oDesk job client data.
    /// </summary>
    /// <author>Tom Day</author>
    public class JobClient
    {
        public string Country { get; set; }
        public float FeedbackRating { get; set; }
        public int ReviewCount { get; set; }
        public int JobCount { get; set; }
        public int HireCount { get; set; }
        public string PaymentVerificationStatus { get; set; }
    }
}
