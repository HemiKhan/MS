using MS_Services.Account;
using MS_Services.AdmissionService;
using MS_Services.CampusService;
using MS_Services.ClassSectionService;
using MS_Services.ClassService;
using MS_Services.FeeStrutureService;
using MS_Services.Mail;
using MS_Services.OrganizationService;
using MS_Services.SectionService;
using MS_Services.Seed;
using MS_Services.SessionService;

namespace MS_App.Helper
{
    public static class AppServices
    {
        public static IServiceCollection AddAppServices(this IServiceCollection appservices)
        {
            appservices.AddTransient<IOrganizationService, OrganizationService>();
            appservices.AddTransient<ICampusService, CampusService>();
            appservices.AddTransient<ISessionService, SessionService>();
            appservices.AddTransient<ISectionService, SectionService>();
            appservices.AddTransient<IClassService, ClassService>();
            appservices.AddTransient<IClassSectionService, ClassSectionService>();
            appservices.AddTransient<IFeeStrutureService, FeeStrutureService>();
            appservices.AddTransient<IAdmissionService, AdmissionService>();

            appservices.AddTransient<ISeedService, SeedService>();
            appservices.AddTransient<IAccountService, AccountService>();
            appservices.AddTransient<IMailService, MailService>();
            appservices.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
            return appservices;
        }
    }
}
