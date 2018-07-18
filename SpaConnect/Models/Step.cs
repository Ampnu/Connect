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
        public int ID { get; set; }
        public string instructions { get; set; }
        //public int timeStart { get; set; }
        //public int timeEnd { get; set; }

        //nav property//
        public int operationID { get; set; }
        public Operation operations { get; set; }
    }
}