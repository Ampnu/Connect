using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SpaConnect.Models;
using System.Data.Entity;

namespace SpaConnect.Controllers
{
    public class ProgramController : Controller
    {
        private RouterDBContext _context;

        public ProgramController()
        {
            _context = new RouterDBContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Program
        public ActionResult Index()
        {
            var programs = _context.programDB.ToList();

          return View(programs);
        }

        public ActionResult Details(int id)
        {
            var programs = _context.programDB.SingleOrDefault(p => p.ID == id);

            if (programs == null)
                return HttpNotFound();

            return View(programs);
        }

    }
}