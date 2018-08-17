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

        public ActionResult Edit(int id)
        {
            Program programToEdit = _context.programDB.SingleOrDefault(m=>m.ID==id);

            if(programToEdit.programName == null)
            {
                return HttpNotFound();
            }
            return View(programToEdit);
        }

        [HttpPost]
        public ActionResult Update(Program program)
        {
            if(program.ID == 0)
            {
                _context.programDB.Add(program); //adding object to the database
            }
            else
            {
                var programInDB = _context.programDB.SingleOrDefault(m => m.ID == program.ID);
                programInDB.programName = program.programName;
            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Program");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Program programToDelete = _context.programDB.SingleOrDefault(m => m.ID == id);

            return View(programToDelete);
        }

        [HttpPost]
        public ActionResult Remove(int id)
        {
            Program programToDelete = _context.programDB.SingleOrDefault(m => m.ID == id);
            _context.programDB.Remove(programToDelete);
            _context.SaveChanges();
            return RedirectToAction("Index", "Program");
        }
    }
}
