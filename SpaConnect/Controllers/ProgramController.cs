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
            //Format program name to all uppercase
            Program newProgram = new Program();
            newProgram.programName = program.programName.ToUpper();

            //Add new program to database
            _context.programDB.Add(newProgram); 
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
                programInDB.programName = program.programName.ToUpper();
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
