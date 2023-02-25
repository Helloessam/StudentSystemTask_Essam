using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystem.Shared
{
    public class UserRegister
    {
        [Required]
        public string Regnum { get; set; } 
        [Required, StringLength(50, MinimumLength =6)]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage ="Passwords do not match")]
        public string ConfirmPassword { get; set; } 

    }
}
