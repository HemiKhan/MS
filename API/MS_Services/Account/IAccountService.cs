﻿using Microsoft.AspNetCore.Identity;
using MS_Models.Common;
using MS_Models.Model;
using MS_Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS_Services.Account
{
    public interface IAccountService
    {
        Task<Response<SignUpViewModel>> GetUserAsync();
        Task<Response<SignUpViewModel>> SignupAsync(SignUpViewModel register);
        Task<Response<string>> LoginAync(LoginViewModel login);
        Task<Response<string>> ConfirmEmailAsync(string userId, string token);
        Task<Response<string>> ForgetPasswordAsync(string email);
        Task<Response<ResetPasswordViewModel>> ResetPasswordAsync(ResetPasswordViewModel model);
        Task<Response<ChangePasswordViewModel>> ChangePasswordAsync(ChangePasswordViewModel model);
        Task<Response<string>> AssignUserRoles(UserRolesViewModel userRoles);
    }
}
