using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spring.Social.oDesk.Api
{
    public interface IJobSearchOperations
    {
        SearchResults Search(SearchParameters parameters);
    }
}
