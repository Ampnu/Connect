using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SpaConnect.Models;

namespace SpaConnect.ViewModels
{
    public class StepVM
    {
        public IEnumerable<Step> stepIDVM { get; set; } //list of steps from the DB
        public IEnumerable<Operation> utilIDVM { get; set; } //list of operations from the DB
        public IEnumerable<string> LessonPlans { get; set; }
        public IEnumerable<string> ToolsList { get; set; }
        public IEnumerable<string> GeneralNotes { get; set; }
    }
}