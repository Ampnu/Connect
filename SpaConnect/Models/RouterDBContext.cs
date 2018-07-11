using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace SpaConnect.Models
{
    public class RouterDBContext : DbContext
    {
        public DbSet<Program> programDB { get; set; }
        public DbSet<Assy> assyDB { get; set; }
        public DbSet<Operation> operationDB { get; set; }
        public DbSet<Step> stepDB { get; set; }
    }
}