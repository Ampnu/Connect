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
            List<Program> programs = _context.programDB.ToList();

          return View(programs);
        }

        public ActionResult Display()
        {

            return View();
        }

        public ActionResult New()
        {        
            return View();
        }

        [HttpPost]
        public ActionResult Create(Program program)
        {
            _context.programDB.Add(program); //adding object to the database
            _context.SaveChanges();
            return RedirectToAction("Index", "Program");
        }
    }
}