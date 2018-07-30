using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SpaConnect.Models
{
    public class Operation
    {
        [Key]
        public int ID { get; set; }
        public string OPN { get; set; }
        public string opTitle { get; set; }
        public string lessonPlan { get; set; }
        public string tools { get; set; }
        public string generalNotes { get; set; }

        //nav property//
        public int asmbID { get; set; }
        public Assy assembly { get; set; }
    }
}