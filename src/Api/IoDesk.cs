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

using Spring.Rest.Client;

namespace Spring.Social.oDesk.Api
{
    /// <summary>
    /// Interface specifying a set of operations for interacting with oDesk.
    /// </summary>
    /// <author>Tom Day</author>
    public interface IoDesk : IApiBinding
    {
        IJobSearchOperations JobSearchOperations { get; }
        IRestOperations RestOperations { get; }
    }
}
