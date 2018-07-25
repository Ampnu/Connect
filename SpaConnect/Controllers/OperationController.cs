using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using SpaConnect.Models;
using SpaConnect.ViewModels;

namespace SpaConnect.Controllers
{
    public class OperationController : Controller
    {
        private RouterDBContext _context;

        public OperationController()
        {
            _context = new RouterDBContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Details(int id)
        {
            List<Operation> ops = _context.operationDB.Include(m => m.assembly).Where(a => a.asmbID == id).ToList();

            return View(ops);
        }

        public ActionResult New(int id)
        {
            List<Assy> asmbID = _context.assyDB.Where(m => m.ID == id).ToList(); //retriving list of assemblies for the DB

            var viewModel = new NewAssetVM
            {
                asmbIDVM = asmbID // storing the list in the new assemblies list
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(NewAssetVM op)
        {
            _context.operationDB.Add(op.opVM); //adding object to the database
            _context.SaveChanges();
            return RedirectToAction("Details", "Operation", new { id = op.opVM.asmbID });
        }

        public ActionResult Result()
        {

            return View();
        }
    }
}