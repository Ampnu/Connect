using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SpaConnect.Models
{
    public class Program
    {
        [Key]
        public int programID { get; set; }

        public string programName { get; set; }
    }
}