using MS_Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS_Services.UriFilterService
{
    public interface IUriService
    {
        public Uri GetPageUri(FilterViewModel filter, string route);
    }
}
