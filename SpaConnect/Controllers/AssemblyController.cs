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

        public ActionResult Index(int id)
        {
            List<Assy> assyID = _context.assyDB.ToList();

            foreach (var val in assyID)
            {
                if (id == val.programID)
                {
                    return RedirectToAction("Details", "Assembly", new { id = id });
                }
            }
            return RedirectToAction("New", "Assembly", new { id = id });
        }

        public ActionResult Details(int id)
        {
            List<Assy> assy = _context.assyDB.Where(a => a.programID == id).ToList();

            return View(assy);
        }

        public ActionResult New(int id)
        {
            List<Program> programID = _context.programDB.Where(m=>m.ID == id).ToList(); //retriving program for the DB

            var viewModel = new NewAssetVM
            {
                programsIDVM = programID //storing the list in the a new program list
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(NewAssetVM asmb)
        {
            _context.assyDB.Add(asmb.asmbVM); //adding object to the database
            _context.SaveChanges();
            return RedirectToAction("Details", "Assembly", new { id = asmb.asmbVM.programID });
            //return RedirectToAction("Index", "Program");
        }
    }
}