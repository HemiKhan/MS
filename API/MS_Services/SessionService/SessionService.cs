using MS_Data.AppContext;
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
    public class SessionService : ISessionService
    {
        private readonly AppDbContext db;
        public SessionService(AppDbContext db)
        {
            this.db = db;
        }


        public async Task<Response<SessionViewModel>> AddSessionAsync(SessionViewModel model)
        {
            try
            {
                return new Response<SessionViewModel>
                {
                    Message = "Found Data Successfully",
                    Status = true
                };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Response<SessionViewModel>> DeleteSessionAsync(int SessId)
        {
            try
            {
                return new Response<SessionViewModel>
                {
                    Message = "Found Data Successfully",
                    Status = true
                };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Response<Session>> GetBySessionIdAsync(int SessId)
        {
            try
            {
                return new Response<Session>
                {
                    Message = "Found Data Successfully",
                    Status = true
                };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Response<Session>> GetSessionAsync()
        {
            try
            {
                return new Response<Session>
                {
                    Message = "Found Data Successfully",
                    Status = true
                };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Response<SessionViewModel>> UpdateSessionAsync(Session model)
        {
            try
            {
                return new Response<SessionViewModel>
                {
                    Message = "Found Data Successfully",
                    Status = true
                };
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
