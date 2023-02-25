using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystem.Shared
{
    public class userChangePassword
    {
        [Required,StringLength(50,MinimumLength =6)]
        public string Password { get; set; } = string.Empty;
        [Compare("Password",ErrorMessage ="The Password don't Match")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
