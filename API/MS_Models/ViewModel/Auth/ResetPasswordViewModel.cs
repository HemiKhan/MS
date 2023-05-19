using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS_Models.ViewModel.Auth
{
    public class ResetPasswordViewModel
    {
        [Required]
        public string Token { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 5)]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string NewPassword { get; set; }
        [Required]
        public string ConfirmPassword { get; set; }
    }
}
