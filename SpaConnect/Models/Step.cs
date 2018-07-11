using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SpaConnect.Models
{
    public class Step
    {
        [Key]
        public int stepID { get; set; }
        public string instructions { get; set; }
        public int timeStart { get; set; }
        public int timeEnd { get; set; }
        public Operation op_FK { get; set; }
    }
}