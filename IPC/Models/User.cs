using System;
using System.ComponentModel.DataAnnotations;

namespace IPC.Models
{
    public class User
    {
        public Guid ID { get; set; }

        [Display(Name ="Full Name")]
        [MinLength(2, ErrorMessage = "Full Name at least 2 charcters .")]
        [MaxLength(50, ErrorMessage = "Full Name max 50 charcters .")]
        [Required(ErrorMessage = "Please Enter Full Name .")]
        public string FullName { get; set; }



        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Please Enter Your Email Address .")]
        public string Email { get; set; }

        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [MinLength(5, ErrorMessage = "Password must be at least 5 charcters .")]
        [MaxLength(50, ErrorMessage = "Password must be 50 charcters max .")]
        [Required(ErrorMessage = "Please Enter Your Password .")]
        public string PW { get; set; }

        [Display(Name = "Age")]
        [Range(1, 120, ErrorMessage = "Range must be between 1:120 years .")]
        [Required(ErrorMessage = "Please Enter Age .")]
        public short Age { get; set; }

        [Display(Name = "Image")]
        public byte[] Img { get; set; }

        [Display(Name = "Role Name")]
        [Required]
        public System.Guid RoleID { get; set; }
    }
}