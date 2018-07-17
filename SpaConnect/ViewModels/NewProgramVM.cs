using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SpaConnect.Models;

namespace SpaConnect.ViewModels
{
    public class NewProgramVM
    {
        public IEnumerable<Program> programsVM { get; set; }
        public Program programVM { get; set; }
    }
}