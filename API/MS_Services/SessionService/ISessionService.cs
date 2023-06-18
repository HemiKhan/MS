using MS_Models.Common;
using MS_Models.Model;
using MS_Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS_Services.SessionService
{
    public interface ISessionService
    {
        Task<Response<Session>> GetSessionAsync();
        Task<Response<Session>> GetBySessionIdAsync(int SessId);
        Task<Response<SessionViewModel>> AddOrUpdateSessionAsync(SessionViewModel model);
        Task<Response<SessionViewModel>> DeleteSessionAsync(int SessId);
    }
}
