using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpaConnect.Models
{
    public class Assy
    {
        [Key]
        public int assyID { get; set; }
        public string assyName { get; set; }
        public Program program_FK { get; set; }

    }
}
