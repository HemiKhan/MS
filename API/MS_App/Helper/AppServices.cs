using MS_Services.Account;
using MS_Services.Employees;
using MS_Services.Mail;
using MS_Services.Pagination;
using MS_Services.Seed;
using MS_Services.StoredProcedures;
using MS_Services.UriFilterService;

namespace MS_App.Helper
{
    public static class AppServices
    {
        public static IServiceCollection AddAppServices(this IServiceCollection appservices)
        {
            appservices.AddTransient<ISeedService, SeedService>();
            appservices.AddTransient<IAccountService, AccountService>();
            appservices.AddTransient<IEmployeeService, EmployeeService>();
            appservices.AddTransient<IPaginationSerivce, PaginationSerivce>();
            appservices.AddTransient<IStoredProcedureService, StoredProcedureService>();
            appservices.AddTransient<IMailService, MailService>();
            appservices.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
            //PaginationSerivce
            appservices.AddHttpContextAccessor();
            appservices.AddSingleton<IUriService>(o =>
            {
                var accessor = o.GetRequiredService<IHttpContextAccessor>();
                var request = accessor.HttpContext.Request;
                var uri = string.Concat(request.Scheme, "://", request.Host.ToUriComponent());
                return new UriService(uri);
            });
            return appservices;
        }
    }
}
