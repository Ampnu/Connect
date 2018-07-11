using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SpaConnect.Models;
using System.Data.Entity;

namespace SpaConnect.Controllers
{
    public class AssemblyController : Controller
    {
        private RouterDBContext _context;

        public AssemblyController()
        {
            _context = new RouterDBContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        
        public ActionResult Details(int id)
        {
            var assy = _context.assyDB.Single(a => a.assyID == id);

            if (assy == null)
                return HttpNotFound();

            return View(assy);
        }
    }
}