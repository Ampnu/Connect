using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SpaConnect.Models;

namespace SpaConnect.ViewModels
{
    public class NewAssyVM
    {
        public IEnumerable<Program> programsIDVM { get; set; } //list for dropdown box
        public Assy asmbVM { get; set; } //access to assembly model variables
    }
}