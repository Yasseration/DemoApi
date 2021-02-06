using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IPC.Models
{
    public class Role
    {
        public Guid ID { get; set; }
        [Required(ErrorMessage = "Please Enter Role Name .")]
        public string RoleName { get; set; }
    }
}