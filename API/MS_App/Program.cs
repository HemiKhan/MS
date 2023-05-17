using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MS_App.Helper;
using MS_Data.AppContext;
using MS_Data.DataConfig;
using MS_Models.FilterModel;
using MS_Models.Model;
using MS_Services.SignalR;
using Newtonsoft.Json.Serialization;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;


var SQLConnection = builder.Configuration.GetConnectionString("SQLConnection");
services.AddDbContext<AppDbContext>(db => db.UseSqlServer(SQLConnection));


// Add Identity Connection Start
services.AddIdentity<ApplicationUser, ApplicationRole>(ad =>
{
    ad.Password.RequiredLength = 5;
    ad.Password.RequireDigit = true;
    ad.Password.RequireLowercase = true;
    ad.SignIn.RequireConfirmedEmail = true;
    ad.User.RequireUniqueEmail = true;

})
.AddDefaultTokenProviders()
.AddTokenProvider<EmailConfirmationTokenProvider<ApplicationUser>>("emailconfirmtion")
.AddTokenProvider<ResetPasswordTokenProvider<ApplicationUser>>("resetpassword")
.AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();
// Add Identity Connection End


// Add Authentication JWT Token Start
services.AddAuthentication(a =>
{
    a.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    a.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(jb =>
{
    jb.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Constrant.Authenticatekey)),
        ValidateIssuer = true,
        ValidIssuer = Constrant.AuthenticateIssuer,
        ValidAudience = Constrant.AuthenticateAudience,
        ValidateIssuerSigningKey = true,
        ValidateAudience = true,
        RequireExpirationTime = true,
    };
});
// Add Authentication JWT Token End


// Add App Services Start
services.AddSignalR();
services.AddLogging();
services.AddAppServices();
// Add App Services End


// Add Controllers Start
services.AddControllers(options =>
{
    options.ModelBinderProviders.Insert(0, new FilterModelBinderProvider());
    //options.Filters.Add(typeof(Authorization));
}).AddNewtonsoftJson(opts =>
{
    opts.SerializerSettings.ContractResolver = new DefaultContractResolver();
    opts.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
}).AddJsonOptions(opt =>
    opt.JsonSerializerOptions.PropertyNamingPolicy = null);
// Add Controllers End

// Add API Explorer & Swagger Start
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();
// Add API Explorer & Swagger End

// Add Cors for Ajax Request Start
var MyCorsPolicy = "devCorsPolicy";
builder.Services.AddCors(options =>
{
    options.AddPolicy(MyCorsPolicy, builder =>
    {
        builder.WithOrigins("https://localhost:7202/").AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
        //builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
        //builder.SetIsOriginAllowed(origin => new Uri(origin).Host == "localhost");
        //builder.SetIsOriginAllowed(origin => true);
    });
});
//Add Cors for Ajax Request End

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Management System API");
    });
}

app.UseExceptionHandler("/exception");

app.UseHttpsRedirection();

app.UseCors(MyCorsPolicy);

app.UseStaticFiles();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.MapHub<SignalR>("/realtime");

app.Run();
