﻿using Microsoft.EntityFrameworkCore;
using MS_Data.AppContext;
using MS_Models.Common;
using MS_Models.Model;
using MS_Models.ViewModel;

namespace MS_Services.SessionService
{
    public class SessionService : ISessionService
    {
        private readonly AppDbContext db;
        public SessionService(AppDbContext db)
        {
            this.db = db;
        }

        public async Task<Response<SessionViewModel>> AddOrUpdateSessionAsync(SessionViewModel model)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(model.SessionName))
                    return new Response<SessionViewModel>
                    {
                        Message = "Session Name Not Found",
                        Status = false
                    };

                if (string.IsNullOrWhiteSpace(model.StartDate.ToString()))
                    return new Response<SessionViewModel>
                    {
                        Message = "Session Start Date Not Found",
                        Status = false
                    };

                if (string.IsNullOrWhiteSpace(model.EndDate.ToString()))
                    return new Response<SessionViewModel>
                    {
                        Message = "Session End Date Not Found",
                        Status = false
                    };

                var msg = "";

                if (model.SessionId > 0 || model.SessionId != null)
                {
                    var data = await db.Sessions.Where(x => x.Id == model.SessionId).FirstOrDefaultAsync();
                    if (data is null)
                        return new Response<SessionViewModel>
                        {
                            Message = "Data Not Found",
                            Status = false
                        };

                    data.SessionName = model.SessionName;
                    data.StartDate = model.StartDate;
                    data.EndDate = model.EndDate;
                    data.IsAtive = model.IsActive;
                    db.Sessions.Update(data);
                    msg = "Session (" + data.SessionName + ") Updated Successfully";
                }
                else
                {
                    Session sess = new Session();
                    sess.SessionName = model.SessionName;
                    sess.StartDate = model.StartDate;
                    sess.EndDate = model.EndDate;
                    sess.IsAtive = model.IsActive;
                    await db.Sessions.AddAsync(sess);
                    msg = "Session (" + sess.SessionName + ") Added Successfully";
                }

                await db.SaveChangesAsync();

                return new Response<SessionViewModel>
                {
                    Message = msg,
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
                if (SessId == 0)
                    return new Response<SessionViewModel>
                    {
                        Message = "Session Id Not Found",
                        Status = false
                    };

                var data = await db.Sessions.Where(x => x.Id == SessId).FirstOrDefaultAsync();
                if (data is null)
                    return new Response<SessionViewModel>
                    {
                        Message = "Data Not Found",
                        Status = false
                    };

                db.Sessions.Remove(data);
                await db.SaveChangesAsync();

                return new Response<SessionViewModel>
                {
                    Message = "Session Removed Successfully",
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
                if (SessId == 0)
                    return new Response<Session>
                    {
                        Message = "Sessions Id Not Valid",
                        Status = false
                    };

                var data = await db.Sessions.Where(x => x.Id == SessId).FirstOrDefaultAsync();
                if (data is null)
                    return new Response<Session>
                    {
                        Message = "Data Not Found",
                        Status = false
                    };

                return new Response<Session>
                {
                    Message = "Data Found Successfully",
                    Status = true,
                    Data = data
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
                var data = await db.Sessions.ToListAsync();
                if (data is null)
                    return new Response<Session>
                    {
                        Message = "Data Not Found",
                        Status = false
                    };

                return new Response<Session>
                {
                    Message = "Data Found Successfully",
                    Status = true,
                    List = data
                };
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
