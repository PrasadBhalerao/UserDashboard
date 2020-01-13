using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Dashboard.Persistence.Models
{
    [Table("Status")]
    public class Status
    {
        [Key]
        public int KeyID { get; set; }
        public string Name { get; set; }
    }
}
