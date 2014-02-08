using Spring.Rest.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spring.Social.oDesk.Api
{
    public interface IoDesk : IApiBinding
    {
        IJobSearchOperations JobSearchOperations { get; }
        IRestOperations RestOperations { get; }
    }
}
