using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IPC_API.Models
{
    public class UsersModel
    {
        public Guid ID { get; set; }
        public string FullName { get; set; }
        public short Age { get; set; }
        public string Email { get; set; }
        public string PW { get; set; }
        public byte[] Img { get; set; }
        public Guid RoleID { get; set; }
    }
}