using Dashboard.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dashboard.Persistence.ValueObjects
{
    public class UserVO
    {
        public int KeyID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string StatusName { get; set; }
        public int StatusId { get; set; }
        public string RoleName { get; set; }        
        public int RoleId { get; set; }
        public string MobileNumber { get; set; }
    }
}
