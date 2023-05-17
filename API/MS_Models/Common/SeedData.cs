using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS_Models.Common
{
    public static class SeedData
    {
        public static void UserRoles(this ModelBuilder builder)
        {
            const string RoleId = "745243b5-a530-417d-80a5-17b0ec14c8ff";
            const string UserId = "0fcc2972-e610-4237-a54a-15922531e405";
            var Password = new PasswordHasher<IdentityUser>();

            builder.Entity<IdentityRole>().HasData(
            new IdentityRole
            {
                Id = RoleId,
                Name = "Admin",
                NormalizedName = "Admin"
            });

            builder.Entity<IdentityUser>().HasData(
            new IdentityUser
            {
                Id = UserId,
                Email = "hammas.khan@itcurves.com",
                NormalizedEmail = "HAMMAS.KHAN@ITCURVES.COM",
                UserName = "hammas.khan@itcurves.com",
                NormalizedUserName = "HAMMAS.KHAN@ITCURVES.COM",
                PasswordHash = Password.HashPassword(null, "Hemi@4364"),
                PhoneNumber = "03470713121",
                SecurityStamp = "W43AR76LWLYNWOTZXVOUJIWQIYK56REQ",
                ConcurrencyStamp = "6114b45b-22c2-4fa6-8b96-7fd5607758c7"
            });

            builder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string>
            {
                RoleId = RoleId,
                UserId = UserId
            });
        }
    }
}
