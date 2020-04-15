using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities
{
    public class Blacklist
    {
        [Key]
        public int Id { get; set; }
        public string Ip { get; set; }
        public DateTime Createtime { get; set; }
    }
}
