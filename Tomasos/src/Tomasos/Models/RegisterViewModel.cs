using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tomasos.Models
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [StringLength(100,ErrorMessage ="Between 6 and 100 characters!",MinimumLength =6)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Display(Name ="Confirm password")]
        [Compare("Password",ErrorMessage ="The password and confirmation does not match")]
        public string ConfirmPassword { get; set; }
    }
}
