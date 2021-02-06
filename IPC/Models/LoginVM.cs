using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IPC.Models
{
    public class LoginVM
    {
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Please Enter Your Email Address .")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [MinLength(5, ErrorMessage = "Password must be at least 5 charcters .")]
        [MaxLength(50, ErrorMessage = "Password must be 50 charcters max .")]
        [Required(ErrorMessage = "Please Enter Your Password .")]
        public string PW { get; set; }
    }
}