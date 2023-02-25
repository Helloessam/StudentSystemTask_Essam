using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystem.Shared
{
    public class UserLogin
    {
        [Required]
        public string Regnum { get; set;} = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;

    }
}
