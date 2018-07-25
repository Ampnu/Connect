using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SpaConnect.Models;

namespace SpaConnect.ViewModels
{
    public class NewAssetVM
    {
        public IEnumerable<Program> programsIDVM { get; set; } //list from the DB
        public Assy asmbVM { get; set; } //access to assembly model variables

        public IEnumerable<Assy> asmbIDVM { get; set; } //list from the DB
        public Operation opVM { get; set; } //access to operation model variables
    }
}