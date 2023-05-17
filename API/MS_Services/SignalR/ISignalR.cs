using MS_Models.Common;
using MS_Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS_Services.SignalR
{
    public interface ISignalR
    {
        Task<Response<Employee>> GetDataAsync();
    }
}
