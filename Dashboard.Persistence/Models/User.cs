using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Dashboard.Persistence.Models
{
    [Table("User")]
    public class User
    {
        [Key]
        public int KeyID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Status Status { get; set; }
        [ForeignKey("Status")]
        public int StatusId { get; set; }
        public Role Role { get; set; }
        [ForeignKey("Role")]
        public int RoleId { get; set; }
        public string MobileNumber { get; set; }
    }
}
