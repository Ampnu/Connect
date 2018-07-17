using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SpaConnect.Models;
using System.Data.Entity;
using SpaConnect.ViewModels;

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
            var assy = _context.assyDB.Where(a => a.programID == id).ToList();

            return View(assy);
        }

        public ActionResult New()
        {
            List<Program> programID = _context.programDB.ToList();

            var viewModel = new NewAssyVM
            {
                programsIDVM = programID
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(Assy assy )
        {
            if (assy.programID == 0)
            {
                _context.assyDB.Add(assy); //adding object to the database
            }
            else
            {
                return HttpNotFound();
            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Program");
        }
    }
}