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
        public int ID { get; set; }
        public string assyName { get; set; }

        //nav property//
        public int programID { get; set; }
        public Program program { get; set; }

    }
}
